using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Presentation;
using ABATS.AppsTalk.UX;
using System;

namespace ABATS.AppsTalk.Views.Tools
{
    /// <summary>
    /// Execute Integration Process
    /// </summary>
    public partial class ExecuteIntegrationProcess : View<ExecuteIntegrationProcessPresenter>
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

        protected void cmbIntegrationProcess_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.LoadDetails(this.cmbIntegrationProcess.SelectedValue.SafeIntegerParse());
        }

        protected void btnRun_Click(object sender, System.EventArgs e)
        {
            this.TryExecute();
        }

        #endregion

        #region Methos

        private void LoadDetails(int pIntegrationProcessID)
        {
            if (pIntegrationProcessID > 0)
            {
                IntegrationProcess integrationProcess = this.Presenter.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationProcess>.Create(c =>
                    c.IntegrationProcessID == pIntegrationProcessID, "SourceIntegrationAdapter", "DestinationIntegrationAdapter"));

                if (integrationProcess != null)
                {
                    this.divProcessInfo.Visible = true;
                    this.lblDescription.Text = integrationProcess.Description;

                    if (integrationProcess.SourceIntegrationAdapter != null)
                    {
                        this.imgSourceAdapterImage.ImageUrl = Presentation.Utilities.PresentationUtilities.GetEndPointTypeImage(integrationProcess.SourceIntegrationAdapter.EndPointType.ToEnum<EndPointType>());
                        this.lblSourceAdapterName.Text = integrationProcess.SourceIntegrationAdapter.IntegrationAdapterTitle;
                        this.lblSourceAdapterDescription.Text = integrationProcess.SourceIntegrationAdapter.Description;
                    }

                    if (integrationProcess.DestinationIntegrationAdapter != null)
                    {
                        this.imgDestinationAdapterImage.ImageUrl = Presentation.Utilities.PresentationUtilities.GetEndPointTypeImage(integrationProcess.DestinationIntegrationAdapter.EndPointType.ToEnum<EndPointType>());
                        this.lblDestinationAdapterName.Text = integrationProcess.DestinationIntegrationAdapter.IntegrationAdapterTitle;
                        this.lblDestinationAdpaterDescription.Text = integrationProcess.DestinationIntegrationAdapter.Description;
                    }

                    if (integrationProcess.SourceIntegrationAdapter != null &&
                        integrationProcess.DestinationIntegrationAdapter != null)
                    {
                        this.btnRun.Enabled = true;
                    }
                    else
                    {
                        this.btnRun.Enabled = false;
                    }
                }
            }
            else
            {
                this.divProcessInfo.Visible = false;
            }
        }

        private void TryExecute()
        {
            try
            {
                IntegrationProcess process = base.Presenter.AppRuntime.DataService.GetEntity<IntegrationProcess>(this.cmbIntegrationProcess.SelectedValue.SafeIntegerParse());

                if (process != null)
                {
                    using (ABATS.AppsTalk.AppsTalkWS.AppsTalkWebServiceInterface client = new AppsTalkWS.AppsTalkWebServiceInterface())
                    {
                        ABATS.AppsTalk.AppsTalkWS.LanuchIntegrationProcessRequest request = new ABATS.AppsTalk.AppsTalkWS.LanuchIntegrationProcessRequest();

                        request.Parameters = new ABATS.AppsTalk.AppsTalkWS.ParameterInfo[] 
                    {
                        new ABATS.AppsTalk.AppsTalkWS.ParameterInfo() 
                        { 
                            SystemParameter = AppsTalkWS.SystemParameter.code,
                            ParameterValue = process.IntegrationProcessCode
                        }
                    };

                        client.LanuchIntegrationProcessAsyncAsync(request);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        #endregion
    }
}