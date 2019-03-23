<%@ Page Title="Application Web Service" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" CodeBehind="ApplicationWebServiceView.aspx.cs" Inherits="ABATS.AppsTalk.Views.Admin.Applications.ApplicationWebServiceView" %>

<asp:Content ID="ContentApplicationWebServiceView" ContentPlaceHolderID="FullContentPlaceHolder"
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
                        <td valign="middle" class="BoxHeaderText">Web Service Settings
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <asp:FormView ID="fvMain" runat="server" DataSourceID="ApplicationWebServiceDataSource"
                    DataKeyNames="ApplicationWebServiceID" OnItemInserted="fvMain_ItemInserted" OnItemUpdated="fvMain_ItemUpdated"
                    Width="100%">
                    <ItemTemplate>
                        <table id="tableMainInfo" cellpadding="0" cellspacing="0" class="FormTable" width="100%">
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Title
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceTitle" runat="server" Text='<%# Bind("ApplicationWebServiceTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Service URL
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceURL" runat="server" Text='<%# Bind("ApplicationWebServiceURL") %>' Width="100%"
                                        CssClass="CalibriFont FontSize16" ReadOnly="true">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Assembly Path
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtAssemblyFullPath" runat="server" Text='<%# Bind("AssemblyFullPath") %>' Width="100%"
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
                                    <asp:TextBox ID="txtApplicationWebServiceTitle" runat="server" Text='<%# Bind("ApplicationWebServiceTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Service URL
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceURL" runat="server" Text='<%# Bind("ApplicationWebServiceURL") %>' Width="100%" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Assembly Path
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtAssemblyFullPath" runat="server" Text='<%# Bind("AssemblyFullPath") %>' Width="100%" CssClass="CalibriFont FontSize16">
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
                                    <asp:TextBox ID="txtApplicationWebServiceTitle" runat="server" Text='<%# Bind("ApplicationWebServiceTitle") %>'
                                        CssClass="CalibriFont FontSize16" Width="100%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Service URL
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtApplicationWebServiceURL" runat="server" Text='<%# Bind("ApplicationWebServiceURL") %>' Width="100%" CssClass="CalibriFont FontSize16">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr class="FormTableRow">
                                <td class="FormFieldLable">Assembly Path
                                </td>
                                <td class="FormFieldInput">
                                    <asp:TextBox ID="txtAssemblyFullPath" runat="server" Text='<%# Bind("AssemblyFullPath") %>' Width="100%" CssClass="CalibriFont FontSize16">
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
                    </InsertItemTemplate>
                </asp:FormView>
            </div>
        </div>
        <div id="divApplicationWebServiceRequests" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 99.8%;"
            runat="server">
            <div class="ShadowBoxHeader">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td valign="bottom" style="width: 22px; padding-top: 4px;">
                            <asp:Image ID="Image1" ImageUrl="~/Contents/Images/list_small.png" runat="server" />
                        </td>
                        <td valign="middle" class="BoxHeaderText">Web Service Requests
                        </td>
                    </tr>
                </table>
            </div>
            <div class="MyBoxContents">
                <div id="divAddButton" class="divButtonSmall" style="width: 200px; margin-bottom: 5px;" onclick="WindowUtilities.ShowApplicationWebServiceRequestView(-1, <%= this.Presenter.EntityID %>, 'Add');">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" valign="middle" style="padding-left: 5px; padding-top: 4px;">
                                <asp:Image ID="imgAdd" ImageUrl="~/Contents/Images/Actions/i_new.gif" Width="16px"
                                    Height="16px" runat="server" />
                            </td>
                            <td align="left" valign="middle" style="padding-left: 7px; padding-right: 7px;">
                                <span id="spanAddDatabase" class="btnText">Add Web Service Request
                                </span>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="dgvList" runat="server" DataSourceID="ApplicationWebServiceRequestsDataSource"
                    AutoGenerateColumns="False" BorderWidth="1px" BackColor="White" GridLines="Horizontal"
                    CellPadding="3" BorderStyle="Solid" BorderColor="#D7D7D7" DataKeyNames="ApplicationWebServiceRequestID"
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
                                <img src="<%= ResolveUrl("~") %>/Contents/Images/i_edit.gif" alt="Edit" onclick="WindowUtilities.ShowApplicationWebServiceRequestView(<%# Eval("ApplicationWebServiceRequestID") %>, <%= this.Presenter.EntityID %>, 'Edit');"
                                    style="cursor: pointer; margin-left: 5px;" title="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ApplicationWebServiceRequestTitle" HeaderText="Title" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="ApplicationWebServiceRequestTitle" />
                        <asp:BoundField DataField="ApplicationWebServiceRequestTypeDescription" HeaderText="Type" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="ApplicationWebServiceRequestTypeDescription" />
                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                            SortExpression="Description" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ApplicationWebServiceDataSource" runat="server" SelectMethod="GetApplicationWebService"
        InsertMethod="InsertApplicationWebService" UpdateMethod="UpdateApplicationWebService"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationWebServicePresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationWebService"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pEntityID" QueryStringField="ApplicationWebServiceID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ApplicationWebServiceRequestsDataSource" runat="server" SelectMethod="GetApplicationWebServiceRequests"
        TypeName="ABATS.AppsTalk.Presentation.ApplicationWebServicePresenter" DataObjectTypeName="ABATS.AppsTalk.Data.ApplicationWebServiceRequest"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:QueryStringParameter Name="pApplicationWebServiceID" QueryStringField="ApplicationWebServiceID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>