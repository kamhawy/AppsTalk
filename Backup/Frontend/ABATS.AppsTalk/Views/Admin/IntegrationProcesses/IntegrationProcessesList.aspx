<%@ Page Title="Integration Processes" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" CodeBehind="IntegrationProcessesList.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.IntegrationProcesses.IntegrationProcessesList" %>

<%@ Register TagPrefix="AppsTalk" TagName="IntegrationProcessCompactView" Src="~/Views/Admin/IntegrationProcesses/IntegrationProcessCompactView.ascx" %>
<asp:Content ID="ContentIntegrationProcessesList" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div id="divAddButton" class="divButtonSmall" style="width: 185px; margin: 5px 5px 0px 5px;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                    <asp:Image ID="imgAdd" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                        Height="16px" runat="server" />
                </td>
                <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                    <asp:LinkButton ID="btnAdd" OnClick="btnAdd_Click" Text="Add Integration Process"
                        CssClass="btnText" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div id="divList">
        <asp:GridView ID="dgvList" runat="server" DataSourceID="IntegrationProcessesDataSource"
            AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
            CellPadding="3" BorderStyle="None" BorderColor="#E7E7FF" ShowHeader="false" ShowFooter="false"
            PagerSettings-Visible="false" DataKeyNames="IntegrationProcessID">
            <Columns>
                <asp:TemplateField HeaderText="IntegrationProcess">
                    <ItemTemplate>
                        <AppsTalk:IntegrationProcessCompactView ID="ctrlIntegrationProcessCompactView" DataObject='<%# Container.DataItem  %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="IntegrationProcessesDataSource" runat="server" SelectMethod="GetAllIntegrationProcesses"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessPresenter" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing"></asp:ObjectDataSource>
</asp:Content>
