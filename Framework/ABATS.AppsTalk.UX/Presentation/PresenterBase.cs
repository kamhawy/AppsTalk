using System;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// Presenter Base
    /// </summary>
    [Serializable]
    public abstract class PresenterBase : DisposableBase
    {
        #region Members

        private IAppRuntime _AppRuntime = null;

        /// <summary>
        /// Lock Object
        /// </summary>
        protected static readonly object _lockObj = new object();

        #endregion

        #region Properties

        /// <summary>
        /// AppRuntime
        /// </summary>
        [DataMember]
        public IAppRuntime AppRuntime
        {
            get
            {
                if (this._AppRuntime == null)
                {
                    this._AppRuntime = AppRuntimeFactory.CreateAppRuntime(true);
                }

                return this._AppRuntime;
            }
            set
            {
                this._AppRuntime = value;
            }
        }

        /// <summary>
        /// Current UI Mode
        /// </summary>
        [DataMember]
        public UIMode CurrentUIMode
        {
            get
            {
                return GetCurrentUIMode();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Presenter Base
        /// </summary>
        public PresenterBase()
        {

        }

        /// <summary>
        /// Presenter Base
        /// </summary>
        /// <param name="pAppRuntime"></param>
        public PresenterBase(IAppRuntime pAppRuntime)
        {
            this.AppRuntime = pAppRuntime;
        }

        #endregion

        #region Statics

        public static P GetSessionInstance<P>() where P : PresenterBase
        {
            P presenter = WebUtilities.GetSessionObject<P>();

            if (presenter == null)
            {
                presenter = Activator.CreateInstance<P>();

                if (presenter != null)
                {
                    WebUtilities.SetSessionObject(presenter.GetSessionKey<P>(), presenter);
                }
            }

            return presenter;
        }

        #endregion

        #region Virtuals

        /// <summary>
        /// Get Current UIMode
        /// </summary>
        /// <returns></returns>
        public virtual UIMode GetCurrentUIMode()
        {
            return WebUtilities.GetObjectFromQueryString(Constants.QueryStringKey_UIMode).SafeEnumParse<UIMode>();
        }

        /// <summary>
        /// Is Disposable
        /// </summary>
        public virtual bool IsDisposable
        {
            get { return true; }
        }

        /// <summary>
        /// Get Session Key
        /// </summary>
        public virtual string GetSessionKey<P>()
        {
            return string.Format("{0}{1}", Constants.Prefix_SessionKey_Presenter, typeof(P).Name);
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