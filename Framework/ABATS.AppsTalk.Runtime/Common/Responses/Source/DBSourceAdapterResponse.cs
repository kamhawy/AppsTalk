#region

using ABATS.AppsTalk.Data;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    ///     DB Source Adapter Response
    /// </summary>
    [Serializable]
    public class DBSourceAdapterResponse : SourceAdapterResponse
    {
        #region Members

        private ApplicationDatabaseQuery _ApplicationDatabaseQuery = null;

        #endregion

        #region Properties

        public ApplicationDatabaseQuery ApplicationDatabaseQuery
        {
            get
            {
                return this._ApplicationDatabaseQuery;
            }
            set
            {
                this._ApplicationDatabaseQuery = value;
            }
        }

        #endregion

        #region Constructors

        public DBSourceAdapterResponse()
        {

        }

        public DBSourceAdapterResponse(IntegrationAdapter pAdapterMetadata, ApplicationDatabaseQuery pApplicationDatabaseQuery)
            : base(pAdapterMetadata)
        {
            this.ApplicationDatabaseQuery = pApplicationDatabaseQuery;
        }

        #endregion
    }
}