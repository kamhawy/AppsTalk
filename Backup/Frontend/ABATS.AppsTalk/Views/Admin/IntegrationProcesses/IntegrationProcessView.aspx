<%@ Page Title="Integration Processes" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" CodeBehind="IntegrationProcessView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.IntegrationProcesses.IntegrationProcessView" %>

<asp:Content ID="ContentIntegrationProcessView" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div id="divInnerContainer" class="innerPanelContainer">
        <div id="divSaveButton" class="divButtonSmall" style="width: 65px;">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                        <asp:Image ID="Image4" ImageUrl="~/Contents/Images/Actions/i_save.png" Width="16px"
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
                            Basic Information
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="IntegrationProcessDataSource"
                    DataKeyNames="IntegrationProcessID" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtIntegrationProcessTitle" runat="server" Text='<%# Eval("IntegrationProcessTitle") %>'
                                        CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    Code
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtIntegrationProcessCode" runat="server" Text='<%# Eval("IntegrationProcessCode") %>'
                                        Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
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
                                <td class="FormFieldLable" style="width: 100px;">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationProcessTitle" runat="server" Text='<%# Bind("IntegrationProcessTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationProcessTitle" ControlToValidate="txtIntegrationProcessTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Process Name]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    Code
                                </td>
                                <td class="FormFieldInput">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationProcessCode" runat="server" Text='<%# Bind("IntegrationProcessCode") %>'
                                                    Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldIntegrationProcessCode" ControlToValidate="txtIntegrationProcessCode"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Process Code]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Description
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                                        Width="100%" TextMode="MultiLine" Height="40px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Name
                                </td>
                                <td class="FormFieldInput">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationProcessTitle" runat="server" Text='<%# Bind("IntegrationProcessTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationProcessTitle" ControlToValidate="txtIntegrationProcessTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Process Name]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    Code
                                </td>
                                <td class="FormFieldInput">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationProcessCode" runat="server" Text='<%# Bind("IntegrationProcessCode") %>'
                                                    Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldIntegrationProcessCode" ControlToValidate="txtIntegrationProcessCode"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Process Code]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
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
        <div id="divApplicationEndPoints" class="ShadowBox" style="margin: 0px 0px 5px 0px;
            width: 99.8%;" runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">
                            Integration Process Adapters
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="top" style="width: 50%;">
                            <div id="divSourceAdapater" class="ShadowBox" style="width: 100%;">
                                <div class="ShadowBoxHeaderGray" style="text-align: center; height: 24px;">
                                    <span class="BoxHeaderText">Source Integration Adapter</span>
                                </div>
                                <div class="MyBoxContents">
                                    <table id="tbSourceAdapter" border="0" cellpadding="0" cellspacing="0" width="100%"
                                        visible="false" runat="server">
                                        <tr>
                                            <td valign="middle" align="center" height="28">
                                                <strong>
                                                    <asp:Label ID="lblSourceAdapterName" CssClass="redTitle" Text="Adapter Name" runat="server"></asp:Label>
                                                </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" align="center" height="160px">
                                                <asp:Image ID="imgSourceDatabase" ImageUrl="~/Contents/Images/i_database_150.png"
                                                    Width="152px" Height="152px" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" align="center">
                                                <asp:Label ID="lblSourceAdapterDescription" Text="Adpater description" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divAddSourceAdapter" runat="server">
                                        <div class="divButton" onclick="ShowIntegrationAdapterView(-1, 'Add', <%= this.Presenter.EntityID %>, 1)">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center" valign="middle" style="padding-left: 5px">
                                                        <asp:Image ID="imgAddSourceAdapter" ImageUrl="~/Contents/Images/i_adapter.gif" Width="48px"
                                                            Height="46px" runat="server" />
                                                    </td>
                                                    <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                                        Add Source Integration Adapter
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td valign="middle">
                            <asp:Image ID="imgDataArrows" ImageUrl="~/Contents/Images/i_dataArrows.png" Width="150px"
                                Height="142px" runat="server" />
                            <center style="margin-top: 10px;">
                                <asp:Label ID="lblMapping" CssClass="MappingText" Text="Mapping" runat="server"></asp:Label>
                            </center>
                        </td>
                        <td valign="top" style="width: 50%; padding-right: 2px;">
                            <div id="divDestinationAdpater" class="ShadowBox" style="width: 100%;">
                                <div class="ShadowBoxHeaderGray" style="text-align: center; height: 24px;">
                                    <span class="BoxHeaderText">Destination Integration Adapter</span>
                                </div>
                                <div class="MyBoxContents">
                                    <table id="tbDestinationAdapter" border="0" cellpadding="0" cellspacing="0" width="100%"
                                        visible="false" runat="server">
                                        <tr>
                                            <td valign="middle" align="center" height="28">
                                                <strong>
                                                    <asp:Label ID="lblDestinationAdapterName" CssClass="redTitle" Text="Adapter Name" runat="server"></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" align="center" height="160px">
                                                <asp:Image ID="Image3" ImageUrl="~/Contents/Images/i_database_150.png" Width="152px"
                                                    Height="152px" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" align="center">
                                                <asp:Label ID="lblDestinationAdpaterDescription" Text="Adpater description" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divAddDestinationAdapter" runat="server">
                                        <div class="divButton" onclick="ShowIntegrationAdapterView(-1, 'Add', <%= this.Presenter.EntityID %>, 2)">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center" valign="middle" style="padding-left: 5px">
                                                        <asp:Image ID="Image5" ImageUrl="~/Contents/Images/i_adapter.gif" Width="48px" Height="46px"
                                                            runat="server" />
                                                    </td>
                                                    <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                                        Add Destination Integration Adapter
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="IntegrationProcessDataSource" runat="server" SelectMethod="GetIntegrationProcess"
        InsertMethod="InsertIntegrationProcess" UpdateMethod="UpdateIntegrationProcess"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationProcess"
        OnInserted="ObjectDataSource_Inserted" OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="IntegrationProcessID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
