#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core.Managers
{
    /// <summary>
    ///      Adapter Cache Manager
    /// </summary>
    internal class AdapterCacheManager : AppRuntimeComponent
    {
        #region Members

        /// <summary>
        /// Lock Object
        /// </summary>
        private static readonly object _lockObj = new object();

        #endregion

        #region Constructor

        internal AdapterCacheManager(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        ///     Build Adapter Cache Results
        /// </summary>
        /// <param name="pSourceAdapterResponse"></param>
        /// <returns>Integration Adapter Cache Result</returns>
        internal List<AdapterCacheResult> BuildAdapterCacheResults(SourceAdapterResponse pSourceAdapterResponse)
        {
            List<AdapterCacheResult> queryCacheResults = null;
            List<IntegrationAdapterCach> tempCache = null;
            List<string> sourceResultsKeys = null;
            bool needSaveChanges = false;

            try
            {
                Parallel.ForEach(pSourceAdapterResponse.Results, recordInfo =>
                {
                    recordInfo.DbRecordKey = this.BuildRecordCompositeKey(pSourceAdapterResponse.AdapterPrimaryKeys, recordInfo);
                });

                sourceResultsKeys = pSourceAdapterResponse.Results
                    .Select(c => c.DbRecordKey)
                    .Where(c => c.IsValidString()).ToList();

                if (sourceResultsKeys != null && sourceResultsKeys.Count > 0)
                {
                    tempCache = base.AppRuntime.DataService.GetAll(GetDataRequest<IntegrationAdapterCach>.Create(c =>
                        c.IntegrationAdapterID == pSourceAdapterResponse.AdapterMetadata.IntegrationAdapterID &&
                        sourceResultsKeys.Contains(c.CachePrimaryKeys))).ToList();

                    if (tempCache != null)
                    {
                        queryCacheResults = new List<AdapterCacheResult>();

                        foreach (DBRecordInfo recordInfo in pSourceAdapterResponse.Results.Where(c =>
                            c.DbRecordKey.IsValidString()))
                        {
                            IntegrationAdapterCach cacheItem = tempCache.FirstOrDefault(c =>
                                c.CachePrimaryKeys == recordInfo.DbRecordKey);

                            if (cacheItem != null)
                            {
                                if (cacheItem.CacheStatus == RecordCacheStatus.InQueue.GetValue<Byte>() ||
                                    cacheItem.CacheStatus == RecordCacheStatus.Failed.GetValue<Byte>())
                                {
                                    cacheItem.CacheStatus = RecordCacheStatus.InQueue.GetValue<Byte>();
                                    base.AppRuntime.DataService.ApplyEntityChanges(cacheItem);
                                    needSaveChanges = true;

                                    queryCacheResults.Add(new AdapterCacheResult()
                                    {
                                        DBRecordCache = cacheItem,
                                        DBRecord = recordInfo
                                    });
                                }
                                else if (cacheItem.CacheStatus == RecordCacheStatus.Succeeded.GetValue<Byte>())
                                {
                                    //Record Ignored: because the record has been moved successfully in earlier transaction
                                }
                            }
                            else
                            {
                                cacheItem = new IntegrationAdapterCach()
                                {
                                    IntegrationAdapterID = pSourceAdapterResponse.AdapterMetadata.IntegrationAdapterID,
                                    CachePrimaryKeys = recordInfo.DbRecordKey,
                                    CacheStatus = RecordCacheStatus.InQueue.GetValue<Byte>(),
                                    Description = string.Format("{0}-{1}",
                                       pSourceAdapterResponse.AdapterMetadata.IntegrationAdapterID,
                                       recordInfo.DbRecordKey),
                                    RecordStatus = (int)RecordAuditStatus.Active,
                                    RecordCreated = DateTime.Now,
                                    RecordCreatedBy = Constants.SystemUser,
                                    RecordLastUpdate = DateTime.Now,
                                    RecordLastUpdateBy = Constants.SystemUser,
                                };

                                base.AppRuntime.DataService.AddEntity(cacheItem);
                                needSaveChanges = true;

                                queryCacheResults.Add(new AdapterCacheResult()
                                {
                                    DBRecordCache = cacheItem,
                                    DBRecord = recordInfo
                                });
                            }
                        }

                        if (needSaveChanges)
                        {
                            base.AppRuntime.DataService.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
            finally
            {
                tempCache = null;
                sourceResultsKeys = null;
            }

            return queryCacheResults;
        }

        /// <summary>
        /// Build Record Composite Key
        /// </summary>
        /// <param name="pQueryPrimaryKeys"></param>
        /// <param name="pRecordInfo"></param>
        /// <returns></returns>
        private string BuildRecordCompositeKey(List<string> pQueryPrimaryKeys, DBRecordInfo pRecordInfo)
        {
            string recordCompositeKey = string.Empty;

            try
            {
                foreach (string primaryKey in pQueryPrimaryKeys)
                {
                    if (pRecordInfo.Row.Table.Columns.Contains(primaryKey))
                    {
                        string tempKeyValue = pRecordInfo.Row[primaryKey].SafeToString();

                        if (tempKeyValue.IsValidString())
                        {
                            if (recordCompositeKey.IsValidString())
                            {
                                recordCompositeKey += ",";
                            }

                            recordCompositeKey += tempKeyValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return recordCompositeKey;
        }

        #endregion
    }
}