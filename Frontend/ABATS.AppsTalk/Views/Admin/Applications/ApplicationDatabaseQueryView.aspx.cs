using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;
using System.Web.UI.WebControls;

namespace ABATS.AppsTalk.Views.Admin.Applications
{
    /// <summary>
    /// Application Database Query View
    /// </summary>
    public partial class ApplicationDatabaseQueryView : EntityView<ApplicationDatabaseQuery, ApplicationDatabaseQueryPresenter>
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

        protected void fvMain_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            base.NavigateBack();
        }

        protected void fvMain_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            base.NavigateBack();
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            this.SaveEntity();
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