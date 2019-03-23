#region

using ABATS.AppsTalk.Data;
using System;


#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    ///     DB Destination Adapter Response
    /// </summary>
    [Serializable]
    public class DBDestinationAdapterResponse : DestinationAdapterResponse
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

        public DBDestinationAdapterResponse()
        {

        }

        public DBDestinationAdapterResponse(IntegrationAdapter pAdapterMetadata, ApplicationDatabaseQuery pApplicationDatabaseQuery)
            : base(pAdapterMetadata)
        {
            this.ApplicationDatabaseQuery = pApplicationDatabaseQuery;
        }

        #endregion
    }
}