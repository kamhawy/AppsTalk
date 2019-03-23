using ABATS.AppsTalk.Adapters.WincashWSAdapter.MaterialInterfaceReference;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;
using ABATS.AppsTalk.Runtime.Services.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABATS.AppsTalk.Adapters.WincashWSAdapter
{
    /// <summary>
    /// Wincash Materials Adapter
    /// </summary>
    public class WincashAdapter : AbstractWSProvider
    {
        #region Members

        private WincashWSAdapterConfig _AdapterConfigurations = null;

        #endregion

        #region Properties

        internal WincashWSAdapterConfig AdapterConfigurations
        {
            get
            {
                if (this._AdapterConfigurations == null)
                {
                    this._AdapterConfigurations = new WincashWSAdapterConfig();
                }

                return this._AdapterConfigurations;
            }
        }

        #endregion

        #region Constructors

        public WincashAdapter(IntegrationAdapter pAdapterMetadata, ApplicationWebService pApplicationWebServiceMetadata, IAppRuntime pAppRuntime)
            : base(pAdapterMetadata, pApplicationWebServiceMetadata, pAppRuntime)
        {

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Invoke Application Web Service Request - GET
        /// </summary>
        /// <param name="pApplicationWebServiceRequest"></param>
        /// <returns></returns>
        public override WSSourceAdapterResponse InvokeApplicationWebServiceRequest_GET(ApplicationWebServiceRequest pApplicationWebServiceRequest)
        {
            WSSourceAdapterResponse response = null;

            try
            {
                response = new WSSourceAdapterResponse(base.AdapterMetadata, pApplicationWebServiceRequest);
                response.Results = new List<DBRecordInfo>();
                // Fire the web service request and fill the results


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return response;
        }

        /// <summary>
        /// Invoke Application Web Service Request - POST
        /// pPushToDestinationRequest.AdapterCacheResults >> Read the post cache records and fire the web service request to post them
        /// </summary>
        /// <param name="pApplicationWebServiceRequest"></param>
        /// <param name="pPushToDestinationRequest"></param>
        /// <returns></returns>
        public override WSDestinationAdapterResponse InvokeApplicationWebServiceRequest_POST(ApplicationWebServiceRequest pApplicationWebServiceRequest, PushToDestinationRequest pPushToDestinationRequest)
        {
            WSDestinationAdapterResponse response = null;

            try
            {
                response = new WSDestinationAdapterResponse(base.AdapterMetadata, pApplicationWebServiceRequest);

                #region Request Header

                fullMaterialRequestData request = new fullMaterialRequestData();

                // Build the request header as configured in the NTSwincash management console
                requestHeader _requestHeader = new requestHeader()
                {
                    securityToken = new securityToken()
                    {
                        userName = this.AdapterConfigurations.SecurityTokenUserName,
                        password = this.AdapterConfigurations.SecurityTokenPassword,
                    },
                    interfaceVersion = this.AdapterConfigurations.InterfaceVersion,
                    buildNumber = this.AdapterConfigurations.BuildNumber,
                    senderID = this.AdapterConfigurations.SenderID,
                    //request uniqueID, can be used by the NTSwincash interface to identify if a request was sent more than one time 
                    uniqueID = WincashWSAdapterUtilities.BuildUniqueID(),
                    numberOfRecords = pPushToDestinationRequest.AdapterCacheResults.Count.SafeToString()
                };

                request.requestHeader = _requestHeader;

                #endregion

                #region Request Builders

                List<standardMaterial> _standardMaterials = new List<standardMaterial>();
                List<DBRecordInfo> dbRecords = new List<DBRecordInfo>();

                foreach (AdapterCacheResult adapterCacheResult in pPushToDestinationRequest.AdapterCacheResults)
                {
                    standardMaterial material = WincashWSAdapterUtilities.BuildStandardMaterialObject(adapterCacheResult.DBRecord, this.AdapterConfigurations);

                    if (material != null)
                    {
                        dbRecords.Add(adapterCacheResult.DBRecord);
                        _standardMaterials.Add(material);
                    }
                }

                standardMaterialList _standardMaterialList = new standardMaterialList()
                {
                    transferMode = dataTransferMode.DELTA,
                    transferModeSpecified = true,
                    material = _standardMaterials.ToArray()
                };

                fullMaterialType _fullMaterialType = new fullMaterialType()
                {
                    materials = _standardMaterialList
                };

                request.interfaceData = _fullMaterialType;

                //Goods Group List
                goodsGroupList _goodsGroupList = WincashWSAdapterUtilities.BuildGoodsGroupList(dbRecords);

                //Material Group List
                materialGroupList _materialGroupList = WincashWSAdapterUtilities.BuildMaterialGroupList(dbRecords);

                LogManager.LogMessage(string.Format("Data to be pushed to Wincash Material Web Service:{0}\tMaterials: {1}{0}\tGoods Group:{2}{0}\tMaterial Group:{3}",
                    Environment.NewLine,
                    (request.interfaceData.materials.material != null ?
                    request.interfaceData.materials.material.Length.SafeToString() : "0"),
                    _goodsGroupList != null ? _goodsGroupList.goodsGroup.Length.SafeToString() : "0",
                    _materialGroupList != null ? _materialGroupList.materialGroup.Length.SafeToString() : "0"
                ));

                #endregion

                if (request.interfaceData.materials.material != null && request.interfaceData.materials.material.Length > 0)
                {
                    using (MaterialImportServiceV16 client = new MaterialImportServiceV16(pApplicationWebServiceRequest.ApplicationWebService.ApplicationWebServiceURL))
                    {
                        #region Import Goods Groups
                        {
                            try
                            {
                                if (_goodsGroupList != null && _goodsGroupList.goodsGroup != null && _goodsGroupList.goodsGroup.Length > 0)
                                {
                                    string _goodsGroupTobeImported = string.Format("List of Goods Groups to be imported:{0}", Environment.NewLine);

                                    foreach (goodsGroup _goodsGroup in _goodsGroupList.goodsGroup)
                                    {
                                        _goodsGroupTobeImported += string.Format("\t{1}{0}", Environment.NewLine, _goodsGroup.goodsGroupName);
                                    }

                                    LogManager.LogMessage(_goodsGroupTobeImported);

                                    goodsGroupRequestData goodsGroupRequestData = new goodsGroupRequestData()
                                    {
                                        goodsGroups = _goodsGroupList,
                                        requestHeader = _requestHeader
                                    };

                                    genericImportResponse goodsGroupResponse = client.importGoodsGroups(goodsGroupRequestData);

                                    string _goodsGroupLogMessage = string.Format("Wincash Import Goods Groups Response{0}{0}Result: {1}{0}Return Code: {2}{0}Interface Specific Response: {3}{0}",
                                        Environment.NewLine,
                                        goodsGroupResponse.result,
                                        goodsGroupResponse.returnCode,
                                        goodsGroupResponse.interfaceSpecificResponse);

                                    LogManager.LogMessage(_goodsGroupLogMessage,
                                        goodsGroupResponse.returnCode.SafeIntegerParse() == 0 ?
                                            OperationStatus.Succeeded : OperationStatus.Failed);
                                }
                                else
                                {
                                    LogManager.LogMessage("Wincash Import Goods Groups > No Goods Group to be imported");
                                }
                            }
                            catch (Exception ex)
                            {
                                LogManager.LogException(ex, "Wincash Import Goods Groups Response");
                            }
                        }
                        #endregion

                        #region Import Material Groups
                        {
                            try
                            {
                                if (_materialGroupList != null && _materialGroupList.materialGroup != null && _materialGroupList.materialGroup.Length > 0)
                                {
                                    string _materialGroupTobeImported = string.Format("List of Material Groups to be imported:", Environment.NewLine);

                                    foreach (materialGroup _materialGroup in _materialGroupList.materialGroup)
                                    {
                                        _materialGroupTobeImported += string.Format("{0}\t{1}", Environment.NewLine, _materialGroup.materialGroupName);
                                    }

                                    LogManager.LogMessage(_materialGroupTobeImported);

                                    materialGroupRequestData materialGroupRequestData = new materialGroupRequestData()
                                    {
                                        materialGroups = _materialGroupList,
                                        requestHeader = _requestHeader
                                    };

                                    materialGroupRequestData.requestHeader.uniqueID = WincashWSAdapterUtilities.BuildUniqueID();

                                    genericImportResponse materialGroupResponse = client.importMaterialGroups(materialGroupRequestData);

                                    string _materialGroupLogMessage = string.Format("Wincash Import Material Groups Response{0}{0}Result: {1}{0}Return Code: {2}{0}Interface Specific Response: {3}{0}",
                                        Environment.NewLine,
                                        materialGroupResponse.result,
                                        materialGroupResponse.returnCode,
                                        materialGroupResponse.interfaceSpecificResponse);

                                    LogManager.LogMessage(_materialGroupLogMessage,
                                        materialGroupResponse.returnCode.SafeIntegerParse() == 0 ?
                                            OperationStatus.Succeeded : OperationStatus.Failed);
                                }
                                else
                                {
                                    LogManager.LogMessage("Wincash Import Material Groups > No Material Groups to be imported");
                                }
                            }
                            catch (Exception ex)
                            {
                                LogManager.LogException(ex, "Wincash Import Material Groups Response");
                            }
                        }
                        #endregion

                        #region Import Material Data

                        genericImportResponse materialImportResponse = null;

                        try
                        {
                            request.requestHeader.uniqueID = WincashWSAdapterUtilities.BuildUniqueID();
                            materialImportResponse = client.importFullMaterialData(request);
                        }
                        catch (Exception ex)
                        {
                            LogManager.LogException(ex);
                        }

                        try
                        {
                            if (materialImportResponse != null)
                            {
                                #region Logging

                                string _logMessage = string.Format("Wincash Import Material Data Response{0}\tResult: {1}{0}\tReturn Code: {2}{0}\tInterface Specific Response: {3}{0}",
                                    Environment.NewLine,
                                    materialImportResponse.result,
                                    materialImportResponse.returnCode,
                                    materialImportResponse.interfaceSpecificResponse.IsValidString() ? materialImportResponse.interfaceSpecificResponse : "Nothing");

                                if (materialImportResponse.responseParameters != null && materialImportResponse.responseParameters.Length > 0)
                                {
                                    _logMessage += string.Format("{0}Response Parameters:{0}", Environment.NewLine);

                                    foreach (var resParam in materialImportResponse.responseParameters)
                                    {
                                        _logMessage += string.Format("\tKey: {1}\t\t Value: {2}{0}",
                                            Environment.NewLine, resParam.key, resParam.value);
                                    }
                                }

                                _logMessage += string.Format("{0}Processed Jobs:{0}", Environment.NewLine);

                                foreach (processedJob _job in materialImportResponse.jobs)
                                {
                                    foreach (failedRecord _failedRecord in _job.failedRecords.Where(c => c.keyValues.Length > 0))
                                    {
                                        string failedMaterialNumber = string.Format("{0}\tFailed Keys:{0}", Environment.NewLine);

                                        foreach (keyValue failedKeyValue in _failedRecord.keyValues)
                                        {
                                            failedMaterialNumber += string.Format("\t\tKey Name: {1}\t\tKey Value: {2}{0}", Environment.NewLine,
                                                failedKeyValue.keyName, failedKeyValue.Value);
                                        }

                                        _logMessage += string.Format("\t\tFailed Material Number: {1}{0}\t\tError Code: {2}{0}\t\tError Message: {3}{0}{0}", Environment.NewLine,
                                            failedMaterialNumber, _failedRecord.errorCode, _failedRecord.errorMessage);
                                    }

                                    _logMessage += string.Format("\tCommitted Records: {1}{0}\tFailed Records: {2}{0}\tSkipped Records: {3}{0}\tTotal Records: {4}{0}", Environment.NewLine,
                                        _job.committedRecords != null ? _job.committedRecords.Length.SafeToString("0") : "Null",
                                        _job.failedRecords != null ? _job.failedRecords.Length.SafeToString("0") : "Null",
                                        _job.skippedRecords != null ? _job.skippedRecords.Length.SafeToString("0") : "Null",
                                        _job.totalRecords);
                                }

                                LogManager.LogMessage(_logMessage);

                                #endregion

                                #region Response Discovery

                                response.BooleanResult = materialImportResponse.returnCode.SafeIntegerParse() == 0;
                                response.Status = response.BooleanResult ? OperationStatus.Succeeded : OperationStatus.Failed;

                                IList<string> _failedMaterialList = WincashWSAdapterUtilities.BuildFailedMaterialList(materialImportResponse);

                                foreach (AdapterCacheResult cacheResult in pPushToDestinationRequest.AdapterCacheResults)
                                {
                                    try
                                    {
                                        string _materialNumber = cacheResult.DBRecord.GetFieldValue<String>(QueryFields.materialNumber);

                                        if (_materialNumber.IsValidString())
                                        {
                                            if (!_failedMaterialList.Contains(_materialNumber))
                                            {
                                                cacheResult.DBRecord.RecordTransactionStatus = RecordTransactionStatus.Succeeded;
                                                cacheResult.DBRecordCache.CacheStatus = RecordCacheStatus.Succeeded.GetValue<Byte>();
                                            }
                                            else
                                            {
                                                cacheResult.DBRecord.RecordTransactionStatus = RecordTransactionStatus.Failed;
                                                cacheResult.DBRecordCache.CacheStatus = RecordCacheStatus.Failed.GetValue<Byte>();
                                            }

                                            base.AppRuntime.DataService.ApplyEntityChanges(cacheResult.DBRecordCache);
                                            response.Results.Add(cacheResult.DBRecord);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogManager.LogException(ex, string.Format("Cache Primary Keys : {0}",
                                            cacheResult.DBRecordCache.CachePrimaryKeys));
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                #region No Response

                                LogManager.LogMessage(string.Format("The web service method [importFullMaterialData] has returned no response"),
                                    OperationStatus.Failed);

                                response.BooleanResult = false;
                                response.Status = OperationStatus.Failed;

                                foreach (AdapterCacheResult cacheResult in pPushToDestinationRequest.AdapterCacheResults)
                                {
                                    cacheResult.DBRecord.RecordTransactionStatus = RecordTransactionStatus.Failed;
                                    cacheResult.DBRecordCache.CacheStatus = RecordCacheStatus.Failed.GetValue<Byte>();
                                    base.AppRuntime.DataService.ApplyEntityChanges(cacheResult.DBRecordCache);
                                    response.Results.Add(cacheResult.DBRecord);
                                }

                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {
                            LogManager.LogException(ex);
                        }

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
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