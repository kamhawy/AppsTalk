<%@ Page Title="Integration Transaction Details" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="IntegrationTransactionDetailsView.aspx.cs"
    Inherits="ABATS.AppsTalk.Views.Tools.IntegrationTransactionDetailsView" %>

<asp:Content ID="ContentIntegrationTransactionDetailsView" ContentPlaceHolderID="MainContentPlaceHolder"
    runat="server">
    <style type="text/css">
        #wrap
        {
            width: 100% !important;
        }
    </style>
    <div id="divInnerContainer" class="innerPanelContainer">
        <asp:GridView ID="dgvList" runat="server" DataSourceID="IntegrationTransactionDetailsDataSource"
            AutoGenerateColumns="true" BorderWidth="1px" BackColor="White" GridLines="Both"
            CellPadding="3" BorderStyle="Solid" BorderColor="#E7E7FF" DataKeyNames="ID" Width="100%"
            CssClass="GridFonts">
            <FooterStyle Height="26px" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
            <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
            <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                BackColor="#4A3C8C" CssClass="GridDynamicHeader"></HeaderStyle>
            <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
            <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px"
                BorderColor="#D7D7D7"></RowStyle>
            <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7">
            </AlternatingRowStyle>
            <EmptyDataTemplate>
                <div class="NoRecords">
                    .. No Integration Process History Details available ..
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="IntegrationTransactionDetailsDataSource" runat="server"
        SelectMethod="GetIntegrationTransactionDetails" TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessHistoryPresenter"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationTransactionID" QueryStringField="IntegrationTransactionID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
