using System;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Core
{
    /// <summary>
    /// Authorization Error
    /// </summary>
    public partial class AuthorizationError : UIComponent
    {
        #region Overrides

        protected override void OnLoad(System.EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Initialize();
            }

            base.OnLoad(e);
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

            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        #endregion
    }
}