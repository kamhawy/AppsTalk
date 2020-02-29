using System;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Core
{
    /// <summary>
    /// Controls Container
    /// </summary>
    public partial class ControlsContainer : View
    {
        #region Properties

        public string UserControlFullPath
        {
            get
            {
                return WebUtilities.GetObjectFromQueryString(Constants.QueryStringKey_UserControlFullPath);
            }
        }

        #endregion

        #region Overrides

        protected override void OnLoad(System.EventArgs e)
        {
            this.Initialize();
            base.OnLoad(e);
        }

        public override bool NeedsAuthorization
        {
            get
            {
                return false;
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
                if (!string.IsNullOrEmpty(this.UserControlFullPath))
                {
                    //if (this.AppRuntime.SecurityService.CheckUserAuthorization(this.AppRuntime.SecurityService.CurrentUser, WebUtilities.ClearAppRootSymbol(this.UserControlFullPath)))
                    //{
                        UIComponent control = this.Page.LoadControl(this.UserControlFullPath) as UIComponent;

                        if (control != null)
                        {
                            if (string.IsNullOrEmpty(control.ID))
                            {
                                //control.ID = control.UserControlID;
                            }

                            panelControlsContainer.Controls.Add(control);
                        }
                    //}
                    //else
                    //{
                    //    UIComponent ctrlAuthorizationError = this.Page.LoadControl("~/Views/Core/AuthorizationError.ascx") as UIComponent;

                    //    if (ctrlAuthorizationError != null)
                    //    {
                    //        if (string.IsNullOrEmpty(ctrlAuthorizationError.ID))
                    //        {
                    //            //ctrlAuthorizationError.ID = ctrlAuthorizationError.UserControlID;
                    //        }

                    //        panelControlsContainer.Controls.Add(ctrlAuthorizationError);
                    //    }
                    //}
                }
                else
                {
                    base.DisplayValidationMessage(ABATS.AppsTalk.Presentation.Properties.Resources.Invalid_UserControlFullPath);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        #endregion
    }
}