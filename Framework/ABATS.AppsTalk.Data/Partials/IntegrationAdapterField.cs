using ABATS.AppsTalk.Core;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ABATS.AppsTalk.Data
{
    public partial class IntegrationAdapterField
    {
        public DataTypes FieldDataTypeEnum
        {
            get
            {
                return this.FieldDataType.ToEnum<DataTypes>();
            }
        }

        public string FieldDataTypeName
        {
            get
            {
                return this.FieldDataTypeEnum.GetDescription();
            }
        }

        public OracleDbType FieldOracleDbType
        {
            get
            {
                return DataUtilities.GetMappedOracleDbType(this.FieldDataTypeEnum);
            }
        }

        public SqlDbType FieldSqlDbType
        {
            get
            {
                return DataUtilities.GetMappedSqlDbType(this.FieldDataTypeEnum);
            }
        }

        private bool _IsRowVisible = true;

        public bool IsRowVisible
        {
            get { return _IsRowVisible; }
            set { _IsRowVisible = value; }
        }
    }
}