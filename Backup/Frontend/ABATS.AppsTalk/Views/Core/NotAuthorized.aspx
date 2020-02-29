<%@ Page Title="ABATS.AppsTalk - Authorization Error" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Main.Master" CodeBehind="NotAuthorized.aspx.cs" Inherits="ABATS.AppsTalk.Views.Core.NotAuthorized" %>

<%@ Register TagPrefix="AppsTalk" TagName="AuthorizationError" Src="~/Views/Core/AuthorizationError.ascx" %>
<asp:Content ID="ContentNotAuthorized" ContentPlaceHolderID="MainContentPlaceHolder"
    runat="server">
    <style type="text/css">
        #wrap
        {
            width: 100% !important;
        }
    </style>
    <AppsTalk:AuthorizationError ID="ctrlAuthorizationError" runat="server" />
</asp:Content>