#region

using ABATS.AppsTalk.Data;
using System;


#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    /// WS Destination Adapter Response
    /// </summary>
    [Serializable]
    public class WSDestinationAdapterResponse : DestinationAdapterResponse
    {
        #region Members

        private ApplicationWebServiceRequest _ApplicationWebServiceRequest = null;

        #endregion

        #region Properties

        public ApplicationWebServiceRequest ApplicationWebServiceRequest
        {
            get
            {
                return this._ApplicationWebServiceRequest;
            }
            set
            {
                this._ApplicationWebServiceRequest = value;
            }
        }

        #endregion

        #region Constructors

        public WSDestinationAdapterResponse()
        {

        }

        public WSDestinationAdapterResponse(IntegrationAdapter pAdapterMetadata, ApplicationWebServiceRequest pApplicationWebServiceRequest)
            : base(pAdapterMetadata)
        {
            this.ApplicationWebServiceRequest = pApplicationWebServiceRequest;
        }

        #endregion
    }
}