#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;


#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core.Managers
{
    /// <summary>
    ///     Query Mapping Manager
    /// </summary>
    internal class ProcessMappingManager : AppRuntimeComponent
    {
        #region Constructor

        internal ProcessMappingManager(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        ///     Build Destination Record
        /// </summary>
        /// <param name="pDestinationTable"></param>
        /// <param name="pSourceRecord"></param>
        /// <param name="pMapping"></param>
        /// <returns></returns>
        public DBRecordInfo BuildDestinationRecord(DataTable pDestinationTable, DBRecordInfo pSourceRecord, List<FieldMappingInfo> pMapping)
        {
            DBRecordInfo destinationRecord = null;

            try
            {
                destinationRecord = new DBRecordInfo
                {
                    DbRecordID = pSourceRecord.DbRecordID,
                    DbRecordKey = pSourceRecord.DbRecordKey,
                    Row = pDestinationTable.NewRow(),
                };

                foreach (FieldMappingInfo fieldMapping in pMapping)
                {
                    destinationRecord.Row[fieldMapping.DestinationField.FieldName] =
                        this.GetMappedFieldResult(pSourceRecord, fieldMapping);
                }
            }
            catch { throw; }

            return destinationRecord;
        }

        /// <summary>
        ///     Get Mapped Field Result
        /// </summary>
        /// <param name="pSourceRecord"></param>
        /// <param name="pMappingInfo"></param>
        /// <returns></returns>
        public object GetMappedFieldResult(DBRecordInfo pSourceRecord, FieldMappingInfo pMappingInfo)
        {
            object result = null;

            try
            {
                DataTypes sourceDataType = (DataTypes)pMappingInfo.SourceField.FieldDataType;
                DataTypes destinationDataType = (DataTypes)pMappingInfo.DestinationField.FieldDataType;

                if (pSourceRecord.Row != null)
                {
                    if (pSourceRecord.Row.Table.Columns.Contains(pMappingInfo.SourceField.FieldName))
                    {
                        result = pSourceRecord.Row[pMappingInfo.SourceField.FieldName];

                        if (result != null && sourceDataType != destinationDataType)
                        {
                            #region Data Type Conversion

                            try
                            {
                                switch (destinationDataType)
                                {
                                    case DataTypes.String:
                                        {
                                            result = result.ToString();
                                        }
                                        break;
                                    case DataTypes.Boolean:
                                        {
                                            result = Convert.ToBoolean(result);
                                        }
                                        break;
                                    case DataTypes.DateTime:
                                        {
                                            result = Convert.ToDateTime(result);
                                        }
                                        break;
                                    case DataTypes.Integer:
                                        {
                                            result = Convert.ToInt32(result);
                                        }
                                        break;
                                    case DataTypes.Enum:
                                        {
                                            //Not Implemented
                                        }
                                        break;
                                    case DataTypes.Double:
                                        {
                                            result = Convert.ToDouble(result);
                                        }
                                        break;
                                    case DataTypes.Decimal:
                                        {
                                            result = Convert.ToDecimal(result);
                                        }
                                        break;
                                    case DataTypes.None:
                                    default:
                                        { }
                                        break;
                                }
                            }
                            catch
                            {
                                // Sallow the Data Conversion Exception 
                            }

                            #endregion
                        }
                    }
                }
            }
            catch { throw; }

            return result;
        }

        #endregion
    }

    /// <summary>
    ///     Field Mapping Info
    /// </summary>
    [Serializable]
    public class FieldMappingInfo : DTOBase
    {
        #region Members

        private IntegrationAdapterField _SourceField = null;
        private IntegrationAdapterField _DestinationField = null;
        private IntegrationProcessMapping _MappingDetail = null;

        #endregion

        #region Properties

        [DataMember]
        public IntegrationAdapterField SourceField
        {
            get
            {
                return this._SourceField;
            }
            set
            {
                this._SourceField = value;
            }
        }

        [DataMember]
        public IntegrationAdapterField DestinationField
        {
            get
            {
                return this._DestinationField;
            }
            set
            {
                this._DestinationField = value;
            }
        }

        [DataMember]
        public IntegrationProcessMapping MappingDetail
        {
            get
            {
                return this._MappingDetail;
            }
            set
            {
                this._MappingDetail = value;
            }
        }

        #endregion
    }
}