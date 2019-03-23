using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Responses;
using System;
using System.Collections.ObjectModel;

namespace ABATS.AppsTalk.Runtime.Services.Core.Managers
{
    /// <summary>
    /// Transaction Log Manager
    /// </summary>
    internal class TransactionLogManager : AppRuntimeComponent
    {
        #region Constructor

        internal TransactionLogManager(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        ///     Log Integration Process Transaction
        /// </summary>
        /// <param name="pResponse"></param>
        internal void LogIntegrationProcessTransaction(ProcessExecutionResponse pResponse)
        {
            try
            {
                //5 - Log the Transaction in the 'IntegrationTransactions' table with some usefull information about the output of the integration process.

                if (pResponse.IntegrationProcessMetadata != null && pResponse.DestinationAdapterResponse != null)
                {
                    //Initialize Main Integration Transaction Log
                    IntegrationTransaction transaction = new IntegrationTransaction
                    {
                        IntegrationProcessID = pResponse.IntegrationProcessMetadata.IntegrationProcessID,
                        IntegrationTransactionTitle = string.Format("{0} - {1}",
                            pResponse.IntegrationProcessMetadata.IntegrationProcessTitle,
                            pResponse.Request.RequestDate.ToStandardFormat(true)),
                        IntegrationTransactionDate = DateTime.Now,
                        TransactionStatus = (int)pResponse.Status,
                        Description = pResponse.StatusDescription,
                        RecordStatus = (int)RecordAuditStatus.Active,
                        RecordCreated = DateTime.Now,
                        RecordCreatedBy = Constants.SystemUser,
                        RecordLastUpdate = DateTime.Now,
                        RecordLastUpdateBy = Constants.SystemUser,
                        IntegrationTransactionDetails = new Collection<IntegrationTransactionDetail>()
                    };

                    foreach (DBRecordInfo dbRecordInfo in pResponse.DestinationAdapterResponse.Results)
                    {
                        transaction.IntegrationTransactionDetails.Add(new IntegrationTransactionDetail
                        {
                            IntegrationTransactionDetailStatus = dbRecordInfo.RecordTransactionStatus.GetValue<Byte>(),
                            IntegrationTransactionDetailData = CoreUtilities.ConstructXmlFromRecord(dbRecordInfo),
                            Description = string.Format("{0}-{1}", dbRecordInfo.DbRecordID,
                                dbRecordInfo.RecordTransactionStatus.GetDescription()),
                            RecordStatus = (int)RecordAuditStatus.Active,
                            RecordCreated = DateTime.Now,
                            RecordCreatedBy = Constants.SystemUser,
                            RecordLastUpdate = DateTime.Now,
                            RecordLastUpdateBy = Constants.SystemUser,
                        });
                    }

                    base.AppRuntime.DataService.AddEntity(transaction);
                    base.AppRuntime.DataService.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        #endregion
    }
}