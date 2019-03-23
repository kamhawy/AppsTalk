#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    /// Abstract Adapter Response
    /// </summary>
    [Serializable]
    public abstract class AbstractAdapterResponse : ResponseBase
    {
        #region Members

        private IntegrationAdapter _AdapterMetadata = null;
        private IList<DBRecordInfo> _Results = null;
        private bool _BooleanResult = true;
        private List<string> _QueryPrimaryKeys = null;

        #endregion

        #region Properties

        public IntegrationAdapter AdapterMetadata
        {
            get
            {
                return this._AdapterMetadata;
            }
            set
            {
                this._AdapterMetadata = value;
            }
        }

        public IList<DBRecordInfo> Results
        {
            get
            {
                if (this._Results == null)
                {
                    this._Results = new List<DBRecordInfo>();
                }

                return this._Results;
            }
            set
            {
                this._Results = value;
            }
        }

        public bool BooleanResult
        {
            get
            {
                return this._BooleanResult;
            }
            set
            {
                this._BooleanResult = value;
            }
        }

        public List<string> AdapterPrimaryKeys
        {
            get
            {
                if (this._QueryPrimaryKeys == null)
                {
                    if (this.AdapterMetadata != null)
                    {
                        this._QueryPrimaryKeys = this.AdapterMetadata.IntegrationAdapterFields
                            .Where(c => c.IsPrimaryKey)
                            .OrderBy(c => c.PrimaryKeySequence)
                            .Select(c => c.FieldName).ToList();
                    }
                    else
                    {
                        this._QueryPrimaryKeys = new List<string>();
                    }
                }

                return this._QueryPrimaryKeys;
            }
            set
            {
                this._QueryPrimaryKeys = value;
            }
        }

        #endregion

        #region Constructors

        public AbstractAdapterResponse()
        {

        }

        public AbstractAdapterResponse(IntegrationAdapter pAdapterMetadata)
            : this()
        {
            this.AdapterMetadata = pAdapterMetadata;
        }

        #endregion
    }
}