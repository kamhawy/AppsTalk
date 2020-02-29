using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Admin.IntegrationProcesses
{
    /// <summary>
    /// Integration Processes List
    /// </summary>
    public partial class IntegrationProcessesList : View<IntegrationProcessPresenter>
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

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect("~/Views/Admin/IntegrationProcesses/IntegrationProcessView.aspx?IntegrationProcessID=-1&UIMode=Add", false);            
        }

        #endregion
    }
}