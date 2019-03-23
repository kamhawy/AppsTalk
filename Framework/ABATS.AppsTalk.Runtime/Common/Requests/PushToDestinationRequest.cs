#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System;
using System.Collections.Generic;

#endregion

namespace ABATS.AppsTalk.Runtime.Common.Requests
{
    /// <summary>
    /// Push To Destination Request
    /// </summary>
    [Serializable]
    public class PushToDestinationRequest : RequestBase
    {
        #region Members

        private IList<AdapterCacheResult> _AdapterCacheResults = null;

        #endregion

        #region Properties

        public IList<AdapterCacheResult> AdapterCacheResults
        {
            get
            {
                if (this._AdapterCacheResults == null)
                {
                    this._AdapterCacheResults = new List<AdapterCacheResult>();
                }

                return this._AdapterCacheResults;
            }
            set
            {
                this._AdapterCacheResults = value;
            }
        }

        #endregion

        #region Constructors

        public PushToDestinationRequest()
            : base()
        {

        }

        public PushToDestinationRequest(DateTime pRequestDate, string pRequestUser)
            : base(pRequestDate, pRequestUser)
        {

        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}