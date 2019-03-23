#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;
using ABATS.AppsTalk.Runtime.Services.Core.Providers;
using System;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core.Adapters
{
    /// <summary>
    /// Web Service Adapter
    /// </summary>
    internal class WSAdapter : AbstractAdapter
    {
        #region Constructor

        internal WSAdapter(IntegrationProcess pProcessMetadata, IntegrationAdapter pAdapterMetadata, IAppRuntime pIAppRuntime)
            : base(pProcessMetadata, pAdapterMetadata, pIAppRuntime)
        {

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Consume Source
        /// </summary>
        /// <returns>Source Adapter Response</returns>
        internal override SourceAdapterResponse ConsumeSource()
        {
            WSSourceAdapterResponse response = null;

            try
            {
                if (this.ValidateAdapter(IntegrationChannelType.Source))
                {
                    using (AbstractWSProvider sourceWSProvider =
                        WSProviderFactory.CreateWSProvider(this.AdapterMetadata, this.AdapterMetadata.ApplicationWebServiceRequest, AppRuntime))
                    {
                        response = sourceWSProvider.InvokeApplicationWebServiceRequest_GET(this.AdapterMetadata.ApplicationWebServiceRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);

                if (response != null)
                {
                    response.Status = OperationStatus.Failed;
                }
            }

            return response;
        }

        /// <summary>
        /// Publish To Destination
        /// </summary>
        /// <param name="pPushToDestinationRequest"></param>
        /// <returns>Destination Adapter Response</returns>
        internal override DestinationAdapterResponse PublishToDestination(PushToDestinationRequest pPushToDestinationRequest)
        {
            WSDestinationAdapterResponse response = null;

            try
            {
                if (base.ValidateAdapter(IntegrationChannelType.Destination) && pPushToDestinationRequest != null)
                {
                    using (AbstractWSProvider destinationWSProvider =
                        WSProviderFactory.CreateWSProvider(this.AdapterMetadata, this.AdapterMetadata.ApplicationWebServiceRequest, base.AppRuntime))
                    {
                        response = destinationWSProvider.InvokeApplicationWebServiceRequest_POST(this.AdapterMetadata.ApplicationWebServiceRequest, pPushToDestinationRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);

                if (response != null)
                {
                    response.Status = OperationStatus.Failed;
                }
            }

            return response;
        }

        #endregion

        #region Factory

        internal static WSAdapter Create(IntegrationProcess pProcessMetadata, IntegrationAdapter pAdapterMetadata, IAppRuntime pIAppRuntime)
        {
            return new WSAdapter(pProcessMetadata, pAdapterMetadata, pIAppRuntime);
        }

        #endregion
    }
}