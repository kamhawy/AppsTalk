<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ABATS.AppsTalk.Views.Core.Header" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
    <tr>
        <td valign="middle" style="width: 75px;">
            <div style="margin-left: 7px; margin-top:4px; vertical-align: middle;">
                <asp:HyperLink ID="hlHeaderImage" ImageUrl="~/Contents/Images/Logo_60.png" NavigateUrl="~/Default.aspx"
                    CssClass="header_image" runat="server"></asp:HyperLink>
            </div>
        </td>
        <td valign="middle" style="width: 500px;">
            <div class="SystemNameText" style="margin-left: 5px;">
                AppsTalk Integration System
            </div>
        </td>
        <td valign="middle" align="right">
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="UserNameText">
                        <asp:Label ID="lblCurrentUser" runat="server">
                        </asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="UserInfoText" align="center">
                        <asp:Label ID="lblDefaultRole" runat="server">
                        </asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
