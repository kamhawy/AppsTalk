using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Admin.Applications
{
    /// <summary>
    /// Application View
    /// </summary>
    public partial class ApplicationView : EntityView<Application, ApplicationPresenter>
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

        protected void ObjectDataSource_Inserted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            base.Response.Redirect("~/Views/Applications/ApplicationsList.aspx", false);
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            this.SaveEntity();
        }

        protected void btnAddApplicationEndPoint_Click(object sender, System.EventArgs e)
        {
            base.Response.Redirect(string.Format("~/Views/Admin/Applications/ApplicationEndPointView.aspx?ApplicationID={0}&ApplicationEndPoint=-1&UIMode=Add", this.Presenter.EntityID), false);
        }
        
        #endregion

        #region Overrides

        protected override void LoadView()
        {
            base.LoadView();

            switch (this.Presenter.CurrentUIMode)
            {
                case UIMode.Add:
                case UIMode.None:
                default:
                    {
                        this.fvMain.DefaultMode = System.Web.UI.WebControls.FormViewMode.Insert;
                        this.divApplicationEndPoints.Visible = false;
                    }
                    break;
                case UIMode.Admin:
                case UIMode.Edit:
                    {
                        this.fvMain.DefaultMode = System.Web.UI.WebControls.FormViewMode.Edit;
                    }
                    break;
                case UIMode.View:
                    {
                        this.fvMain.DefaultMode = System.Web.UI.WebControls.FormViewMode.ReadOnly;
                    }
                    break;
            }
        }

        private void SaveEntity()
        {
            switch (this.Presenter.CurrentUIMode)
            {
                case UIMode.Add:
                case UIMode.None:
                    {
                        this.fvMain.InsertItem(true);
                    }
                    break;
                case UIMode.Admin:
                case UIMode.Edit:
                    {
                        this.fvMain.UpdateItem(true);
                    }
                    break;
                default:
                case UIMode.View:
                    { }
                    break;
            }
        }
        
        #endregion
    }
}