#region

using ABATS.AppsTalk.Data;
using System;

#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    ///     Destination Adapter Response
    /// </summary>
    [Serializable]
    public abstract class DestinationAdapterResponse : AbstractAdapterResponse
    {
        #region Members


        #endregion

        #region Properties


        #endregion

        #region Constructors

        public DestinationAdapterResponse()
        {

        }

        public DestinationAdapterResponse(IntegrationAdapter pAdapterMetadata)
            : base(pAdapterMetadata)
        {

        }

        #endregion
    }
}