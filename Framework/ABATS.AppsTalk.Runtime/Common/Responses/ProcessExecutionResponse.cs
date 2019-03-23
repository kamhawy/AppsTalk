#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime.Common.Requests;
using System;

#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    ///     Process Execution Response
    /// </summary>
    [Serializable]
    public class ProcessExecutionResponse : ResponseBase
    {
        #region Members

        private IntegrationProcess _IntegrationProcessMetadata = null;
        private SourceAdapterResponse _SourceAdapterResponse = null;
        private DestinationAdapterResponse _DestinationAdapterResponse = null;

        #endregion

        #region Properties

        public IntegrationProcess IntegrationProcessMetadata
        {
            get
            {
                return this._IntegrationProcessMetadata;
            }
            set
            {
                this._IntegrationProcessMetadata = value;
            }
        }

        public SourceAdapterResponse SourceAdapterResponse
        {
            get
            {
                return this._SourceAdapterResponse;
            }
            set
            {
                this._SourceAdapterResponse = value;
            }
        }

        public DestinationAdapterResponse DestinationAdapterResponse
        {
            get
            {
                return this._DestinationAdapterResponse;
            }
            set
            {
                this._DestinationAdapterResponse = value;
            }
        }

        #endregion

        #region Constructors

        public ProcessExecutionResponse()
        {

        }

        public ProcessExecutionResponse(ProcessExecutionRequest pProcessExecutionRequest)
            : base(pProcessExecutionRequest)
        {

        }
        public ProcessExecutionResponse(ProcessExecutionRequest pProcessExecutionRequest, IntegrationProcess pIntegrationProcessMetadata)
            : base(pProcessExecutionRequest)
        {
            this.IntegrationProcessMetadata = pIntegrationProcessMetadata;
        }

        #endregion
    }
}