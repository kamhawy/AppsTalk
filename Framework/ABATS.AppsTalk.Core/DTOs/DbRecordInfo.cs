using System;
using System.Data;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    ///     Db Record Info
    /// </summary>
    [Serializable]
    public partial class DBRecordInfo : DisposableBase
    {
        #region Members

        private string _DbRecordID = string.Empty;
        private string _DbRecordKey = string.Empty;
        private DataRow _Row = null;
        private RecordTransactionStatus _RecordTransactionStatus = RecordTransactionStatus.None;
        private string _ExceptionExtraMessage = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public string DbRecordID
        {
            get
            {
                if (!this._DbRecordID.IsValidString())
                {
                    this._DbRecordID = Guid.NewGuid().ToString();
                }

                return this._DbRecordID;
            }
            set
            {
                this._DbRecordID = value;
            }
        }

        [DataMember]
        public string DbRecordKey
        {
            get
            {
                return this._DbRecordKey;
            }
            set
            {
                this._DbRecordKey = value;
            }
        }

        [DataMember]
        public DataRow Row
        {
            get
            {
                return this._Row;
            }
            set
            {
                this._Row = value;
            }
        }

        [DataMember]
        public RecordTransactionStatus RecordTransactionStatus
        {
            get
            {
                return this._RecordTransactionStatus;
            }
            set
            {
                this._RecordTransactionStatus = value;
            }
        }

        [DataMember]
        public string ExceptionExtraMessage
        {
            get
            {
                return this._ExceptionExtraMessage;
            }
            set
            {
                this._ExceptionExtraMessage = value;
            }
        }

        #endregion

        #region Constructors

        public DBRecordInfo()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Field Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pColumnName"></param>
        /// <returns></returns>
        public T GetFieldValue<T>(string pColumnName)
        {
            T columnValue = default(T);

            try
            {
                if (pColumnName.IsValidString() && this.Row != null)
                {
                    columnValue = this.Row.Field<T>(pColumnName);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex, string.Format("Column Name : {0}", pColumnName));
            }

            return columnValue;
        }

        #endregion
    }
}