using System.Collections.Specialized;
using System.Web.UI.WebControls;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Admin.IntegrationProcesses
{
    /// <summary>
    /// Integration Adapter Query View
    /// </summary>
    public partial class IntegrationAdapterQueryView : EntityView<IntegrationAdapterQuery, IntegrationAdapterQueryPresenter>
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

        protected void fvMain_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            OrderedDictionary values = e.NewValues as OrderedDictionary;

            var refIntegrationAdapterQueryID = values["RefIntegrationAdapterQueryID"];

            if (string.IsNullOrEmpty(refIntegrationAdapterQueryID.SafeToString()))
            {
                values.Remove("RefIntegrationAdapterQueryID");
                values.Add("RefIntegrationAdapterQueryID", null);
            }
        }

        protected void fvMain_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            OrderedDictionary values = e.Values as OrderedDictionary;

            var refIntegrationAdapterQueryID = values["RefIntegrationAdapterQueryID"];

            if (string.IsNullOrEmpty(refIntegrationAdapterQueryID.SafeToString()))
            {
                values.Remove("RefIntegrationAdapterQueryID");
                values.Add("RefIntegrationAdapterQueryID", null);
            }
        }

        protected void fvMain_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(typeof(System.Web.UI.Page), "closeWindow", "CloseWindowRegular();", true);
        }

        protected void dgvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            IntegrationAdapterQueryField field = e.Row.DataItem as IntegrationAdapterQueryField;

            if (field != null && field.IsRowVisible == false)
            {
                e.Row.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            this.SaveEntity();
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            this.dgvList.ShowFooter = true;
        }

        protected void btnInsert_Click(object sender, System.EventArgs e)
        {
            TextBox txtFieldName = this.dgvList.FooterRow.FindControl("txtFieldName") as TextBox;
            DropDownList cmbFieldDataType = this.dgvList.FooterRow.FindControl("cmbFieldDataType") as DropDownList;
            TextBox txtDescription = this.dgvList.FooterRow.FindControl("txtDescription") as TextBox;

            if (this.Presenter.InsertIntegrationAdapterQueryField(new IntegrationAdapterQueryField()
            {
                FieldName = txtFieldName.Text,
                FieldCategory = 1,
                FieldDataType = cmbFieldDataType.SelectedValue.SafeIntegerParse(),
                Description = txtDescription.Text.Trim(),
            }) > 0)
            {
                this.dgvList.ShowFooter = false;
            }
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.dgvList.ShowFooter = false;
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
                        this.divIntegrationApdaterQueryFields.Visible = false;
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