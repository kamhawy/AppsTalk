using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.Presentation.Utilities;
using ABATS.AppsTalk.UX;
using System.Collections.Specialized;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ABATS.AppsTalk.Views.Admin.IntegrationAdapters
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

        public DropDownList cmbEndPointType
        {
            get
            {
                return PresentationUtilities.GetFormViewControl<DropDownList>(this.fvMain, "cmbEndPointType");
            }
        }

        public HtmlTableRow trDatabaseQuery
        {
            get
            {
                return PresentationUtilities.GetFormViewControl<HtmlTableRow>(this.fvMain, "trDatabaseQuery");
            }
        }

        public HtmlTableRow trWebServiceRequest
        {
            get
            {
                return PresentationUtilities.GetFormViewControl<HtmlTableRow>(this.fvMain, "trWebServiceRequest");
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
            if (this.TryInsertIntegrationAdapterField())
            {
                this.dgvList.ShowFooter = false;
            }
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.dgvList.ShowFooter = false;
        }

        protected void dgvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            IntegrationAdapterField field = e.Row.DataItem as IntegrationAdapterField;

            if (field != null && field.IsRowVisible == false)
            {
                e.Row.Visible = false;
            }
        }

        protected void cmbEndPointType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.AdjustEndPointTypeUX(this.cmbEndPointType.SelectedValue.SafeIntegerParse().ToEnum<EndPointType>());
        }

        protected void fvMain_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            this.AdjustEndPointDBValues(e.NewValues as OrderedDictionary);
        }

        protected void fvMain_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            this.AdjustEndPointDBValues(e.Values as OrderedDictionary);
        }

        protected void fvMain_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            base.NavigateBack();
        }

        protected void fvMain_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            base.NavigateBack();
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

                        this.divIntegrationApdaterFields.Visible = false;
                        this.cmbIntegrationAdapterType.SelectedValue = this.Presenter.IntegrationAdapterType.GetValue<int>().SafeToString();
                        this.cmbEndPointType.SelectedValue = EndPointType.Database.GetValue<int>().SafeToString();
                        this.AdjustEndPointTypeUX(EndPointType.Database);
                    }
                    break;
                case UIMode.Admin:
                case UIMode.Edit:
                    {
                        this.fvMain.DefaultMode = System.Web.UI.WebControls.FormViewMode.Edit;

                        if (this.Presenter.Entity != null)
                        {
                            this.AdjustEndPointTypeUX(this.Presenter.Entity.EndPointType.ToEnum<EndPointType>());
                        }
                    }
                    break;
                case UIMode.View:
                    {
                        this.fvMain.DefaultMode = System.Web.UI.WebControls.FormViewMode.ReadOnly;

                        if (this.Presenter.Entity != null)
                        {
                            this.AdjustEndPointTypeUX(this.Presenter.Entity.EndPointType.ToEnum<EndPointType>());
                        }
                    }
                    break;
            }
        }

        #endregion

        #region Methods

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

        private void AdjustEndPointTypeUX(EndPointType pEndPointType)
        {
            if (this.trDatabaseQuery != null)
            {
                this.trDatabaseQuery.Visible = pEndPointType == EndPointType.Database;
            }
            if (this.trWebServiceRequest != null)
            {
                this.trWebServiceRequest.Visible = pEndPointType == EndPointType.WebService;
            }
        }

        private void AdjustEndPointDBValues(OrderedDictionary pValues)
        {
            if (pValues != null)
            {
                EndPointType _EndPointType = pValues["EndPointType"].SafeIntegerParse(1).ToEnum<EndPointType>();

                var _ApplicationDatabaseQueryID = pValues[ApplicationDatabaseQuery.sEntityKey];

                if (_EndPointType != EndPointType.Database || !_ApplicationDatabaseQueryID.SafeToString().IsValidString())
                {
                    pValues.Remove(ApplicationDatabaseQuery.sEntityKey);
                    pValues.Add(ApplicationDatabaseQuery.sEntityKey, null);
                }

                var _ApplicationWebServiceRequestID = pValues[ApplicationWebServiceRequest.sEntityKey];

                if (_EndPointType != EndPointType.WebService || !_ApplicationWebServiceRequestID.SafeToString().IsValidString())
                {
                    pValues.Remove(ApplicationWebServiceRequest.sEntityKey);
                    pValues.Add(ApplicationWebServiceRequest.sEntityKey, null);
                }
            }
        }

        private bool TryInsertIntegrationAdapterField()
        {
            bool success = false;

            try
            {
                TextBox txtFieldName = this.dgvList.FooterRow.FindControl("txtFieldName") as TextBox;
                DropDownList cmbFieldDataType = this.dgvList.FooterRow.FindControl("cmbFieldDataType") as DropDownList;
                CheckBox chkIsPrimaryKey = this.dgvList.FooterRow.FindControl("chkIsPrimaryKey") as CheckBox;
                TextBox txtPrimaryKeySequence = this.dgvList.FooterRow.FindControl("txtPrimaryKeySequence") as TextBox;
                TextBox txtDescription = this.dgvList.FooterRow.FindControl("txtDescription") as TextBox;

                if (txtFieldName != null && cmbFieldDataType != null && chkIsPrimaryKey != null && txtPrimaryKeySequence != null && txtDescription != null)
                {
                    IntegrationAdapterField _IntegrationAdapterField = new IntegrationAdapterField()
                    {
                        FieldName = txtFieldName.Text,
                        FieldDataType = cmbFieldDataType.SelectedValue.SafeIntegerParse(),
                        IsPrimaryKey = chkIsPrimaryKey.Checked,
                        PrimaryKeySequence = txtDescription.Text.SafeByteParse(1),
                        FieldCategory = FieldCategory.Standard.GetValue<int>(),
                        Description = txtDescription.Text.Trim(),
                    };

                    success = this.Presenter.InsertIntegrationAdapterField(_IntegrationAdapterField) > 0;
                }
            }
            catch (System.Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion
    }
}