<%@ Page Title="AppsTalk 2.0" Language="C#" MasterPageFile="~/Full.Master" AutoEventWireup="true"
    CodeBehind="~/Default.aspx.cs" Inherits="ABATS.AppsTalk.Default" %>

<%@ Register TagPrefix="AppsTalk" TagName="Home" Src="~/Views/Core/Home.ascx" %>
<asp:Content ID="DefaultPageContent" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <AppsTalk:Home ID="ctrlHome" runat="server">
    </AppsTalk:Home>
</asp:Content>
