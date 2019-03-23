<%@ Page Title="Application Database Query" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="ApplicationDatabaseQueryView.aspx.cs"
    Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationDatabaseQueryView" %>

<asp:Content ID="ContentApplicationDatabaseQueryView" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div id="divInnerContainer" class="innerPanelContainer">
        <div id="divSaveButton" class="divButtonSmall" style="width: 65px;">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                        <asp:Image ID="imgSave" ImageUrl="~/Contents/Images/Actions/i_save.png" Width="16px"
                            Height="16px" runat="server" />
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
                            <asp:Image ID="Image1" ImageUrl="~/Contents/Images/generalSettings.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Basic Information
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="ApplicationDatabaseQueryDataSource"
                    DataKeyNames="ApplicationDatabaseQueryID" OnItemInserted="fvMain_ItemInserted" OnItemUpdated="fvMain_ItemUpdated" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Title
                                </td>
                                <td class="FormFieldInput" style="width: 65%;">
                                    <asp:TextBox ID="txtApplicationDatabaseQueryTitle" runat="server" Text='<%# Eval("ApplicationDatabaseQueryTitle") %>'
                                        CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%" ReadOnly="true" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Type
                                </td>
                                <td class="FormFieldInput" style="width: 35%;">
                                    <asp:Label ID="lblApplicationDatabaseQueryType" Text='<%# Eval("ApplicationDatabaseQueryTypeDescription") %>'
                                        CssClass="CalibriFont FontSize16" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput" style="width: 65%;">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Database
                                </td>
                                <td class="FormFieldInput" style="width: 35%;">
                                    <asp:Label ID="lblApplicationDatabaseTitle" Text='<%# Eval("ApplicationDatabaseTitle") %>'
                                        CssClass="CalibriFont FontSize16" runat="server"></asp:Label>
                                </td>

                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldInput" colspan="4">
                                    <asp:TextBox ID="txtApplicationDatabaseQueryCommand" runat="server" Text='<%# Eval("ApplicationDatabaseQueryCommand") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" TextMode="MultiLine" Height="380px" ReadOnly="true">
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
                                <td class="FormFieldInput" style="width: 65%;">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtApplicationDatabaseQueryTitle" runat="server" Text='<%# Bind("ApplicationDatabaseQueryTitle") %>'
                                                    CssClass="CalibriFont FontSize16" CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtApplicationDatabaseQueryTitle" ControlToValidate="txtApplicationDatabaseQueryTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application Database Query Title]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                                <td class="FormFieldLable" style="width: 100px;">Type
                                </td>
                                <td class="FormFieldInput" style="width: 35%;">
                                    <asp:DropDownList ID="cmbApplicationDatabaseQueryType" SelectedValue='<%# Bind("ApplicationDatabaseQueryType") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" runat="server">
                                        <asp:ListItem Value="1" Text="Select Query" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Insert Query"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput" style="width: 65%;">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Database
                                </td>
                                <td class="FormFieldInput" style="width: 35%;">
                                    <asp:Label ID="lblApplicationDatabaseTitle" Text='<%# Eval("ApplicationDatabaseTitle") %>'
                                        CssClass="CalibriFont FontSize16" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldInput" style="width: 100px;" colspan="4">
                                    <asp:TextBox ID="txtApplicationDatabaseQueryCommand" runat="server" Text='<%# Bind("ApplicationDatabaseQueryCommand") %>'
                                        Width="100%" TextMode="MultiLine" Height="380px" Font-Names="Consolas" Font-Size="13px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px;" colspan="4">
                                    <asp:RequiredFieldValidator ID="RequiredFieldtxtApplicationDatabaseQueryCommand" ControlToValidate="txtApplicationDatabaseQueryCommand"
                                        ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application Database Query Command]</b> is a Required Field !"
                                        Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Title
                                </td>
                                <td class="FormFieldInput" style="width: 65%;">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtApplicationDatabaseQueryTitle" runat="server" Text='<%# Bind("ApplicationDatabaseQueryTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%" CssClass="CalibriFont FontSize16">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtApplicationDatabaseQueryTitle" ControlToValidate="txtApplicationDatabaseQueryTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application Database Query Title]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">Type
                                </td>
                                <td class="FormFieldInput" style="width: 35%;">
                                    <asp:DropDownList ID="cmbApplicationDatabaseQueryType" SelectedValue='<%# Bind("ApplicationDatabaseQueryType") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" runat="server">
                                        <asp:ListItem Value="1" Text="Select Query" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Insert Query"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldInput" style="width: 100px;" colspan="2">
                                    <asp:TextBox ID="txtApplicationDatabaseQueryCommand" runat="server" Text='<%# Bind("ApplicationDatabaseQueryCommand") %>'
                                        Width="100%" TextMode="MultiLine" Height="380px" Font-Names="Consolas" Font-Size="13px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px;" colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldtxtApplicationDatabaseQueryCommand" ControlToValidate="txtApplicationDatabaseQueryCommand"
                                        ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application Database Query Command]</b> is a Required Field !"
                                        Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ApplicationDatabaseQueryDataSource" runat="server" SelectMethod="GetApplicationDatabaseQuery"
        InsertMethod="InsertApplicationDatabaseQuery" UpdateMethod="UpdateApplicationDatabaseQuery"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationDatabaseQueryPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationDatabaseQuery"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="ApplicationDatabaseQueryID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
