using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;
using System;
using System.Web.UI;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// View
    /// </summary>
    public class View : Page
    {
        #region Members

        private IAppRuntime _AppRuntime = null;
        private HistoryManager _HistroyManager = null;

        #endregion

        #region Properties

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
            protected set
            {
                this._AppRuntime = value;
            }
        }

        public UIMode ViewMode
        {
            get
            {
                return WebUtilities.GetObjectFromQueryString(Constants.QueryStringKey_UIMode).SafeEnumParse<UIMode>();
            }
        }

        public string PageFriendlyName
        {
            get
            {
                return WebUtilities.GetPageFirendlyName(base.Context.Request);
            }
        }

        public virtual bool NeedsAuthorization
        {
            get
            {
                return false;
            }
        }

        public virtual bool AddPageUserTracking
        {
            get
            {
                return false;
            }
        }

        public HistoryManager HistroyManager
        {
            get
            {
                if (this._HistroyManager == null)
                {
                    this._HistroyManager = HistoryManager.GetHistoryManager(this.AppRuntime, Constants.SessionKey_HistoryManager);
                }

                return this._HistroyManager;
            }
        }

        #endregion

        #region Overrides

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!base.IsPostBack)
            {
                this.Initialize();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitializeView();

            if (!this.IsPostBack)
            {
                LoadView();
            }
        }

        protected override void OnUnload(System.EventArgs e)
        {
            try
            {
                if (this._AppRuntime != null)
                {
                    this._AppRuntime.DisposeRuntimeService(RuntimeService.Data);
                }

                PresenterFactory.RemovePresentersFromSession();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
            finally
            {
                base.OnUnload(e);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize
        /// </summary>
        private void Initialize()
        {
            try
            {
                //if (NeedsAuthorization && !this.AppRuntime.SecurityService.CheckUserAuthorization(this.AppRuntime.SecurityService.CurrentUser, this.PageFriendlyName, AddPageUserTracking))
                //{
                //    System.Web.HttpContext.Current.Response.Redirect(Constants.Page_NotAuthorized, "_self", null);
                //    System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
                //}
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        /// Display Validation Message
        /// </summary>
        /// <param name="pErrorMessage"></param>
        public void DisplayValidationMessage(string pErrorMessage, string pValidationGroup = Constants.DefaultValidationGroup)
        {
            WebUtilities.AddCustomValidator(this, pErrorMessage, pValidationGroup);
        }

        /// <summary>
        /// Initialize View
        /// </summary>
        protected virtual void InitializeView()
        {

        }

        /// <summary>
        /// Load View
        /// </summary>
        protected virtual void LoadView()
        {
            if (!IsPostBack)
            {
                if (base.Request.UrlReferrer != null)
                {
                    this.HistroyManager.AddHistoryPoint(base.Request.Url.SafeToString(), base.Request.UrlReferrer.SafeToString());
                }
            }
        }

        protected void NavigateBack()
        {
            string historyURL = this.HistroyManager.GetHistoryPointURL(base.Request.Url.SafeToString());

            if (historyURL.IsValidString())
            {
                base.Response.Redirect(historyURL, true);
            }
        }

        #endregion
    }

    /// <summary>
    /// View [Presenter]
    /// </summary>
    public abstract class View<P> : View where P : PresenterBase
    {
        #region Members

        private P _Presenter = null;

        #endregion

        #region Properties

        public P Presenter
        {
            get
            {
                if (this._Presenter == null)
                {
                    this._Presenter = GetPresenter();
                }

                return this._Presenter;
            }
        }

        #endregion

        #region Virtuals

        public virtual P GetPresenter()
        {
            return PresenterBase.GetSessionInstance<P>();
        }

        #endregion
    }
}