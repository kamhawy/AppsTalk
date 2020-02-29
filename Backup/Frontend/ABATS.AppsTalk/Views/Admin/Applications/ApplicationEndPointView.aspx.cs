using System.Web.UI.WebControls;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.Presentation.Utilities;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Admin.Applications
{
    /// <summary>
    /// Application EndPoint View
    /// </summary>
    public partial class ApplicationEndPointView : EntityView<ApplicationEndPoint, ApplicationEndPointPresenter>
    {
        #region FormView Controls

        public DropDownList cmbApplicationEndPointType
        {
            get
            {
                return PresentationUtilities.GetFormViewControl<DropDownList>(this.fvMain, "cmbApplicationEndPointType");
            }
        }

        #endregion

        #region Events Handlers

        protected void ObjectDataSource_ObjectCreating(object sender, System.Web.UI.WebControls.ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = this.Presenter;
        }

        protected void ObjectDataSource_ObjectDisposing(object sender, System.Web.UI.WebControls.ObjectDataSourceDisposingEventArgs e)
        {
            e.Cancel = true;
        }

        protected void ObjectDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            base.Presenter.TempApplicationEndPoint = e.ReturnValue as ApplicationEndPoint;
        }

        protected void DBConnectionDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            this.SaveEntity();
        }

        protected void cmbApplicationEndPointType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DropDownList cmbApplicationEndPointType = sender as DropDownList;

            if (cmbApplicationEndPointType != null)
            {
                this.divDBConnection.Visible =
                    (ApplicationEndPointType)cmbApplicationEndPointType.SelectedValue.SafeIntegerParse()
                        == ApplicationEndPointType.Database;
            }
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
                        this.fvMain.DefaultMode = this.fvDBConnection.DefaultMode = FormViewMode.Insert;
                    }
                    break;
                case UIMode.Admin:
                case UIMode.Edit:
                    {
                        this.fvMain.DefaultMode = this.fvDBConnection.DefaultMode = FormViewMode.Edit;
                    }
                    break;
                case UIMode.View:
                    {
                        this.fvMain.DefaultMode = this.fvDBConnection.DefaultMode = FormViewMode.ReadOnly;
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

                        if (this.cmbApplicationEndPointType.SelectedValue.SafeIntegerParse() == (int)ApplicationEndPointType.Database)
                        {
                            this.fvDBConnection.InsertItem(true);

                        }
                    }
                    break;
                case UIMode.Admin:
                case UIMode.Edit:
                    {
                        this.fvMain.UpdateItem(true);

                        if (this.cmbApplicationEndPointType.SelectedValue.SafeIntegerParse() == (int)ApplicationEndPointType.Database)
                        {
                            this.fvDBConnection.UpdateItem(true);
                        }
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