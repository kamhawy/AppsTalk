using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;
using System.Web.UI.WebControls;
using ABATS.AppsTalk.Presentation.Utilities;

namespace ABATS.AppsTalk.Views.Admin.IntegrationProcesses
{
    /// <summary>
    /// Integration Adapter View
    /// </summary>
    public partial class IntegrationAdapterView : EntityView<IntegrationAdapter, IntegrationAdapterPresenter>
    {
        #region FormView Controls

        public DropDownList cmbIntegrationAdapterType
        {
            get
            {
                return PresentationUtilities.GetFormViewControl<DropDownList>(this.fvMain, "cmbIntegrationAdapterType");
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

        protected void IntegrationAdapterDataSource_Inserted(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            this.SaveEntity();
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string url = string.Format("~/Views/Admin/IntegrationProcesses/IntegrationAdapterQueryView.aspx?IntegrationAdapterQueryID=-1&UIMode=Add&IntegrationAdapterID={0}&IntegrationProcessID={1}", this.Presenter.EntityID, this.Presenter.IntegrationProcessID);
            Response.Redirect(url);
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
                        this.cmbIntegrationAdapterType.SelectedValue = 
                            this.Presenter.IntegrationAdapterType.GetValue<int>().SafeToString();
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

            this.AdjustQueryFields();
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

        private void AdjustQueryFields()
        {
            if (this.Presenter.CurrentUIMode == UIMode.Add)
            {
                this.divIntegrationApdaterQueryFields.Visible = false;
            }
            else
            {
                this.divIntegrationApdaterQueryFields.Visible = true;
                this.divAddButton.Visible = this.dgvList.Rows.Count == 0;
            }
        }

        #endregion
    }
}