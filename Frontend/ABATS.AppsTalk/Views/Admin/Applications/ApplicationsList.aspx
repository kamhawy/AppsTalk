<%@ Page Title="Applications" Language="C#" MasterPageFile="~/Full.Master" AutoEventWireup="true"
    CodeBehind="ApplicationsList.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationsList" %>

<%@ Register TagPrefix="AppsTalk" TagName="AppCompactView" Src="~/Views/Admin/Applications/ApplicationCompactView.ascx" %>
<asp:Content ID="ContentApplicationsList" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div id="divAddButton" class="divButtonSmall" style="width: 140px; margin: 5px 5px 0px 5px;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                    <asp:Image ID="imgAdd" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                        Height="16px" runat="server" />
                </td>
                <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                    <asp:LinkButton ID="btnAdd" OnClick="btnAdd_Click" Text="Add Application" CssClass="btnText"
                        runat="server"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div id="divList">
        <asp:GridView ID="dgvList" runat="server" DataSourceID="ApplicationsDataSource" AutoGenerateColumns="False"
            BorderWidth="1px" BackColor="White" GridLines="Horizontal" CellPadding="3" BorderStyle="None"
            BorderColor="#E7E7FF" ShowHeader="false" ShowFooter="false" AllowPaging="false"
            DataKeyNames="ApplicationID" CssClass="ApplicationsGrid">
            <Columns>
                <asp:TemplateField HeaderText="Application">
                    <ItemTemplate>
                        <AppsTalk:AppCompactView ID="ctrlAppCompactView" DataObject='<%# Container.DataItem  %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource ID="ApplicationsDataSource" runat="server" SelectMethod="GetAllApplications"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationPresenter" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing"></asp:ObjectDataSource>
</asp:Content>
