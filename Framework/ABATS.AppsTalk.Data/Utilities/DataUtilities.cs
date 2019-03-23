using ABATS.AppsTalk.Core;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Reflection;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// Data Utilities
    /// </summary>
    public static class DataUtilities
    {
        #region GetDataRequest Builders

        /// <summary>
        /// Build Integration Process GetDataRequest
        /// </summary>
        /// <param name="pProcessCode"></param>
        /// <returns></returns>
        public static GetDataRequest<IntegrationProcess> BuildIntegrationProcessGetDataRequest(string pProcessCode)
        {
            GetDataRequest<IntegrationProcess> getDataRequest = null;

            try
            {
                string[] integrationProcessIncludes =
                {
                    "SourceIntegrationAdapter.IntegrationAdapterFields",
                    "SourceIntegrationAdapter.ApplicationDatabaseQuery.ApplicationDatabas.Application",  
                    "SourceIntegrationAdapter.ApplicationWebServiceRequest.ApplicationWebService.Application",
                    "DestinationIntegrationAdapter.IntegrationAdapterFields",
                    "DestinationIntegrationAdapter.ApplicationDatabaseQuery.ApplicationDatabas.Application",
                    "DestinationIntegrationAdapter.ApplicationWebServiceRequest.ApplicationWebService.Application"
                };

                getDataRequest = GetDataRequest<IntegrationProcess>.Create(c =>
                    c.IntegrationProcessCode == pProcessCode, integrationProcessIncludes);
            }
            catch { throw; }

            return getDataRequest;
        }

        /// <summary>
        /// Build Integration Process Mapping GetDataRequest
        /// </summary>
        /// <param name="pIntegrationProcess"></param>
        /// <returns></returns>
        public static GetDataRequest<IntegrationProcessMapping> BuildIntegrationProcessMappingGetDataRequest(IntegrationProcess pIntegrationProcess)
        {
            return GetDataRequest<IntegrationProcessMapping>.Create(c =>
                c.IntegrationProcessID == pIntegrationProcess.IntegrationProcessID,
                "SourceIntegrationAdapterField",
                "DestinationIntegrationAdapterField");
        }

        #endregion

        #region Data Utilities

        /// <summary>
        /// Update Record Audit Info
        /// </summary>
        /// <param name="pEntity"></param>
        public static void UpdateRecordAuditInfo<T>(T pEntity) where T : DBEntityBase
        {
            if (pEntity != null)
            {
                PropertyInfo propRecordCreated = typeof(T).GetProperty(Constants.PropertyName_RecordCreated);

                if (propRecordCreated != null)
                {
                    object objRecordCreated = propRecordCreated.GetValue(pEntity, null);

                    if (!objRecordCreated.IsValidDateTime())
                    {
                        propRecordCreated.SetValue(pEntity, DateTime.Now, null);
                    }
                }

                PropertyInfo propRecordCreatedBy = typeof(T).GetProperty(Constants.PropertyName_RecordCreatedBy);

                if (propRecordCreatedBy != null)
                {
                    object objRecordCreatedBy = propRecordCreatedBy.GetValue(pEntity, null);

                    if (objRecordCreatedBy == null)
                    {
                        propRecordCreatedBy.SetValue(pEntity, Constants.SystemUser, null);
                    }
                }

                PropertyInfo propLastUpdated = typeof(T).GetProperty(Constants.PropertyName_RecordLastUpdate);

                if (propLastUpdated != null)
                {
                    propLastUpdated.SetValue(pEntity, DateTime.Now, null);
                }

                PropertyInfo propLastUpdatedBy = typeof(T).GetProperty(Constants.PropertyName_RecordLastUpdateBy);

                if (propLastUpdatedBy != null)
                {
                    propLastUpdatedBy.SetValue(pEntity, Constants.SystemUser, null);
                }
            }
        }

        /// <summary>
        /// Get Mapped Type
        /// </summary>
        /// <param name="pDataType"></param>
        /// <returns></returns>
        public static Type GetMappedType(DataTypes pDataType)
        {
            Type retType = typeof(String);

            switch (pDataType)
            {
                case DataTypes.Boolean:
                    {
                        retType = typeof(Boolean);
                    }
                    break;
                case DataTypes.DateTime:
                    {
                        retType = typeof(DateTime);
                    }
                    break;
                case DataTypes.Integer:
                    {
                        retType = typeof(Int32);
                    }
                    break;
                case DataTypes.Double:
                    {
                        retType = typeof(Double);
                    }
                    break;
                case DataTypes.Decimal:
                    {
                        retType = typeof(Decimal);
                    }
                    break;
                default:
                case DataTypes.None:
                case DataTypes.String:
                case DataTypes.Enum:
                    {
                        retType = typeof(String);
                    }
                    break;
            }

            return retType;
        }

        /// <summary>
        /// Get Mapped SqlDbType
        /// </summary>
        /// <param name="pDataType"></param>
        /// <returns></returns>
        public static SqlDbType GetMappedSqlDbType(DataTypes pDataType)
        {
            SqlDbType sqlDbType = SqlDbType.NVarChar;

            switch (pDataType)
            {
                case DataTypes.Boolean:
                    {
                        sqlDbType = SqlDbType.Bit;
                    }
                    break;
                case DataTypes.DateTime:
                    {
                        sqlDbType = SqlDbType.Date;
                    }
                    break;
                case DataTypes.Integer:
                    {
                        sqlDbType = SqlDbType.Int;
                    }
                    break;
                case DataTypes.Double:
                    {
                        sqlDbType = SqlDbType.Float;
                    }
                    break;
                case DataTypes.Decimal:
                    {
                        sqlDbType = SqlDbType.Decimal;
                    }
                    break;
                default:
                case DataTypes.None:
                case DataTypes.String:
                case DataTypes.Enum:
                    {
                        sqlDbType = SqlDbType.NVarChar;
                    }
                    break;
            }

            return sqlDbType;
        }

        /// <summary>
        /// Get Mapped OracleDbType
        /// </summary>
        /// <param name="pDataType"></param>
        /// <returns></returns>
        public static OracleDbType GetMappedOracleDbType(DataTypes pDataType)
        {
            OracleDbType oracleDbType = OracleDbType.NVarchar2;

            switch (pDataType)
            {
                case DataTypes.Boolean:
                    {
                        oracleDbType = OracleDbType.Char;
                    }
                    break;
                case DataTypes.DateTime:
                    {
                        oracleDbType = OracleDbType.Date;
                    }
                    break;
                case DataTypes.Integer:
                    {
                        oracleDbType = OracleDbType.Int32;
                    }
                    break;
                case DataTypes.Double:
                    {
                        oracleDbType = OracleDbType.Double;
                    }
                    break;
                case DataTypes.Decimal:
                    {
                        oracleDbType = OracleDbType.Decimal;
                    }
                    break;
                default:
                case DataTypes.None:
                case DataTypes.String:
                case DataTypes.Enum:
                    {
                        oracleDbType = OracleDbType.NVarchar2;
                    }
                    break;
            }

            return oracleDbType;
        }

        /// <summary>
        /// Get Mapped DataType (SqlDbType)
        /// </summary>
        /// <param name="pSqlDbType"></param>
        /// <returns></returns>
        public static DataTypes GetMappedDataType(SqlDbType pSqlDbType)
        {
            DataTypes dataType = DataTypes.String;

            switch (pSqlDbType)
            {
                case SqlDbType.Char:
                    {
                        dataType = DataTypes.Boolean;
                    }
                    break;
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                    {
                        dataType = DataTypes.DateTime;
                    }
                    break;
                case SqlDbType.Int:
                    {
                        dataType = DataTypes.Integer;
                    }
                    break;
                case SqlDbType.Float:
                    {
                        dataType = DataTypes.Double;
                    }
                    break;
                case SqlDbType.Decimal:
                    {
                        dataType = DataTypes.Decimal;
                    }
                    break;
                default:
                case SqlDbType.NVarChar:
                    {
                        dataType = DataTypes.String;
                    }
                    break;
            }

            return dataType;
        }

        /// <summary>
        /// Get Mapped DataType (OracleDbType)
        /// </summary>
        /// <param name="pOracleDbType"></param>
        /// <returns></returns>
        public static DataTypes GetMappedDataType(OracleDbType pOracleDbType)
        {
            DataTypes dataType = DataTypes.String;

            switch (pOracleDbType)
            {
                case OracleDbType.Char:
                    {
                        dataType = DataTypes.Boolean;
                    }
                    break;
                case OracleDbType.Date:
                    {
                        dataType = DataTypes.DateTime;
                    }
                    break;
                case OracleDbType.Int32:
                    {
                        dataType = DataTypes.Integer;
                    }
                    break;
                case OracleDbType.Double:
                    {
                        dataType = DataTypes.Double;
                    }
                    break;
                case OracleDbType.Decimal:
                    {
                        dataType = DataTypes.Decimal;
                    }
                    break;
                default:
                case OracleDbType.NVarchar2:
                    {
                        dataType = DataTypes.String;
                    }
                    break;
            }

            return dataType;
        }

        /// <summary>
        /// Convert Value To Data Column Type
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pDataColumnType"></param>
        /// <returns></returns>
        public static object ConvertValueToDataColumnType(string pValue, Type pDataColumnType)
        {
            object retValue = DBNull.Value;

            if (pDataColumnType == typeof(Boolean))
            {
                retValue = pValue.SafeBooleanParse();
            }
            else if (pDataColumnType == typeof(DateTime))
            {
                retValue = pValue.SafeDateTimeParse();
            }
            else if (pDataColumnType == typeof(Int32))
            {
                retValue = pValue.SafeIntegerParse();
            }
            else if (pDataColumnType == typeof(Double))
            {
                retValue = pValue.SafeDoubleParse();
            }
            else if (pDataColumnType == typeof(Decimal))
            {
                retValue = pValue.SafeDecimalParse();
            }
            else
            {
                retValue = pValue.SafeToString();
            }

            return retValue;
        }

        /// <summary>
        /// Get Field Parameter Value
        /// </summary>
        /// <param name="pField"></param>
        /// <param name="pRecordDataRow"></param>
        /// <returns></returns>
        public static object GetFieldParameterValue(IntegrationAdapterField pField, DataRow pRecordDataRow, ApplicationDatabaseType pApplicationDatabaseType)
        {
            object parameterValue = null;

            try
            {
                parameterValue = pRecordDataRow[pField.FieldName];

                if (parameterValue == DBNull.Value)
                {
                    parameterValue = null;
                }
                else
                {
                    switch (pApplicationDatabaseType)
                    {
                        case ApplicationDatabaseType.SQLServer:
                            {
                                parameterValue = DataUtilities.ConvertValueToDataColumnType(
                                    parameterValue.SafeToString(),
                                    DataUtilities.GetMappedType(DataUtilities.GetMappedDataType(pField.FieldSqlDbType)));
                            }
                            break;
                        case ApplicationDatabaseType.Oracle:
                            {
                                parameterValue = DataUtilities.ConvertValueToDataColumnType(
                                    parameterValue.SafeToString(),
                                    DataUtilities.GetMappedType(DataUtilities.GetMappedDataType(pField.FieldOracleDbType)));
                            }
                            break;
                        case ApplicationDatabaseType.None:
                        case ApplicationDatabaseType.MySQL:
                        case ApplicationDatabaseType.Sybase:
                        default:
                            {
                                parameterValue = DataUtilities.ConvertValueToDataColumnType(
                                    parameterValue.SafeToString(),
                                    DataUtilities.GetMappedType(DataUtilities.GetMappedDataType(pField.FieldSqlDbType)));
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return parameterValue;
        }

        #endregion
    }
}