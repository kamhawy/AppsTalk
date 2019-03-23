using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    ///     SQL Provider
    /// </summary>
    public class SQLProvider : AbstractDBProvider
    {
        #region Constructor

        internal SQLProvider(IntegrationAdapter pAdapterMetadata, ApplicationDatabas pApplicationDatabaseMetadata, IAppRuntime pAppRuntime)
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
                using (SqlConnection connection = new SqlConnection(
                        pApplicationDatabaseQuery.ApplicationDatabas.ProviderConnectionString))
                {
                    using (SqlCommand command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = pApplicationDatabaseQuery.ApplicationDatabaseQueryCommand,
                        CommandType = CommandType.Text
                    })
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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
        public override RecordTransactionStatus RunInsertQuery(ApplicationDatabaseQuery pApplicationDatabaseQuery, ICollection<IntegrationAdapterField> pAdapterFields, DBRecordInfo pDBRecord)
        {
            RecordTransactionStatus recordTransactionStatus = RecordTransactionStatus.None;
            string lastParamName = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(
                        pApplicationDatabaseQuery.ApplicationDatabas.ProviderConnectionString))
                {
                    using (SqlCommand command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = pApplicationDatabaseQuery.ApplicationDatabaseQueryCommand,
                        CommandType = CommandType.Text
                    })
                    {
                        foreach (IntegrationAdapterField field in pAdapterFields)
                        {
                            lastParamName = field.FieldName;
                            object paramValue = DataUtilities.GetFieldParameterValue(field, pDBRecord.Row, ApplicationDatabaseType.SQLServer);

                            SqlParameter param = command.CreateParameter();
                            param.ParameterName = field.FieldName;
                            param.Direction = ParameterDirection.Input;
                            param.SqlDbType = field.FieldSqlDbType;
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
            catch (SqlException dbException)
            {
                pDBRecord.ExceptionExtraMessage = lastParamName;

                if (dbException.Number == 2601) // Cannot insert duplicate keys
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
        internal static SQLProvider Create(IntegrationAdapter pAdapterMetadata, ApplicationDatabas pApplicationDatabaseMetadata, IAppRuntime pAppRuntime)
        {
            return new SQLProvider(pAdapterMetadata, pApplicationDatabaseMetadata, pAppRuntime);
        }

        #endregion
    }
}