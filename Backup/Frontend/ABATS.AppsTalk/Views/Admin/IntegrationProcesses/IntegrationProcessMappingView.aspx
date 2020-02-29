<%@ Page Title="Integration Process Mapping" Language="C#" MasterPageFile="~/Main.Master"
    AutoEventWireup="true" CodeBehind="IntegrationProcessMappingView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.IntegrationProcesses.IntegrationProcessMappingView" %>

<asp:Content ID="ContentIntegrationProcessMappingView" ContentPlaceHolderID="MainContentPlaceHolder"
    runat="server">
    <style type="text/css">
        #wrap
        {
            width: 100% !important;
        }
    </style>
    <div id="divInnerContainer" class="innerPanelContainer">
        <div id="divIntegratoinProcessMapping" class="ShadowBox" style="margin: 0px 0px 5px 0px;
            width: 99.8%;" runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image2" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">
                            Integratoin Process Mapping
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
                <asp:GridView ID="dgvList" runat="server" DataSourceID="IntegrationProcessMappingsDataSource"
                    AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                    CellPadding="3" BorderStyle="Solid" BorderColor="#E7E7FF" DataKeyNames="IntegrationProcessMappingID"
                    OnRowDataBound="dgvList_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Fields Mapping"
                    Width="100%" CssClass="GridFonts">
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
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="50px" ItemStyle-Width="50px">
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
                        <asp:TemplateField HeaderText="Source Field" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSourceIntegrationAdapterQueryFieldName" Text='<%# Eval("SourceIntegrationAdapterQueryFieldName") %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbSourceField" DataSourceID="SourceFieldMappingObjectDataSource"
                                    SelectedValue='<%# Bind("SourceAdapterQueryFieldID") %>' Width="95%" DataTextField="FieldName"
                                    DataValueField="IntegrationAdapterQueryFieldID" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="0" Text="Select Source Field .." Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="cmbSourceField" DataSourceID="SourceFieldMappingObjectDataSource"
                                    SelectedValue='<%# Bind("SourceAdapterQueryFieldID") %>' Width="95%" DataTextField="FieldName"
                                    DataValueField="IntegrationAdapterQueryFieldID" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="0" Text="Select Source Field .." Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbSourceField" DataSourceID="SourceFieldMappingObjectDataSource"
                                    SelectedValue='<%# Bind("SourceAdapterQueryFieldID") %>' Width="95%" DataTextField="FieldName"
                                    DataValueField="IntegrationAdapterQueryFieldID" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="0" Text="Select Source Field .." Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Destination Field" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblDestinationIntegrationAdapterQueryFieldName" Text='<%# Eval("DestinationIntegrationAdapterQueryFieldName") %>'
                                    runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmbDestinationField" DataSourceID="DestinationFieldMappingObjectDataSource"
                                    SelectedValue='<%# Bind("DestinationAdapterQueryFieldID") %>' Width="95%" DataTextField="FieldName"
                                    DataValueField="IntegrationAdapterQueryFieldID" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="0" Text="Select Destination Field .." Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="cmbDestinationField" DataSourceID="DestinationFieldMappingObjectDataSource"
                                    SelectedValue='<%# Bind("DestinationAdapterQueryFieldID") %>' Width="95%" DataTextField="FieldName"
                                    DataValueField="IntegrationAdapterQueryFieldID" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="0" Text="Select Source Field .." Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </InsertItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="cmbDestinationField" DataSourceID="DestinationFieldMappingObjectDataSource"
                                    SelectedValue='<%# Bind("DestinationAdapterQueryFieldID") %>' Width="95%" DataTextField="FieldName"
                                    DataValueField="IntegrationAdapterQueryFieldID" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Value="0" Text="Select Source Field .." Selected="True"></asp:ListItem>
                                </asp:DropDownList>
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
    <asp:ObjectDataSource ID="IntegrationProcessMappingsDataSource" runat="server" SelectMethod="GetIntegrationProcessMappings"
        UpdateMethod="UpdateIntegrationProcessMapping" InsertMethod="InsertIntegrationProcessMapping"
        DeleteMethod="DeleteIntegrationProcessMapping" TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessMappingPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationProcessMapping" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationProcessID" QueryStringField="IntegrationProcessID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="SourceFieldMappingObjectDataSource" runat="server" SelectMethod="GetSourceFields"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessMappingPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQueryField"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationProcessID" QueryStringField="IntegrationProcessID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="DestinationFieldMappingObjectDataSource" runat="server"
        SelectMethod="GetDestinationFields" TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessMappingPresenter"
        DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationAdapterQueryField" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pIntegrationProcessID" QueryStringField="IntegrationProcessID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
