#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;
using ABATS.AppsTalk.Runtime.Services.Core.Providers;
using System;
using System.Linq;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core.Adapters
{
    /// <summary>
    /// Database Adapter
    /// </summary>
    internal class DBAdapter : AbstractAdapter
    {
        #region Members


        #endregion

        #region Properties



        #endregion

        #region Constructor

        internal DBAdapter(IntegrationProcess pProcessMetadata, IntegrationAdapter pAdapterMetadata, IAppRuntime pIAppRuntime)
            : base(pProcessMetadata, pAdapterMetadata, pIAppRuntime)
        {

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Consume Source
        /// </summary>
        /// <returns></returns>
        internal override SourceAdapterResponse ConsumeSource()
        {
            DBSourceAdapterResponse response = null;

            try
            {
                if (base.ValidateAdapter(IntegrationChannelType.Source))
                {
                    using (AbstractDBProvider sourceDBProvider =
                        DBProviderFactory.CreateDBProvider(
                        this.AdapterMetadata,
                        this.AdapterMetadata.ApplicationDatabaseQuery.ApplicationDatabas, 
                        base.AppRuntime))
                    {
                        response = new DBSourceAdapterResponse(this.AdapterMetadata, this.AdapterMetadata.ApplicationDatabaseQuery);
                        response.Results = sourceDBProvider.RunSelectQuery(this.AdapterMetadata.ApplicationDatabaseQuery);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);

                if (response != null)
                {
                    response.Status = OperationStatus.Failed;
                }
            }

            return response;
        }

        /// <summary>
        /// Publish To Destination
        /// </summary>
        /// <param name="pPushToDestinationRequest"></param>
        /// <returns>Destination Adapter Response</returns>
        internal override DestinationAdapterResponse PublishToDestination(PushToDestinationRequest pPushToDestinationRequest)
        {
            DBDestinationAdapterResponse response = null;

            try
            {
                if (base.ValidateAdapter(IntegrationChannelType.Destination) && pPushToDestinationRequest != null)
                {
                    using (AbstractDBProvider destinationDBProvider = DBProviderFactory.CreateDBProvider(
                        this.AdapterMetadata,
                        this.AdapterMetadata.ApplicationDatabaseQuery.ApplicationDatabas, 
                        base.AppRuntime))
                    {
                        response = new DBDestinationAdapterResponse(this.AdapterMetadata, this.AdapterMetadata.ApplicationDatabaseQuery);

                        foreach (AdapterCacheResult cacheResult in pPushToDestinationRequest.AdapterCacheResults)
                        {
                            try
                            {
                                cacheResult.DBRecord.RecordTransactionStatus = destinationDBProvider.RunInsertQuery(
                                    this.AdapterMetadata.ApplicationDatabaseQuery,
                                    this.AdapterMetadata.IntegrationAdapterFields,
                                    cacheResult.DBRecord);

                                if (cacheResult.DBRecord.RecordTransactionStatus == RecordTransactionStatus.Succeeded ||
                                    cacheResult.DBRecord.RecordTransactionStatus == RecordTransactionStatus.Duplicated)
                                {
                                    cacheResult.DBRecordCache.CacheStatus = RecordCacheStatus.Succeeded.GetValue<Byte>();
                                }
                                else
                                {
                                    if (cacheResult.DBRecord.RecordTransactionStatus == RecordTransactionStatus.Failed ||
                                        cacheResult.DBRecord.RecordTransactionStatus == RecordTransactionStatus.None)
                                    {
                                        cacheResult.DBRecordCache.CacheStatus = RecordCacheStatus.Failed.GetValue<Byte>();
                                    }
                                }

                                base.AppRuntime.DataService.ApplyEntityChanges(cacheResult.DBRecordCache);
                                response.Results.Add(cacheResult.DBRecord);
                            }
                            catch (Exception ex)
                            {
                                string extraMessage = string.Format("Record Keys: {0} - Parameter: {1}",
                                    cacheResult.DBRecord != null ? cacheResult.DBRecord.DbRecordKey : "NO KEYS",
                                    cacheResult.DBRecord != null ? cacheResult.DBRecord.ExceptionExtraMessage : string.Empty);

                                LogManager.LogException(ex, extraMessage);
                            }
                        }

                        response.Status = response.Results.Where(c =>
                            c.RecordTransactionStatus == RecordTransactionStatus.None ||
                            c.RecordTransactionStatus == RecordTransactionStatus.Failed).Count() > 0 ?
                                OperationStatus.Failed : OperationStatus.Succeeded;

                        //Save the updated query cache
                        if (pPushToDestinationRequest.AdapterCacheResults.Count > 0)
                        {
                            base.AppRuntime.DataService.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);

                if (response != null)
                {
                    response.Status = OperationStatus.Failed;
                }
            }
            finally
            {

            }

            return response;
        }

        #endregion

        #region Factory

        internal static DBAdapter Create(IntegrationProcess pProcessMetadata, IntegrationAdapter pAdapterMetadata, IAppRuntime pIAppRuntime)
        {
            return new DBAdapter(pProcessMetadata, pAdapterMetadata, pIAppRuntime);
        }

        #endregion
    }
}