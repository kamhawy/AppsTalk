<%@ Page Title="Application End-Point" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="ApplicationEndPointView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationEndPointView" %>

<asp:Content ID="ContentApplicationEndPointView" ContentPlaceHolderID="MainContentPlaceHolder"
    runat="server">
    <style type="text/css">
        #wrap
        {
            width: 100% !important;
        }
    </style>
    <div style="padding: 5px;">
        <div id="divSaveButton" class="divButtonSmall" style="width: 65px;">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                        <asp:Image ID="imgAddSourceAdapter" ImageUrl="~/Contents/Images/Actions/i_save.png"
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
            <asp:ValidationSummary ID="ErrorSummary" runat="server" CssClass="validation" ValidationGroup="FormValidationGroup">
            </asp:ValidationSummary>
        </div>
        <div id="divBasicInfo" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image1" ImageUrl="~/Contents/Images/generalSettings.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">
                            End-Point Information
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="ApplicationEndPointDataSource"
                    DataKeyNames="ApplicationEndPointID" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("ApplicationEndPointTitle") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtSymbol" runat="server" Text='<%# Eval("ApplicationEndPointTypeName") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("ApplicationEndPointTitle") %>'
                                        Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbApplicationEndPointType" SelectedValue='<%# Bind("ApplicationEndPointType") %>'
                                        Width="100%" OnSelectedIndexChanged="cmbApplicationEndPointType_SelectedIndexChanged"
                                        AutoPostBack="true" runat="server">
                                        <asp:ListItem Value="1" Text="Database" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Web Service"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfDBConnectionID" Value='<%# Bind("DBConnectionID") %>' runat="server" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("ApplicationEndPointTitle") %>'
                                        Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbApplicationEndPointType" SelectedValue='<%# Bind("ApplicationEndPointType") %>'
                                        Width="100%" OnSelectedIndexChanged="cmbApplicationEndPointType_SelectedIndexChanged"
                                        AutoPostBack="true" runat="server">
                                        <asp:ListItem Value="1" Text="Database" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Web Service"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
        <div id="divDBConnection" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;"
            runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">
                            Database Settings
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvDBConnection" runat="server" DataSourceID="DBConnectionDataSource"
                    DataKeyNames="DBConnectionID" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtDBConnectionName" runat="server" Text='<%# Bind("DBConnectionName") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DBConnectionTypeName") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Metadata
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtMetadata" runat="server" Text='<%# Bind("Metadata") %>' Width="100%"
                                        ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">
                                    Provider Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Bind("ProviderName") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Connection
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtConnectionString" runat="server" Text='<%# Bind("ProviderConnectionString") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtDBConnectionName" runat="server" Text='<%# Bind("DBConnectionName") %>'
                                        Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbDBConnectionType" Width="100%" SelectedValue='<%# Bind("DBConnectionType") %>'
                                        runat="server">
                                        <asp:ListItem Value="2" Text="Oracle" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="SQLServer"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="MySQL"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Sybase"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Metadata
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtMetadata" runat="server" Text='<%# Bind("Metadata") %>' Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">
                                    Provider Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Bind("ProviderName") %>'
                                        Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Connection
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtConnectionString" runat="server" Text='<%# Bind("ProviderConnectionString") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtDBConnectionName" runat="server" Text='<%# Bind("DBConnectionName") %>'
                                        Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbDBConnectionType" Width="100%" SelectedValue='<%# Bind("DBConnectionType") %>'
                                        runat="server">
                                        <asp:ListItem Value="2" Text="Oracle" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="SQLServer"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="MySQL"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Sybase"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Metadata
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtMetadata" runat="server" Text='<%# Bind("Metadata") %>' Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">
                                    Provider Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Bind("ProviderName") %>'
                                        Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">
                                    Connection
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtConnectionString" runat="server" Text='<%# Bind("ProviderConnectionString") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ApplicationEndPointDataSource" runat="server" SelectMethod="GetApplicationEndPoint"
        InsertMethod="InsertApplicationEndPoint" UpdateMethod="UpdateApplicationEndPoint"
        OnInserted="ObjectDataSource_Inserted" TypeName="ABATS.AppsTalk.Presentation.ApplicationEndPointPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationEndPoint" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="ApplicationEndPointID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DBConnectionDataSource" runat="server" SelectMethod="GetDBConnection"
        InsertMethod="InsertDBConnection" UpdateMethod="UpdateDBConnection" OnInserted="DBConnectionDataSource_Inserted"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationEndPointPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.DBConnection"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pApplicationEndPointID" QueryStringField="ApplicationEndPointID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
