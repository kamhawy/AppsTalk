<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IntegrationProcessCompactView.ascx.cs"
    Inherits="ABATS.AppsTalk.Views.Admin.IntegrationProcesses.IntegrationProcessCompactView" %>
<div id="divIntegrationProcessInfo" class="ShadowBox" style="margin: 5px 5px 5px 5px;
    width: 1087px;">
    <div class="MyBoxContents">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HyperLink ID="hllIntegrationProcessTitle" runat="server" Text="<%# this.DataObject.IntegrationProcessTitle %>"
                        NavigateUrl='<%# String.Format("~/Views/Admin/IntegrationProcesses/IntegrationProcessView.aspx?IntegrationProcessID={0}&UIMode=Edit", this.DataObject.IntegrationProcessID) %>'></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="ItemDescriptionSmallText" style="padding-top: 5px; padding-left: 10px;">
                    <asp:Label ID="lblDescription" Text="<%# this.DataObject.Description %>" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</div>
