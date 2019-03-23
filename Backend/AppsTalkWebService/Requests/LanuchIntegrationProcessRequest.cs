#region

using System;
using System.Collections.Generic;
using ABATS.AppsTalk.Core;

#endregion

namespace AppsTalkWebService
{
    /// <summary>
    ///     Lanuch Integration Process Request
    /// </summary>
    [Serializable]
    public class LanuchIntegrationProcessRequest : RequestBase
    {
        #region Members

        private List<ParameterInfo> _Parameters = null;

        #endregion

        #region Properties

        public List<ParameterInfo> Parameters
        {
            get
            {
                if (this._Parameters == null)
                {
                    this._Parameters = new List<ParameterInfo>();
                }

                return this._Parameters;
            }
            set
            {
                this._Parameters = value;
            }
        }

        #endregion

        #region Constructors

        public LanuchIntegrationProcessRequest()
        {

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