#region

using ABATS.AppsTalk.Core;
using System;
using System.Runtime.Serialization;

#endregion

namespace ABATS.AppsTalk.Runtime
{
    /// <summary>
    /// Represents the abstract base class of all AppRuntime Managers
    /// </summary>
    [Serializable]
    public abstract class AppRuntimeComponent : DisposableBase, IAppRuntimeComponent
    {
        #region Members

        private IAppRuntime _AppRuntime = null;

        #endregion

        #region Properties

        [DataMember]
        public IAppRuntime AppRuntime
        {
            get
            {
                return this._AppRuntime;
            }
            set
            {
                this._AppRuntime = value;
            }
        }

        #endregion

        #region Constructor

        public AppRuntimeComponent()
        {

        }

        public AppRuntimeComponent(IAppRuntime pIAppRuntime)
        {
            this.AppRuntime = pIAppRuntime;
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