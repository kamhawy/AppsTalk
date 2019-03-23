using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    /// Abstract WS Provider
    /// </summary>
    public abstract class AbstractWSProvider : AbstractProvider
    {
        #region Members

        private ApplicationWebService _ApplicationWebServiceMetadata = null;

        #endregion

        #region Properties

        public ApplicationWebService ApplicationWebServiceMetadata
        {
            get { return this._ApplicationWebServiceMetadata; }
            set { this._ApplicationWebServiceMetadata = value; }
        }

        #endregion

        #region Constructors

        public AbstractWSProvider(IntegrationAdapter pAdapterMetadata, ApplicationWebService pApplicationWebServiceMetadata, IAppRuntime pAppRuntime)
            : base(pAdapterMetadata, pAppRuntime)
        {
            this.ApplicationWebServiceMetadata = pApplicationWebServiceMetadata;
        }

        #endregion

        #region Abstracts

        /// <summary>
        /// Invoke Application Web Service Request - GET
        /// </summary>
        /// <param name="pApplicationWebServiceRequest"></param>
        /// <returns></returns>
        public abstract WSSourceAdapterResponse InvokeApplicationWebServiceRequest_GET(ApplicationWebServiceRequest pApplicationWebServiceRequest);

        /// <summary>
        /// Invoke Application Web Service Request - POST
        /// </summary>
        /// <param name="pApplicationWebServiceRequest"></param>
        /// <param name="pPushToDestinationRequest"></param>
        /// <returns></returns>
        public abstract WSDestinationAdapterResponse InvokeApplicationWebServiceRequest_POST(ApplicationWebServiceRequest pApplicationWebServiceRequest, PushToDestinationRequest pPushToDestinationRequest);

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}