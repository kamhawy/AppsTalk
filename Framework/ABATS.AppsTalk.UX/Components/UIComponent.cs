using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// UI Component
    /// </summary>
    public abstract class UIComponent : System.Web.UI.UserControl
    {
        #region Members

        private IAppRuntime _AppRuntime = null;

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
            set
            {
                this._AppRuntime = value;
            }
        }

        #endregion

        #region Constructors

        public UIComponent()
            : base()
        {

        }

        #endregion

        #region Overrides

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                InitializeUIComponent();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize UI Component
        /// </summary>
        protected virtual void InitializeUIComponent()
        {

        }

        /// <summary>
        /// Display Validation Message
        /// </summary>
        /// <param name="pErrorMessage"></param>
        public void DisplayValidationMessage(string pErrorMessage, string pValidationGroup = Constants.DefaultValidationGroup)
        {
            WebUtilities.AddCustomValidator(this.Page, pErrorMessage, pValidationGroup);
        }

        /// <summary>
        /// Refresh Contents
        /// </summary>
        public virtual void RefreshContents()
        {

        }

        #endregion
    }

    /// <summary>
    /// UI Component [Presenter]
    /// </summary>
    public abstract class UIComponent<P> : UIComponent where P : PresenterBase
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

        #region Constructors

        public UIComponent()
            : base()
        {

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