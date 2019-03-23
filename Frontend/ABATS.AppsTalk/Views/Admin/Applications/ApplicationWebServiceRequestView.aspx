<%@ Page Title="Application Web Service Request" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" CodeBehind="ApplicationWebServiceRequestView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationWebServiceRequestView" %>

<asp:Content ID="ContentApplicationWebServiceRequestView" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div style="padding: 5px;">
        <div id="divSaveButton" class="divButtonSmall" style="width: 65px;">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                        <asp:Image ID="imgSave" ImageUrl="~/Contents/Images/Actions/i_save.png"
                            Width="16px" Height="16px" runat="server" />
                    </td>
                    <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                        <asp:LinkButton ID="btnSave" CausesValidation="true" ValidationGroup="FormValidationGroup"
                            OnClick="btnSave_Click" Text="Save" CssClass="btnText" runat="server"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divSummary" style="margin: 5px 0px 5px 0px;">
            <asp:ValidationSummary ID="ErrorSummary" runat="server" CssClass="validation" ValidationGroup="FormValidationGroup"></asp:ValidationSummary>
        </div>
        <div id="divApplicationWebService" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;"
            runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Web Service Request Settings
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="ApplicationWebServiceRequestDataSource"
                    DataKeyNames="ApplicationWebServiceRequestID" OnItemInserted="fvMain_ItemInserted" OnItemUpdated="fvMain_ItemUpdated"
                    Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Title
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceRequestTitle" runat="server" Text='<%# Bind("ApplicationWebServiceRequestTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceRequestType" runat="server" Text='<%# Bind("ApplicationWebServiceRequestTypeDescription") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Implementation Type Full Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtAssemblyFullPath" runat="server" Text='<%# Bind("ImplementationTypeFullName") %>' Width="100%"
                                        CssClass="CalibriFont FontSize16" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="40px" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Title
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceRequestTitle" runat="server" Text='<%# Bind("ApplicationWebServiceRequestTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbApplicationWebServiceRequestType" SelectedValue='<%# Bind("ApplicationWebServiceRequestType") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" runat="server">
                                        <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Insert"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Implementation Type Full Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtAssemblyFullPath" runat="server" Text='<%# Bind("ImplementationTypeFullName") %>' Width="100%" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Title
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceRequestTitle" runat="server" Text='<%# Bind("ApplicationWebServiceRequestTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbApplicationWebServiceRequestType" SelectedValue='<%# Bind("ApplicationWebServiceRequestType") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" runat="server">
                                        <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Insert"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Implementation Type Full Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtAssemblyFullPath" runat="server" Text='<%# Bind("ImplementationTypeFullName") %>' Width="100%" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ApplicationWebServiceRequestDataSource" runat="server" SelectMethod="GetApplicationWebServiceRequest"
        InsertMethod="InsertApplicationWebServiceRequest" UpdateMethod="UpdateApplicationWebServiceRequest"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationWebServiceRequestPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationWebServiceRequest" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="ApplicationWebServiceRequestID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
