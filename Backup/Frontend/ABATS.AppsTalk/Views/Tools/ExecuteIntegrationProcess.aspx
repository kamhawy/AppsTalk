<%@ Page Title="Execute Integration Process" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" Async="true" CodeBehind="ExecuteIntegrationProcess.aspx.cs" Inherits="ABATS.AppsTalk.Views.Tools.ExecuteIntegrationProcess" %>

<asp:Content ID="ContentExecuteIntegrationProcesses" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div class="innerPanelContainer">
        <div id="divSelection" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 100%;">
            <div class="MyBoxContents">
                <asp:DropDownList ID="cmbIntegrationProcess" DataSourceID="IntegrationProcessesDataSource"
                    Width="100%" DataTextField="IntegrationProcessTitle" DataValueField="IntegrationProcessID"
                    OnSelectedIndexChanged="cmbIntegrationProcess_SelectedIndexChanged" AutoPostBack="true"
                    AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="Select Integration Process ..." Value="0" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div id="divProcessInfo" visible="false" runat="server">
            <div id="divDescription" class="ShadowBox" style="margin: 5px 0px 5px 0px; width: 100%;">
                <div class="MyBoxContents">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </div>
            </div>
            <div id="divDetails" class="ShadowBox" style="margin: 5px 0px 5px 0px; width: 100%;">
                <div class="MyBoxContents">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td valign="top" style="width: 50%;">
                                <div id="divSourceAdapater" class="ShadowBox" style="width: 100%;">
                                    <div class="ShadowBoxHeaderGray" style="text-align: center; height: 24px;">
                                        <span class="BoxHeaderText">Source Integration Adapter</span>
                                    </div>
                                    <div class="MyBoxContents">
                                        <table id="tbSourceAdapter" border="0" cellpadding="0" cellspacing="0" width="100%"
                                            runat="server">
                                            <tr>
                                                <td class="redTitle" valign="middle" align="center" height="28">
                                                    <strong>
                                                        <asp:Label ID="lblSourceAdapterName" Text="Adapter Name" runat="server"></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" height="160px">
                                                    <asp:Image ID="imgSourceDatabase" ImageUrl="~/Contents/Images/i_database_150.png"
                                                        Width="152px" Height="152px" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center">
                                                    <asp:Label ID="lblSourceAdapterDescription" Text="Adpater description" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                            <td valign="middle">
                                <asp:Image ID="imgDataArrows" ImageUrl="~/Contents/Images/i_dataArrows.png" Width="150px"
                                    Height="142px" runat="server" />
                            </td>
                            <td valign="top" style="width: 50%; padding-right: 2px;">
                                <div id="divDestinationAdpater" class="ShadowBox" style="width: 100%;">
                                    <div class="ShadowBoxHeaderGray" style="text-align: center; height: 24px;">
                                        <span class="BoxHeaderText">Destination Integration Adapter</span>
                                    </div>
                                    <div class="MyBoxContents">
                                        <table id="tbDestinationAdapter" border="0" cellpadding="0" cellspacing="0" width="100%"
                                            runat="server">
                                            <tr>
                                                <td class="redTitle" valign="middle" align="center" height="28">
                                                    <strong>
                                                        <asp:Label ID="lblDestinationAdapterName" Text="Adapter Name" runat="server"></asp:Label></strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center" height="160px">
                                                    <asp:Image ID="Image3" ImageUrl="~/Contents/Images/i_database_150.png" Width="152px"
                                                        Height="152px" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" align="center">
                                                    <asp:Label ID="lblDestinationAdpaterDescription" Text="Adpater description" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="divRunButton" style="width: 100%;">
                <asp:Button ID="btnRun" OnClick="btnRun_Click" Text="Execute Integration Process"
                    CssClass="ExecuteButton" runat="server" />
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="IntegrationProcessesDataSource" runat="server" SelectMethod="GetAllIntegrationProcesses"
        TypeName="ABATS.AppsTalk.Presentation.ExecuteIntegrationProcessPresenter" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing"></asp:ObjectDataSource>
</asp:Content>
