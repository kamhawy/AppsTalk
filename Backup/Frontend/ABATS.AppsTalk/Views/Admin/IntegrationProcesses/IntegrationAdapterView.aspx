<%@ Page Title="Integration Adapter" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="IntegrationAdapterView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.IntegrationProcesses.IntegrationAdapterView" %>

<asp:Content ID="ContentIntegrationAdapterView" ContentPlaceHolderID="MainContentPlaceHolder"
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
                            Basic Information
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="IntegrationAdapterDataSource"
                    DataKeyNames="IntegrationAdapterID" Width="100%">
                    <ItemTemplate>
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
                                                <asp:TextBox ID="txtIntegrationAdapterTitle" runat="server" Text='<%# Bind("IntegrationAdapterTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationAdapterTitle" ControlToValidate="txtIntegrationAdapterTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Adapter Name]</b> is a Required Field !"
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
                                    <asp:DropDownList ID="cmbIntegrationAdapterType" SelectedValue='<%# Bind("IntegrationAdapterType") %>'
                                        Width="150px" runat="server">
                                        <asp:ListItem Value="1" Text="Source"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Destination"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    End-Point
                                </td>
                                <td class="FormFieldInput">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="cmbApplicationEndPoint" SelectedValue='<%# Bind("ApplicationEndPointID") %>'
                                                    Width="100%" DataSourceID="ApplicationEndPointObjectDataSource" DataTextField="ApplicationEndPointTitle"
                                                    DataValueField="ApplicationEndPointID" AppendDataBoundItems="true" runat="server">
                                                    <asp:ListItem Value="" Text="Select Application End-Point" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="validatorApplicationEndPoint" ControlToValidate="cmbApplicationEndPoint"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application End-Point]</b> is a Required Field !"
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
                                <td class="FormFieldInput" colspan="3">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtIntegrationAdapterTitle" runat="server" Text='<%# Bind("IntegrationAdapterTitle") %>'
                                                    CausesValidation="true" ValidationGroup="FormValidationGroup" Width="100%">
                                                </asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="RequiredFieldtxtIntegrationAdapterTitle" ControlToValidate="txtIntegrationAdapterTitle"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Integration Adapter Name]</b> is a Required Field !"
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
                                    <asp:DropDownList ID="cmbIntegrationAdapterType" SelectedValue='<%# Bind("IntegrationAdapterType") %>'
                                        Width="150px" Enabled="false" runat="server">
                                        <asp:ListItem Value="1" Text="Source"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Destination"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="FormFieldLable" style="width: 100px;">
                                    End-Point
                                </td>
                                <td class="FormFieldInput">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="cmbApplicationEndPoint" SelectedValue='<%# Bind("ApplicationEndPointID") %>'
                                                    Width="100%" DataSourceID="ApplicationEndPointObjectDataSource" DataTextField="ApplicationEndPointTitle"
                                                    DataValueField="ApplicationEndPointID" AppendDataBoundItems="true" runat="server">
                                                    <asp:ListItem Value="" Text="Select Application End-Point" Selected="True"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <asp:RequiredFieldValidator ID="validatorApplicationEndPoint" ControlToValidate="cmbApplicationEndPoint"
                                                    ValidationGroup="FormValidationGroup" ErrorMessage="<b>[Application End-Point]</b> is a Required Field !"
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
        <div id="divIntegrationApdaterQueryFields" class="ShadowBox" style="margin: 0px 0px 5px 0px;
            width: 99.8%;" runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">
                            Adapter Queries
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                
                <div id="divAddButton" class="divButtonSmall" style="width: 65px; margin-bottom: 5px;" runat="server">
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
                <asp:GridView ID="dgvList" runat="server" DataSourceID="IntegrationAdapterQueriesDataSource"
                    AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                    CellPadding="3" BorderStyle="Solid" BorderColor="#D7D7D7" DataKeyNames="IntegrationAdapterQueryID"
                    Width="100%" CssClass="GridFonts">
                    <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                    <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
                    <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                        BackColor="#4A3C8C" BorderWidth="1px" BorderColor="#D7D7D7"></HeaderStyle>
                    <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                    <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px"
                        BorderColor="#D7D7D7"></RowStyle>
                    <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7">
                    </AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="&nbsp;..." HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <img src="<%= ResolveUrl("~") %>/Contents/Images/i_edit.gif" alt="Edit" onclick="ShowIntegrationApdaterQueryView(<%# Eval("IntegrationAdapterQueryID") %>, 'Edit', <%= this.Presenter.EntityID %>, <%= this.Presenter.IntegrationProcessID %>);"
                                    style="cursor: pointer; margin-left: 5px;" title="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IntegrationAdapterQueryTitle" HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="IntegrationAdapterQueryTitle" />
                        <asp:BoundField DataField="IntegrationAdapterQueryTypeName" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="IntegrationAdapterQueryTypeName" />
                        <asp:BoundField DataField="RefIntegrationAdapterQueryTitle" HeaderText="Ref. Query"
                            HeaderStyle-HorizontalAlign="Left" SortExpression="RefIntegrationAdapterQueryTitle" />
                        <asp:BoundField DataField="ExecutionOrder" HeaderText="Sequence" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="ExecutionOrder" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="IntegrationAdapterDataSource" runat="server" SelectMethod="GetIntegrationAdapter"
        InsertMethod="InsertIntegrationAdapter" UpdateMethod="UpdateIntegrationAdapter"
        OnInserted="IntegrationAdapterDataSource_Inserted" TypeName="ABATS.AppsTalk.Presentation.IntegrationAdapterPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapter" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="IntegrationAdapterID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="IntegrationAdapterQueriesDataSource" runat="server" SelectMethod="GetIntegrationAdapterQueries"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationAdapterPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQuery"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationAdapterID" QueryStringField="IntegrationAdapterID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ApplicationEndPointObjectDataSource" runat="server" SelectMethod="GetApplicationEndPoints"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationAdapterPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQuery"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
    </asp:ObjectDataSource>
</asp:Content>
