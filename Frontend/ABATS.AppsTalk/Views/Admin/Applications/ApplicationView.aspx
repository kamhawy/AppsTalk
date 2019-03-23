<%@ Page Title="Application" Language="C#" MasterPageFile="~/Full.Master" AutoEventWireup="true"
    CodeBehind="ApplicationView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationView" %>

<asp:Content ID="ContentApplicationView" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div class="innerPanelContainer">
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
            <asp:ValidationSummary ID="ErrorSummary" runat="server" CssClass="validation" ValidationGroup="FormValidationGroup"></asp:ValidationSummary>
        </div>
        <div id="divBasicInfo" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ImageUrl="~/Contents/Images/generalSettings.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Basic Information
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="ApplicationDataSource" DataKeyNames="ApplicationID"
                    OnItemInserted="fvMain_ItemInserted" OnItemUpdated="fvMain_ItemUpdated" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Title
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtApplicationTitle" runat="server" Text='<%# Eval("ApplicationTitle") %>' Width="100%"
                                        CssClass="CalibriFont FontSize16" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Symbol
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtSymbol" runat="server" Text='<%# Eval("ApplicationSymbol") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">Version
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtVersion" runat="server" Text='<%# Eval("ApplicationVersion") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Provider
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProvider" runat="server" Text='<%# Eval("ApplicationProvider") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">Buisness Area
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtBuisnessArea" runat="server" Text='<%# Eval("ApplicationBuisnessArea") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
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
                                <td class="FormFieldLable" style="width: 100px;">Title
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtApplicationTitle" runat="server" Text='<%# Bind("ApplicationTitle") %>' CausesValidation="true"
                                                    CssClass="CalibriFont FontSize16" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtApplicationTitle" ControlToValidate="txtApplicationTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application Title]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Symbol
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtSymbol" runat="server" Text='<%# Bind("ApplicationSymbol") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Version
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtVersion" runat="server" Text='<%# Bind("ApplicationVersion") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Provider
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProvider" runat="server" Text='<%# Bind("ApplicationProvider") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Buisness Area
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtBuisnessArea" runat="server" Text='<%# Bind("ApplicationBuisnessArea") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
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
                                <td class="FormFieldLable" style="width: 100px;">Name
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtApplicationTitle" runat="server" Text='<%# Bind("ApplicationTitle") %>' CausesValidation="true"
                                                    CssClass="CalibriFont FontSize16" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtApplicationTitle" ControlToValidate="txtApplicationTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application Title]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Symbol
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtSymbol" runat="server" Text='<%# Bind("ApplicationSymbol") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">Version
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtVersion" runat="server" Text='<%# Bind("ApplicationVersion") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Provider
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProvider" runat="server" Text='<%# Bind("ApplicationProvider") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable">Buisness Area
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtBuisnessArea" runat="server" Text='<%# Bind("ApplicationBuisnessArea") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
        <div id="divApplicationEndPoints" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;"
            runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image1" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Application End-Points
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td style="width: 50%; padding-right: 5px;" valign="top">
                            <div id="divAddDatabaseButton" class="divButtonSmall" style="width: 135px; margin-bottom: 5px; padding-right: 7px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                                            <asp:Image ID="imgAdd" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                                                Height="16px" runat="server" />
                                        </td>
                                        <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                            <span id="spanAddDatabase" class="btnText" onclick="WindowUtilities.ShowApplicationDatabaseView(-1, <%= this.Presenter.EntityID %>, 'Add');">Add Database
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="dgvApplicationDatabases" runat="server" DataSourceID="ApplicationDatabasesDataSource"
                                AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                                CellPadding="3" BorderStyle="Solid" BorderColor="#E7E7FF" DataKeyNames="ApplicationDatabaseID"
                                Width="100%" CssClass="GridFonts">
                                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                                <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
                                <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                                    BackColor="#4A3C8C"></HeaderStyle>
                                <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                                <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px" BorderColor="#D7D7D7"></RowStyle>
                                <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="&nbsp;..." HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <img src="<%= ResolveUrl("~") %>/Contents/Images/i_edit.gif" alt="Edit" onclick="WindowUtilities.ShowApplicationDatabaseView(<%# Eval("ApplicationDatabaseID") %>, <%# Eval("ApplicationID") %>, 'Edit');"
                                                style="cursor: pointer; margin-left: 5px;" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ApplicationDatabaseTitle" HeaderText="Title" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="ApplicationDatabaseTitle" />
                                    <asp:BoundField DataField="ApplicationDatabaseTypeDescription" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="ApplicationDatabaseTypeDescription" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="Description" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="width: 50%; border-left: solid 1px #B3C1D5; padding-left: 5px;" valign="top">
                            <div id="divAddWebServiceButton" class="divButtonSmall" style="width: 140px; margin-bottom: 5px; padding-right: 7px;">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                                                Height="16px" runat="server" />
                                        </td>
                                        <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                            <span id="spanAddWebService" class="btnText" onclick="WindowUtilities.ShowApplicationWebServiceView(-1, <%= this.Presenter.EntityID %>, 'Add');">Add Web Service
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="dgvApplicationWebServices" runat="server" DataSourceID="ApplicationWebServicesDataSource"
                                AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                                CellPadding="3" BorderStyle="Solid" BorderColor="#E7E7FF" DataKeyNames="ApplicationWebServiceID"
                                Width="100%" CssClass="GridFonts">
                                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                                <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
                                <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                                    BackColor="#4A3C8C"></HeaderStyle>
                                <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                                <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px" BorderColor="#D7D7D7"></RowStyle>
                                <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="&nbsp;..." HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <img src="<%= ResolveUrl("~") %>/Contents/Images/i_edit.gif" alt="Edit" onclick="WindowUtilities.ShowApplicationWebServiceView(<%# Eval("ApplicationWebServiceID") %>, <%# Eval("ApplicationID") %>, 'Edit');"
                                                style="cursor: pointer; margin-left: 5px;" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ApplicationWebServiceTitle" HeaderText="Title" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="ApplicationWebServiceTitle" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                        SortExpression="Description" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ApplicationDataSource" runat="server" SelectMethod="GetApplication"
        InsertMethod="InsertApplication" UpdateMethod="UpdateApplication" TypeName="ABATS.AppsTalk.Presentation.ApplicationPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.Application" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="ApplicationID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ApplicationDatabasesDataSource" runat="server" SelectMethod="GetApplicationDatabases"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationDatabas"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pApplicationID" QueryStringField="ApplicationID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ApplicationWebServicesDataSource" runat="server" SelectMethod="GetApplicationWebServices"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationWebService"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pApplicationID" QueryStringField="ApplicationID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
