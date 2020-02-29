using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;
using System.Web.UI.WebControls;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Views.Admin.IntegrationProcesses
{
    /// <summary>
    /// Integration Process Mapping View
    /// </summary>
    public partial class IntegrationProcessMappingView : EntityView<IntegrationProcessMapping, IntegrationProcessMappingPresenter>
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

        protected void dgvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            IntegrationProcessMapping mapping = e.Row.DataItem as IntegrationProcessMapping;

            if (mapping != null && mapping.IsRowVisible == false)
            {
                e.Row.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            this.dgvList.ShowFooter = true;
        }

        protected void btnInsert_Click(object sender, System.EventArgs e)
        {
            DropDownList cmbSourceField = this.dgvList.FooterRow.FindControl("cmbSourceField") as DropDownList;
            DropDownList cmbDestinationField = this.dgvList.FooterRow.FindControl("cmbDestinationField") as DropDownList;
            TextBox txtDescription = this.dgvList.FooterRow.FindControl("txtDescription") as TextBox;

            if (this.Presenter.InsertIntegrationProcessMapping(new IntegrationProcessMapping()
            {
                SourceAdapterQueryFieldID = cmbSourceField.SelectedValue.SafeIntegerParse(),
                DestinationAdapterQueryFieldID = cmbDestinationField.SelectedValue.SafeIntegerParse(),
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
    }
}