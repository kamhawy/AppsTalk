﻿using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;

namespace ABATS.AppsTalk.Views.Admin.IntegrationProcesses
{
    /// <summary>
    /// Integration Process View
    /// </summary>
    public partial class IntegrationProcessView : EntityView<IntegrationProcess, IntegrationProcessPresenter>
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
            base.Response.Redirect("~/Views/Admin/IntegrationProcesses/IntegrationProcessesList.aspx", false);
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

            this.AdjustAdapter();
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

        private void AdjustAdapter()
        {
            if (this.Presenter.CurrentUIMode == UIMode.Add)
            {
                this.divApplicationEndPoints.Visible = false;
            }
            else
            {
                this.divApplicationEndPoints.Visible = true;

                if (this.Presenter.Entity != null)
                {
                    this.tbSourceAdapter.Visible = this.Presenter.Entity.SourceIntegrationAdapterID > 0;
                    this.divAddSourceAdapter.Visible = !this.tbSourceAdapter.Visible;

                    if (this.Presenter.Entity.SourceIntegrationAdapter != null)
                    {
                        this.lblSourceAdapterName.Text = this.Presenter.Entity.SourceIntegrationAdapter.IntegrationAdapterTitle;
                        this.lblSourceAdapterDescription.Text = this.Presenter.Entity.SourceIntegrationAdapter.Description;

                        this.lblSourceAdapterName.Attributes.Add("onclick",
                            string.Format("ShowIntegrationAdapterView({0}, 'Edit', {1}, 1)",
                            this.Presenter.Entity.SourceIntegrationAdapter.IntegrationAdapterID.ToString(),
                            this.Presenter.EntityID.ToString()));
                    }

                    this.tbDestinationAdapter.Visible = this.Presenter.Entity.DestinationIntegrationAdapterID > 0;
                    this.divAddDestinationAdapter.Visible = !this.tbDestinationAdapter.Visible;

                    if (this.Presenter.Entity.DestinationIntegrationAdapter != null)
                    {
                        this.lblDestinationAdapterName.Text = this.Presenter.Entity.DestinationIntegrationAdapter.IntegrationAdapterTitle;
                        this.lblDestinationAdpaterDescription.Text = this.Presenter.Entity.DestinationIntegrationAdapter.Description;

                        this.lblDestinationAdapterName.Attributes.Add("onclick",
                            string.Format("ShowIntegrationAdapterView({0}, 'Edit', {1}, 2)",
                            this.Presenter.Entity.DestinationIntegrationAdapter.IntegrationAdapterID.ToString(),
                            this.Presenter.EntityID.ToString()));
                    }

                    this.lblMapping.Visible =
                        this.Presenter.Entity.SourceIntegrationAdapterID > 0 &&
                        this.Presenter.Entity.DestinationIntegrationAdapterID > 0;

                    if (this.lblMapping.Visible)
                    {
                        this.lblMapping.Attributes.Add("onclick",
                                string.Format("ShowIntegrationProcessMappingView({0}, 'Edit')",
                                this.Presenter.Entity.IntegrationProcessID.ToString()));
                    }
                }
            }
        }

        #endregion
    }
}