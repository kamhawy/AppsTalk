<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicationCompactView.ascx.cs"
    Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationCompactView" %>

<div id="divAppInfo" class="ShadowBox" style="margin: 5px 5px 5px 5px; width: 1087px;">
    <div class="MyBoxContents">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HyperLink ID="hllApplicationName" runat="server" Text="<%# this.DataObject.ApplicationName %>"
                        NavigateUrl='<%# String.Format("~/Views/Admin/Applications/ApplicationView.aspx?ApplicationID={0}&UIMode=Edit", this.DataObject.ApplicationID) %>'></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="ItemDescriptionSmallText" style="padding-top: 5px;">
                    <asp:Label ID="lblDescription" Text="<%# this.DataObject.Description %>" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</div>
