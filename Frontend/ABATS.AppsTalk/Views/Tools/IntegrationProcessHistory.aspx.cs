using System;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Tools
{
    /// <summary>
    /// Integration Process History
    /// </summary>
    public partial class IntegrationProcessHistory : View<IntegrationProcessHistoryPresenter>
    {
        #region Events Handlers

        protected void ObjectDataSource_ObjectCreating(object sender, System.Web.UI.WebControls.ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = this.Presenter;
        }

        protected void ObjectDataSource_ObjectDisposing(object sender, System.Web.UI.WebControls.ObjectDataSourceDisposingEventArgs e)
        {
            e.Cancel = true;
        }

        protected void btnRun_Click(object sender, System.EventArgs e)
        {
            this.dgvHistory.DataBind();
        }

        #endregion

        #region Overrides

        protected override void LoadView()
        {
            base.LoadView();

            this.hfStartDate.Value = DateTime.Now.AddDays(-7).ToShortDateString();
            this.hfEndDate.Value = DateTime.Now.AddDays(1).ToShortDateString();
        } 

        #endregion
    }
}