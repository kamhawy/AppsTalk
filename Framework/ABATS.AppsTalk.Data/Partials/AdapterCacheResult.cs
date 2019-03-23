using ABATS.AppsTalk.Core;
using System;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    public partial class AdapterCacheResult : DisposableBase
    {
        #region Members

        private IntegrationAdapterCach _DBRecordCache = null;
        private DBRecordInfo _DBRecord = null;

        #endregion

        #region Properties

        public IntegrationAdapterCach DBRecordCache
        {
            get
            {
                return this._DBRecordCache;
            }
            set
            {
                this._DBRecordCache = value;
            }
        }

        public DBRecordInfo DBRecord
        {
            get
            {
                return this._DBRecord;
            }
            set
            {
                this._DBRecord = value;
            }
        }

        #endregion

        #region Constructor

        public AdapterCacheResult()
        {

        }

        #endregion
    }
}