using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    ///     Oracle Provider
    /// </summary>
    public class OracleProvider : AbstractDBProvider
    {
        #region Constructor

        public OracleProvider(IntegrationAdapter pAdapterMetadata, ApplicationDatabas pApplicationDatabaseMetadata, IAppRuntime pAppRuntime)
            : base(pAdapterMetadata, pApplicationDatabaseMetadata, pAppRuntime)
        {

        }

        #endregion

        #region DBProvider

        /// <summary>
        /// Run Select Query
        /// </summary>
        /// <param name="pApplicationDatabaseQuery"></param>
        /// <returns></returns>
        public override IList<DBRecordInfo> RunSelectQuery(ApplicationDatabaseQuery pApplicationDatabaseQuery)
        {
            IList<DBRecordInfo> results = null;
            DataSet dataSet = null;

            try
            {
                using (OracleConnection connection = new OracleConnection(
                        pApplicationDatabaseQuery.ApplicationDatabas.ProviderConnectionString))
                {
                    using (OracleCommand command = new OracleCommand
                    {
                        Connection = connection,
                        CommandText = pApplicationDatabaseQuery.ApplicationDatabaseQueryCommand,
                        CommandType = CommandType.Text
                    })
                    {
                        connection.Open();

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                            {
                                results = (from DataRow row in dataSet.Tables[0].Rows
                                           select new DBRecordInfo { Row = row }).ToList();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataSet = null;
            }

            return results;
        }

        /// <summary>
        /// Run Insert Query
        /// </summary>
        /// <param name="pApplicationDatabaseQuery"></param>
        /// <param name="pAdapterFields"></param>
        /// <param name="pDBRecord"></param>
        /// <returns></returns>
        public override RecordTransactionStatus RunInsertQuery(ApplicationDatabaseQuery pApplicationDatabaseQuery, ICollection<IntegrationAdapterField> pAdapterFields, DBRecordInfo pDBRecord)
        {
            RecordTransactionStatus recordTransactionStatus = RecordTransactionStatus.None;
            string lastParamName = string.Empty;

            try
            {
                using (OracleConnection connection = new OracleConnection(
                        pApplicationDatabaseQuery.ApplicationDatabas.ProviderConnectionString))
                {
                    using (OracleCommand command = new OracleCommand
                    {
                        Connection = connection,
                        CommandText = pApplicationDatabaseQuery.ApplicationDatabaseQueryCommand,
                        CommandType = CommandType.Text,
                        BindByName = true
                    })
                    {
                        foreach (IntegrationAdapterField field in pAdapterFields)
                        {
                            lastParamName = field.FieldName;
                            object paramValue = DataUtilities.GetFieldParameterValue(field, pDBRecord.Row, ApplicationDatabaseType.Oracle);

                            OracleParameter param = command.CreateParameter();
                            param.ParameterName = field.FieldName;
                            param.OracleDbType = field.FieldOracleDbType;
                            param.Value = paramValue;

                            command.Parameters.Add(param);
                        }

                        connection.Open();

                        if (command.ExecuteNonQuery() > 0)
                        {
                            recordTransactionStatus = RecordTransactionStatus.Succeeded;
                        }
                        else
                        {
                            recordTransactionStatus = RecordTransactionStatus.Failed;
                        }
                    }
                }
            }
            catch (OracleException dbException)
            {
                pDBRecord.ExceptionExtraMessage = lastParamName;

                if (dbException.Number == 2601) // Cannot insert duplicate keys //Or check ORA-00001: unique constraint (.) violated
                {
                    recordTransactionStatus = RecordTransactionStatus.Duplicated;
                    LogManager.LogException(dbException);
                }
                else
                {
                    recordTransactionStatus = RecordTransactionStatus.Failed;
                    throw dbException;
                }
            }
            catch (Exception ex)
            {
                pDBRecord.ExceptionExtraMessage = lastParamName;

                recordTransactionStatus = RecordTransactionStatus.Failed;
                throw ex;
            }
            finally
            {

            }

            return recordTransactionStatus;
        }

        #endregion

        #region Factory

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="pApplicationDatabaseMetadata"></param>
        /// <param name="pAppRuntime"></param>
        /// <returns></returns>
        internal static OracleProvider Create(IntegrationAdapter pAdapterMetadata, ApplicationDatabas pApplicationDatabaseMetadata, IAppRuntime pAppRuntime)
        {
            return new OracleProvider(pAdapterMetadata, pApplicationDatabaseMetadata, pAppRuntime);
        }

        #endregion
    }
}