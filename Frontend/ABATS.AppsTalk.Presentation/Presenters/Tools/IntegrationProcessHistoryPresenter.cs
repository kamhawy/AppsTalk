using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime;
using ABATS.AppsTalk.UX;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ABATS.AppsTalk.Presentation
{
    /// <summary>
    /// Integration Process History Presenter
    /// </summary>
    [Serializable()]
    public class IntegrationProcessHistoryPresenter : PresenterBase
    {
        #region Constructors

        public IntegrationProcessHistoryPresenter()
            : base()
        {

        }

        public IntegrationProcessHistoryPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All Integration Processes
        /// </summary>
        /// <returns></returns>
        public IList<IntegrationProcess> GetAllIntegrationProcesses()
        {
            IList<IntegrationProcess> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll<IntegrationProcess>().ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Get History
        /// </summary>
        /// <param name="pIntegrationProcessID"></param>
        /// <param name="pStartDate"></param>
        /// <param name="pEndDate"></param>
        /// <returns></returns>
        public IList<IntegrationTransaction> GetHistory(int pIntegrationProcessID, string pStartDate, string pEndDate)
        {
            IList<IntegrationTransaction> list = null;

            try
            {
                DateTime dtStartDate = DateTime.Now.AddDays(-7);
                DateTime dtEndDate = DateTime.Now;

                if (!string.IsNullOrEmpty(pStartDate))
                {
                    DateTime.TryParse(pStartDate, out dtStartDate);
                }

                if (!string.IsNullOrEmpty(pEndDate))
                {
                    DateTime.TryParse(pEndDate, out dtEndDate);
                }

                list = base.AppRuntime.DataService.GetAll(GetDataRequest<IntegrationTransaction>.Create(c =>
                    c.IntegrationProcessID == pIntegrationProcessID &&
                    c.IntegrationTransactionDate >= dtStartDate &&
                    c.IntegrationTransactionDate <= dtEndDate)).ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Get Integration Transaction Details
        /// </summary>
        /// <param name="pIntegrationTransactionID"></param>
        /// <returns></returns>
        public DataTable GetIntegrationTransactionDetails(int pIntegrationTransactionID)
        {
            DataTable dtResults = null;
            IntegrationTransaction transaction = null;

            try
            {
                dtResults = new DataTable(Constants.TableName_Results);

                transaction = base.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationTransaction>.Create(c =>
                    c.IntegrationTransactionID == pIntegrationTransactionID,
                    "IntegrationProcess.IntegrationProcessMappings.SourceIntegrationAdapterField",
                    "IntegrationProcess.IntegrationProcessMappings.DestinationIntegrationAdapterField",
                    "IntegrationTransactionDetails"));

                if (transaction != null)
                {
                    DataColumn col_ID = new DataColumn(Constants.ColumnName_ID, typeof(Int32));
                    dtResults.Columns.Add(col_ID);

                    DataColumn col_RecordStatus = new DataColumn(Constants.ColumnName_RecordStatus, typeof(String));
                    dtResults.Columns.Add(col_RecordStatus);

                    if (transaction.IntegrationProcess != null)
                    {
                        List<string> columns = new List<string>();

                        foreach (IntegrationProcessMapping mappingItem in transaction.IntegrationProcess.IntegrationProcessMappings.Where(c =>
                            c.DestinationIntegrationAdapterField != null))
                        {
                            if (!dtResults.Columns.Contains(mappingItem.DestinationIntegrationAdapterField.FieldName))
                            {
                                DataColumn dcMappingField = new DataColumn(
                                    mappingItem.DestinationIntegrationAdapterField.FieldName,
                                    DataUtilities.GetMappedType(mappingItem.DestinationIntegrationAdapterField.FieldDataTypeEnum));

                                dtResults.Columns.Add(dcMappingField);
                                columns.Add(dcMappingField.ColumnName);
                            }
                        }

                        foreach (IntegrationTransactionDetail detail in transaction.IntegrationTransactionDetails)
                        {
                            try
                            {
                                DataRow drDetail = dtResults.NewRow();
                                drDetail[col_ID] = detail.IntegrationTransactionDetailID;
                                drDetail[col_RecordStatus] = ((RecordTransactionStatus)detail.IntegrationTransactionDetailStatus).GetDescription();

                                StringReader dataReader = new StringReader(
                                    CoreUtilities.GetString(detail.IntegrationTransactionDetailData));

                                XElement xData = XElement.Load(dataReader);

                                foreach (XElement item in xData.Nodes())
                                {
                                    string columnName = CoreUtilities.FormatXMLColumnName(item.Name.LocalName, false);

                                    if (columnName != Constants.ColumnName_RecordStatus &&
                                        drDetail.Table.Columns.Contains(columnName))
                                    {
                                        drDetail[columnName] = DataUtilities.ConvertValueToDataColumnType(
                                                item.Value, drDetail.Table.Columns[columnName].DataType);
                                    }
                                }

                                dtResults.Rows.Add(drDetail);
                            }
                            catch (Exception ex)
                            {
                                LogManager.LogException(ex);
                            }
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
                transaction = null;
            }

            return dtResults;
        }

        #endregion
    }
}