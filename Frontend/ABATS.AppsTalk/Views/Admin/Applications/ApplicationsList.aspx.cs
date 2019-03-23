using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Admin.Applications
{
    /// <summary>
    /// Applications List
    /// </summary>
    public partial class ApplicationsList : View<ApplicationPresenter>
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
            base.Response.Redirect("~/Views/Admin/Applications/ApplicationView.aspx?ApplicationID=-1&UIMode=Add", false);
        }

        #endregion
    }
}