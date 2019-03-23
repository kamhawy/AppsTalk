#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;
using ABATS.AppsTalk.Runtime.Services.Core.Adapters;
using ABATS.AppsTalk.Runtime.Services.Core.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core
{
    /// <summary>
    /// Core Service
    /// </summary>
    [Serializable]
    internal class CoreService : AppServiceBase, ICoreService
    {
        #region Members

        private ProcessMappingManager _FieldMappingManager = null;

        #endregion

        #region Properties

        internal ProcessMappingManager FieldMappingManager
        {
            get
            {
                if (this._FieldMappingManager == null)
                {
                    this._FieldMappingManager = new ProcessMappingManager(base.AppRuntime);
                }
                return this._FieldMappingManager;
            }
            private set
            {
                this._FieldMappingManager = value;
            }
        }

        #endregion

        #region Constructor

        internal CoreService(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {
        }

        #endregion

        #region IRuntimeService

        public bool Initialize()
        {
            bool success = false;

            try
            {
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #region ICoreService

        /// <summary>
        ///     Execute Integration Process
        /// </summary>
        /// <param name="pProcessExecutionRequest"></param>
        /// <returns></returns>
        public ProcessExecutionResponse ExecuteIntegrationProcess(ProcessExecutionRequest pProcessExecutionRequest)
        {
            ProcessExecutionResponse response = null;
            List<IntegrationProcessMapping> processMapping = null;
            DataTable destinationTable = null;
            List<FieldMappingInfo> mappingInfos = null;
            PushToDestinationRequest pushToDestinationRequest = null;
            string outputMessage = string.Empty;

            try
            {
                #region Integration Process Metadata
                
                LogManager.LogMessage(string.Format(ABATS.AppsTalk.Runtime.Properties.Resources.Message_Integration_Process_Execution_Start_Request, 
                    pProcessExecutionRequest.ProcessCode));

                response = new ProcessExecutionResponse(pProcessExecutionRequest,
                    base.AppRuntime.MetadataService.GetIntegrationProcessMetatdata(pProcessExecutionRequest.ProcessCode));

                #endregion

                if (response != null && response.IntegrationProcessMetadata != null)
                {
                    LogManager.LogMessage(string.Format(ABATS.AppsTalk.Runtime.Properties.Resources.Message_Integration_Process_Execution_Started,
                        response.IntegrationProcessMetadata.IntegrationProcessCode,
                        response.IntegrationProcessMetadata.IntegrationProcessID,
                        response.IntegrationProcessMetadata.IntegrationProcessTitle));

                    if (this.ValidateIntegrationProcess(response.IntegrationProcessMetadata, out outputMessage))
                    {
                        LogManager.LogMessage(string.Format(ABATS.AppsTalk.Runtime.Properties.Resources.Message_Integration_Process_Validation_Succeeded,
                            response.IntegrationProcessMetadata.IntegrationProcessCode));
                        
                        #region Consume Source

                        using (AbstractAdapter sourceAdapter = AdapterFactory.CreateAdapter(
                            response.IntegrationProcessMetadata,
                            response.IntegrationProcessMetadata.SourceIntegrationAdapter, 
                            base.AppRuntime))
                        {
                            response.SourceAdapterResponse = sourceAdapter.ConsumeSource();
                        }

                        #endregion

                        if (response.SourceAdapterResponse != null &&
                            response.SourceAdapterResponse.Status == OperationStatus.Succeeded)
                        {
                            LogManager.LogMessage(string.Format(ABATS.AppsTalk.Runtime.Properties.Resources.Message_Integration_Process_ConsumeSource_Succeeded,
                                response.IntegrationProcessMetadata.IntegrationProcessCode,
                                response.SourceAdapterResponse.Results.Count.SafeToString("0")));

                            #region Publish To Destination
                            
                            pushToDestinationRequest = new PushToDestinationRequest(
                                pProcessExecutionRequest.RequestDate, pProcessExecutionRequest.RequestUser);

                            #region Mapping

                            processMapping = base.AppRuntime.DataService.GetAll(
                                DataUtilities.BuildIntegrationProcessMappingGetDataRequest(response.IntegrationProcessMetadata)).ToList();
                            destinationTable = new DataTable();
                            mappingInfos = new List<FieldMappingInfo>();

                            foreach (IntegrationAdapterField destinationAdapterField in
                                response.IntegrationProcessMetadata.DestinationIntegrationAdapter.IntegrationAdapterFields)
                            {
                                var mappingField = processMapping.FirstOrDefault(item =>
                                    item.DestinationIntegrationAdapterFieldID == destinationAdapterField.IntegrationAdapterFieldID);

                                if (mappingField != null)
                                {
                                    mappingInfos.Add(new FieldMappingInfo()
                                    {
                                        SourceField = mappingField.SourceIntegrationAdapterField,
                                        DestinationField = destinationAdapterField,
                                        MappingDetail = mappingField
                                    });

                                    destinationTable.Columns.Add(destinationAdapterField.FieldName);
                                }
                            }

                            #endregion

                            #region Caching

                            // Handle the Integration Adapter Cahce
                            List<AdapterCacheResult> sourceQueryCahce = null;

                            using (AdapterCacheManager queryCacheManager = new AdapterCacheManager(base.AppRuntime))
                            {
                                sourceQueryCahce = queryCacheManager.BuildAdapterCacheResults(response.SourceAdapterResponse);
                            }

                            LogManager.LogMessage(string.Format(ABATS.AppsTalk.Runtime.Properties.Resources.Message_Integration_Process_Cache_Prepration_Completed,
                                sourceQueryCahce != null ? sourceQueryCahce.Count.ToString() : "0"));

                            foreach (AdapterCacheResult cacheItem in sourceQueryCahce)
                            {
                                try
                                {
                                    DBRecordInfo destinationRecord = this.FieldMappingManager.BuildDestinationRecord(
                                        destinationTable, cacheItem.DBRecord, mappingInfos);

                                    if (destinationRecord != null)
                                    {
                                        pushToDestinationRequest.AdapterCacheResults.Add(new AdapterCacheResult()
                                        {
                                            DBRecord = destinationRecord,
                                            DBRecordCache = cacheItem.DBRecordCache
                                        });
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string extraMessage = string.Format("Record Keys: {0} - Parameter: {1}",
                                        cacheItem.DBRecord != null ? cacheItem.DBRecord.DbRecordKey : "NO KEYS",
                                        cacheItem.DBRecord != null ? cacheItem.DBRecord.ExceptionExtraMessage : string.Empty);

                                    LogManager.LogException(ex, extraMessage);
                                }
                            }

                            #endregion

                            #region Destination Adapter Push Request

                            using (AbstractAdapter destinationAdapter = AdapterFactory.CreateAdapter(
                                response.IntegrationProcessMetadata,
                                response.IntegrationProcessMetadata.DestinationIntegrationAdapter, 
                                base.AppRuntime))
                            {
                                response.DestinationAdapterResponse = destinationAdapter.PublishToDestination(
                                    pushToDestinationRequest);

                                if (response.DestinationAdapterResponse != null &&
                                    response.DestinationAdapterResponse.Status == OperationStatus.Succeeded)
                                {
                                    response.Status = OperationStatus.Succeeded;
                                    response.Message = string.Format(Properties.Resources.Message_Integration_Process_Execution_Succeeded,
                                        response.IntegrationProcessMetadata.IntegrationProcessCode);
                                }
                                else
                                {
                                    response.Status = OperationStatus.Failed;
                                    response.Message = string.Format(Properties.Resources.Message_Integration_Process_Execution_Failed,
                                        response.IntegrationProcessMetadata.IntegrationProcessCode);
                                }
                            }

                            #endregion

                            #endregion
                        }
                        else
                        {
                            response.Status = OperationStatus.Failed;
                            response.Message = string.Format(Properties.Resources.Message_Consume_Source_Failed,
                                response.IntegrationProcessMetadata.IntegrationProcessCode);
                        }
                    }
                    else
                    {
                        response.Status = OperationStatus.Failed;
                        response.Message = string.Format(Properties.Resources.Message_Metadata_Validation_Failed,
                            response.IntegrationProcessMetadata.IntegrationProcessCode, Environment.NewLine, outputMessage);
                    }
                }
                else
                {
                    response.Status = OperationStatus.Failed;
                    response.Message = string.Format(Properties.Resources.Message_Fetch_integration_Process_Metadata_Failed,
                        pProcessExecutionRequest.ProcessCode);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
            finally
            {
                if (response != null && !string.IsNullOrEmpty(response.Message))
                {
                    LogManager.LogMessage(response.Message, response.Status);
                }

                if (response != null)
                {
                    //Log Integration Transaction
                    using (TransactionLogManager transactionLogManager = new TransactionLogManager(base.AppRuntime))
                    {
                        transactionLogManager.LogIntegrationProcessTransaction(response);
                    }
                }

                outputMessage = null;
            }

            return response;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Validate Integration Process
        /// </summary>
        /// <param name="pIntegrationProcess"></param>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        private bool ValidateIntegrationProcess(IntegrationProcess pIntegrationProcess, out string pMessage)
        {
            bool isValid = true;
            pMessage = string.Empty;

            if (pIntegrationProcess.SourceIntegrationAdapter == null)
            {
                isValid = false;
                pMessage += "[Source Integration Adapter] can't be null";
            }

            if (pIntegrationProcess.DestinationIntegrationAdapter == null)
            {
                isValid = false;
                pMessage += "[Destination Integration Adapter] can't be null";
            }

            return isValid;
        }

        #endregion

        #region Factory

        internal static ICoreService Create(IAppRuntime pIAppRuntime)
        {
            return new CoreService(pIAppRuntime);
        }

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}