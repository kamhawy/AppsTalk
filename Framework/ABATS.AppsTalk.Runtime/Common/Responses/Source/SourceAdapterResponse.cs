#region

using ABATS.AppsTalk.Data;
using System;


#endregion

namespace ABATS.AppsTalk.Runtime.Common.Responses
{
    /// <summary>
    ///     Source Adapter Response
    /// </summary>
    [Serializable]
    public abstract class SourceAdapterResponse : AbstractAdapterResponse
    {
        #region Members

        #endregion

        #region Properties


        #endregion

        #region Constructors

        public SourceAdapterResponse()
        {

        }

        public SourceAdapterResponse(IntegrationAdapter pAdapterMetadata)
            : base(pAdapterMetadata)
        {

        }

        #endregion
    }
}