<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ControlsContainer.aspx.cs" Inherits="ABATS.AppsTalk.Views.Core.ControlsContainer" %>

<asp:Content ID="ControlsContainerContents" ContentPlaceHolderID="MainContentPlaceHolder"
    runat="server">
    <style type="text/css">
        #wrap
        {
            width: 100% !important;
        }
    </style>
    <div id="divSummary" style="margin: 5px;">
        <asp:ValidationSummary ID="ErrorSummary" runat="server" CssClass="validation" ValidationGroup="ValidGroup">
        </asp:ValidationSummary>
    </div>
    <asp:Panel ID="panelControlsContainer" CssClass="GenericControlContainerPanel" runat="server">
    </asp:Panel>
</asp:Content>
