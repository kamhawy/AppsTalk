<%@ Page Title="Integration Adapter Query" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="IntegrationAdapterQueryView.aspx.cs"
    Inherits="ABATS.AppsTalk.Views.Admin.IntegrationProcesses.IntegrationAdapterQueryView" %>

<asp:Content ID="ContentIntegrationAdapterQueryView" ContentPlaceHolderID="MainContentPlaceHolder"
    runat="server">
    <style type="text/css">
        #wrap
        {
            width: 100% !important;
        }
    </style>
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
                <asp:FormView ID="fvMain" runat="server" DataSourceID="IntegrationAdapterQueryDataSource"
                    DataKeyNames="IntegrationAdapterQueryID" OnItemUpdating="fvMain_ItemUpdating"
                    OnItemInserting="fvMain_ItemInserting" OnItemInserted="fvMain_ItemInserted" Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Name
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtIntegrationAdapterQueryTitle" runat="server" Text='<%# Eval("IntegrationAdapterQueryTitle") %>'
                                        CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:Label ID="lblIntegrationAdapterQueryType" Text='<%# Eval("IntegrationAdapterQueryTypeName") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    Ref. Query
                                </td>
                                <td class="FormFieldInput">
                                    <asp:Label ID="lblRefIntegrationAdapterQueryName" Text='<%# Eval("RefIntegrationAdapterQueryTitle") %>'
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Query Text
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <asp:TextBox ID="txtIntegrationAdapterQueryText" runat="server" Text='<%# Eval("IntegrationAdapterQueryText") %>'
                                        Width="100%" TextMode="MultiLine" Height="200px" ReadOnly="true">
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
                                <td class="FormFieldInput" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationAdapterQueryTitle" runat="server" Text='<%# Bind("IntegrationAdapterQueryTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationAdapterQueryTitle" ControlToValidate="txtIntegrationAdapterQueryTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Adapter Query Name]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbIntegrationAdapterQueryType" SelectedValue='<%# Bind("IntegrationAdapterQueryType") %>'
                                        Width="100%" runat="server">
                                        <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Insert"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    Ref. Query
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbRefQuery" SelectedValue='<%# Bind("RefIntegrationAdapterQueryID") %>'
                                        Width="100%" DataSourceID="RefIntegrationAdapterQueryObjectDataSource" DataTextField="IntegrationAdapterQueryTitle"
                                        DataValueField="IntegrationAdapterQueryID" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text="Select Ref. Query" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldInput" colspan="4">
                                    <div style="margin-bottom: 4px; font-weight: bold;">
                                        Query Text</div>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationAdapterQueryText" runat="server" Text='<%# Bind("IntegrationAdapterQueryText") %>'
                                                    Width="100%" TextMode="MultiLine" Height="400px" Font-Names="Consolas" Font-Size="13px">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationAdapterQueryText" ControlToValidate="txtIntegrationAdapterQueryText"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Adapter Query Text]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
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
                                <td class="FormFieldInput" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationAdapterQueryTitle" runat="server" Text='<%# Bind("IntegrationAdapterQueryTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationAdapterQueryTitle" ControlToValidate="txtIntegrationAdapterQueryTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Adapter Query Name]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Type
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbIntegrationAdapterQueryType" SelectedValue='<%# Bind("IntegrationAdapterQueryType") %>'
                                        Width="100%" runat="server">
                                        <asp:ListItem Value="1" Text="Select" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Insert"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    Ref. Query
                                </td>
                                <td class="FormFieldInput">
                                    <asp:DropDownList ID="cmbRefQuery" SelectedValue='<%# Bind("RefIntegrationAdapterQueryID") %>'
                                        Width="100%" DataSourceID="RefIntegrationAdapterQueryObjectDataSource" DataTextField="IntegrationAdapterQueryTitle"
                                        DataValueField="IntegrationAdapterQueryID" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="" Text="Select Ref. Query" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable" style="width: 100px;">
                                    Query Text
                                </td>
                                <td class="FormFieldInput" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationAdapterQueryText" runat="server" Text='<%# Bind("IntegrationAdapterQueryText") %>'
                                                    Width="100%" TextMode="MultiLine" Height="400px" Font-Names="Consolas" Font-Size="13px">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationAdapterQueryText" ControlToValidate="txtIntegrationAdapterQueryText"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Adapter Query Text]</b> is a Required Field !"
                                                    Text="*" InitialValue="" Display="Dynamic" ForeColor="Red" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
        <div id="divIntegrationApdaterQueryFields" class="ShadowBox" style="margin: 0px 0px 5px 0px;
            width: 99.8%;" runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">
                            Adapter Queries Fields
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <div id="divAddButton" class="divButtonSmall" style="width: 65px; margin-bottom: 5px;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                                <asp:Image ID="imgAdd" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                                    Height="16px" runat="server" />
                            </td>
                            <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                <asp:LinkButton ID="btnAdd" OnClick="btnAdd_Click" Text="Add" CssClass="btnText"
                                    runat="server"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="dgvList" runat="server" DataSourceID="IntegrationAdapterQueryFieldsDataSource"
                    AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                    CellPadding="3" BorderStyle="Solid" BorderColor="#E7E7FF" DataKeyNames="IntegrationAdapterQueryFieldID"
                    OnRowDataBound="dgvList_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Fields" Width="100%" CssClass="GridFonts">
                    <FooterStyle Height="28px" ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                    <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
                    <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                        BackColor="#4A3C8C"></HeaderStyle>
                    <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                    <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px"
                        BorderColor="#D7D7D7"></RowStyle>
                    <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7">
                    </AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                &nbsp;...</HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="Edit" ToolTip="Edit" ImageUrl="~/Contents/Images/Actions/i_edit.gif" />
                                <asp:ImageButton ID="btnDelete" runat="server" CommandName="Delete" ToolTip="Delete"
                                    ImageUrl="~/Contents/Images/Actions/i_delete.gif" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ToolTip="Update"
                                    ImageUrl="~/Contents/Images/Actions/i_save.png" />
                                <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="Cancel"
                                    ImageUrl="~/Contents/Images/Actions/i_cancel.png" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ToolTip="Save"
                                    ImageUrl="~/Contents/Images/Actions/i_save.png" OnClick="btnInsert_Click" />
                                <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" ToolTip="Cancel"
                                    ImageUrl="~/Contents/Images/Actions/i_cancel.png" CausesValidation="false" OnClick="btnCancel_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Field Name" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblFieldName" Text='<%# Eval("FieldName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtFieldName" Text='<%# Bind("FieldName") %>' Width="90%" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtFieldName" Text='<%# Bind("FieldName") %>' Width="90%" runat="server"></asp:TextBox>
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtFieldName" Text='<%# Bind("FieldName") %>' Width="90%" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Field Type" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblFieldDataType" Text='<%# Eval("FieldDataTypeName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbFieldDataType" SelectedValue='<%# Bind("FieldDataType") %>'
                                    Width="120px" runat="server">
                                    <asp:ListItem Value="0" Text="Select Data Type.." Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="String"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Boolean"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="DateTime"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Integer"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Double"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Decimal"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="cmbFieldDataType" SelectedValue='<%# Bind("FieldDataType") %>'
                                    Width="120px" runat="server">
                                    <asp:ListItem Value="1" Text="String" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Boolean"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="DateTime"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Integer"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Double"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Decimal"></asp:ListItem>
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbFieldDataType" SelectedValue='<%# Bind("FieldDataType") %>'
                                    Width="120px" runat="server">
                                    <asp:ListItem Value="1" Text="String" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Boolean"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="DateTime"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Integer"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Double"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Decimal"></asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Key" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkIsPrimaryKey" Checked='<%# Eval("IsPrimaryKey") %>' Enabled="false"
                                    runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsPrimaryKey" Checked='<%# Bind("IsPrimaryKey") %>' runat="server" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:CheckBox ID="chkIsPrimaryKey" Checked='<%# Bind("IsPrimaryKey") %>' runat="server" />
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:CheckBox ID="chkIsPrimaryKey" Checked='<%# Bind("IsPrimaryKey") %>' runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Key Sequence" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblPrimaryKeySequence" Text='<%# Eval("PrimaryKeySequence") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrimaryKeySequence" Text='<%# Bind("PrimaryKeySequence") %>'
                                    MaxLength="1" runat="server" />
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtPrimaryKeySequence" Text='<%# Bind("PrimaryKeySequence") %>'
                                    MaxLength="1" runat="server" />
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtPrimaryKeySequence" Text='<%# Bind("PrimaryKeySequence") %>'
                                    MaxLength="1" runat="server" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescription" Text='<%# Bind("Description") %>' Width="90%" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="txtDescription" Text='<%# Bind("Description") %>' Width="90%" runat="server"></asp:TextBox>
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtDescription" Text='<%# Bind("Description") %>' Width="90%" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="IntegrationAdapterQueryDataSource" runat="server" SelectMethod="GetIntegrationAdapterQuery"
        InsertMethod="InsertIntegrationAdapterQuery" UpdateMethod="UpdateIntegrationAdapterQuery"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationAdapterQueryPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQuery"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="IntegrationAdapterQueryID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="IntegrationAdapterQueryFieldsDataSource" runat="server"
        SelectMethod="GetIntegrationAdapterQueryFields" UpdateMethod="UpdateIntegrationAdapterQueryField"
        InsertMethod="InsertIntegrationAdapterQueryField" DeleteMethod="DeleteIntegrationAdapterQueryField"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationAdapterQueryPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQueryField"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationAdapterQueryID" QueryStringField="IntegrationAdapterQueryID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="RefIntegrationAdapterQueryObjectDataSource" runat="server"
        SelectMethod="GetRefIntegrationAdapterQueries" TypeName="ABATS.AppsTalk.Presentation.IntegrationAdapterQueryPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQuery" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationAdapterID" QueryStringField="IntegrationAdapterID"
                Type="Int32" />
            <asp:QueryStringParameter Name="pIntegrationProcessID" QueryStringField="IntegrationProcessID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
