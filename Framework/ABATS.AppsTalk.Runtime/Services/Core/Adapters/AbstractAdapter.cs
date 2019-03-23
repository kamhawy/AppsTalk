#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;


#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core.Adapters
{
    /// <summary>
    ///     Abstract Adapter
    /// </summary>
    internal abstract class AbstractAdapter : AppRuntimeComponent
    {
        #region Members

        private IntegrationProcess _ProcessMetadata = null;
        private IntegrationAdapter _AdapterMetadata = null;

        #endregion

        #region Properties

        internal IntegrationProcess ProcessMetadata
        {
            get
            {
                return this._ProcessMetadata;
            }
            set
            {
                this._ProcessMetadata = value;
            }
        }

        internal IntegrationAdapter AdapterMetadata
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

        #endregion

        #region Constructors

        internal AbstractAdapter(IntegrationProcess pProcessMetadata, IntegrationAdapter pAdapterMetadata, IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {
            this.ProcessMetadata = pProcessMetadata;
            this.AdapterMetadata = pAdapterMetadata;
        }

        #endregion

        #region Abstracts

        /// <summary>
        /// Consume Source
        /// </summary>
        /// <returns>Source Adapter Response</returns>
        internal abstract SourceAdapterResponse ConsumeSource();

        /// <summary>
        /// Publish To Destination
        /// </summary>
        /// <param name="pPushToDestinationRequest"></param>
        /// <returns>Destination Adapter Response</returns>
        internal abstract DestinationAdapterResponse PublishToDestination(PushToDestinationRequest pPushToDestinationRequest);

        #endregion

        #region Helpers

        /// <summary>
        /// Validate Adapter
        /// </summary>
        /// <param name="pCheckType"></param>
        /// <returns></returns>
        protected bool ValidateAdapter(IntegrationChannelType pCheckType)
        {
            bool isValidMetadata = false;

            if (this.ProcessMetadata != null)
            {
                if (this.AdapterMetadata != null && this.AdapterMetadata.IntegrationAdapterType.ToEnum<IntegrationChannelType>() == pCheckType)
                {
                    EndPointType endPointType = this.AdapterMetadata.EndPointType.ToEnum<EndPointType>();

                    if (endPointType == EndPointType.Database)
                    {
                        if (this.AdapterMetadata.ApplicationDatabaseQuery != null && this.AdapterMetadata.ApplicationDatabaseQuery.ApplicationDatabas != null)
                        {
                            isValidMetadata = true;
                        }
                    }
                    else if (endPointType == EndPointType.WebService)
                    {
                        if (this.AdapterMetadata.ApplicationWebServiceRequest != null && this.AdapterMetadata.ApplicationWebServiceRequest.ApplicationWebService != null)
                        {
                            isValidMetadata = true;
                        }
                    }
                }
            }

            return isValidMetadata;
        }

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