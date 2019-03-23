<%@ Page Title="Application Database" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" CodeBehind="ApplicationDatabaseView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationDatabaseView" %>

<asp:Content ID="ContentApplicationDatabaseView" ContentPlaceHolderID="FullContentPlaceHolder"
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
        <div id="divApplicationDatabase" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Database Settings
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="ApplicationDatabaseDataSource"
                    DataKeyNames="ApplicationDatabaseID" OnItemInserted="fvMain_ItemInserted" OnItemUpdated="fvMain_ItemUpdated" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Title
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationDatabaseTitle" runat="server" Text='<%# Eval("ApplicationDatabaseTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ApplicationDatabaseTypeDescription") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Metadata
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtMetadata" runat="server" Text='<%# Eval("Metadata") %>' Width="100%"
                                        CssClass="CalibriFont FontSize16" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Provider
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Eval("ProviderName") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Connection
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtConnectionString" runat="server" Text='<%# Eval("ProviderConnectionString") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="40px" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
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
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationDatabaseTitle" runat="server" Text='<%# Bind("ApplicationDatabaseTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbApplicationDatabaseType" Width="100%" SelectedValue='<%# Bind("ApplicationDatabaseType") %>'
                                        CssClass="CalibriFont FontSize16" runat="server">
                                        <asp:ListItem Value="2" Text="Oracle" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="SQL Server"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="MySQL"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Sybase"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Metadata
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtMetadata" runat="server" Text='<%# Bind("Metadata") %>' Width="100%" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Provider
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Bind("ProviderName") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Connection
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtConnectionString" runat="server" Text='<%# Bind("ProviderConnectionString") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="50px">
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
                                <td class="FormFieldLable" style="width: 100px;">Title
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationDatabaseTitle" runat="server" Text='<%# Bind("ApplicationDatabaseTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbApplicationDatabaseType" Width="100%" SelectedValue='<%# Bind("ApplicationDatabaseType") %>'
                                        CssClass="CalibriFont FontSize16" runat="server">
                                        <asp:ListItem Value="2" Text="Oracle" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="SQL Server"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="MySQL"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Sybase"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Metadata
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtMetadata" runat="server" Text='<%# Bind("Metadata") %>' Width="100%" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Provider
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtProviderName" runat="server" Text='<%# Bind("ProviderName") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Connection
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtConnectionString" runat="server" Text='<%# Bind("ProviderConnectionString") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="50px">
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
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
        <div id="divApplicationDatabaseQueries" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;"
            runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image1" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Database Queries
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <div id="divAddButton" class="divButtonSmall" style="width: 125px; margin-bottom: 5px;" onclick="WindowUtilities.ShowApplicationDatabaseQueryView(-1, <%= this.Presenter.EntityID %>, 'Add');">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                                <asp:Image ID="imgAdd" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                                    Height="16px" runat="server" />
                            </td>
                            <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                <span id="spanAddDatabase" class="btnText">Add Query
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="dgvList" runat="server" DataSourceID="ApplicationDatabaseQueriesDataSource"
                    AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                    CellPadding="3" BorderStyle="Solid" BorderColor="#D7D7D7" DataKeyNames="ApplicationDatabaseQueryID"
                    Width="100%" CssClass="GridFonts">
                    <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                    <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
                    <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                        BackColor="#4A3C8C" BorderWidth="1px" BorderColor="#D7D7D7"></HeaderStyle>
                    <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                    <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px"
                        BorderColor="#D7D7D7"></RowStyle>
                    <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="&nbsp;..." HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <img src="<%= ResolveUrl("~") %>/Contents/Images/i_edit.gif" alt="Edit" onclick="WindowUtilities.ShowApplicationDatabaseQueryView(<%# Eval("ApplicationDatabaseQueryID") %>, <%= this.Presenter.EntityID %>, 'Edit');"
                                    style="cursor: pointer; margin-left: 5px;" title="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApplicationDatabaseQueryTitle" HeaderText="Title" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="ApplicationDatabaseQueryTitle" />
                        <asp:BoundField DataField="ApplicationDatabaseQueryTypeDescription" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="ApplicationDatabaseQueryTypeDescription" />
                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="Description" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ApplicationDatabaseDataSource" runat="server" SelectMethod="GetApplicationDatabase"
        InsertMethod="InsertApplicationDatabase" UpdateMethod="UpdateApplicationDatabase"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationDatabasePresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationDatabas"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="ApplicationDatabaseID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ApplicationDatabaseQueriesDataSource" runat="server" SelectMethod="GetApplicationDatabaseQueries"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationDatabasePresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationDatabaseQuery"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pApplicationDatabaseID" QueryStringField="ApplicationDatabaseID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
