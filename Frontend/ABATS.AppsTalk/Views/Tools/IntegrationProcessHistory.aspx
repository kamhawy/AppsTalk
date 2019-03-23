<%@ Page Title="Integration Processes History" Language="C#" MasterPageFile="~/Full.Master"
    AutoEventWireup="true" CodeBehind="IntegrationProcessHistory.aspx.cs" Inherits="ABATS.AppsTalk.Views.Tools.IntegrationProcessHistory" %>

<asp:Content ID="ContentIntegrationProcessHistory" ContentPlaceHolderID="FullContentPlaceHolder"
    runat="server">
    <div class="innerPanelContainer">
        <div id="divSelection" class="ShadowBox" style="margin: 0px 0px 5px 0px; width: 100%;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" style="padding: 5px;">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <asp:DropDownList ID="cmbIntegrationProcess" DataSourceID="IntegrationProcessesDataSource"
                                       CssClass="CalibriFont FontSize16"  Width="100%" DataTextField="IntegrationProcessTitle" DataValueField="IntegrationProcessID"
                                        AutoPostBack="true" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Text="Select Integration Process ..." Value="0" Selected="True"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="padding-top: 7px;">
                                    <div class="Regular" style="font-size: 12px;">
                                        <label for="start">
                                            <strong>Start date:</strong></label>
                                        <input id="start" />
                                        <label for="end" style="margin-left: 3em">
                                            <strong>End date:</strong></label>
                                        <input id="end" />
                                        <script type="text/javascript">
                                            $(document).ready(function () {
                                                function startChange() {
                                                    var startDate = start.value();
                                                    var endDate = end.value();

                                                    var hfStartDate = $("#hfStartDate");
                                                    if (hfStartDate != null) {
                                                        hfStartDate.val(kendo.toString(startDate, "g"));
                                                    }

                                                    if (startDate) {
                                                        startDate = new Date(startDate);
                                                        startDate.setDate(startDate.getDate());
                                                        end.min(startDate);
                                                    } else if (endDate) {
                                                        start.max(new Date(endDate));
                                                    } else {
                                                        endDate = new Date();
                                                        start.max(endDate);
                                                        end.min(endDate);
                                                    }
                                                }

                                                function endChange() {
                                                    var endDate = end.value(), startDate = start.value();

                                                    var hfEndDate = $("#hfEndDate");
                                                    if (hfEndDate != null) {
                                                        hfEndDate.val(kendo.toString(endDate, "g"));
                                                    }

                                                    if (endDate) {
                                                        endDate = new Date(endDate);
                                                        endDate.setDate(endDate.getDate());
                                                        start.max(endDate);
                                                    } else if (startDate) {
                                                        end.min(new Date(startDate));
                                                    } else {
                                                        endDate = new Date();
                                                        start.max(endDate);
                                                        end.min(endDate);
                                                    }
                                                }

                                                var tempStartDate = kendo.parseDate($("#hfStartDate").val());
                                                var tempEndDate = kendo.parseDate($("#hfEndDate").val());

                                                var start = $("#start").kendoDateTimePicker({
                                                    value: tempStartDate,
                                                    change: startChange,
                                                    format: "dd/MM/yyyy hh:mm tt",
                                                    parseFormats: ["dd/MM/yyyy hh:mm tt"]
                                                }).data("kendoDateTimePicker");

                                                var hfStartDate = $("#hfStartDate");
                                                if (hfStartDate != null) {
                                                    hfStartDate.val(kendo.toString(start.value(), "g"));
                                                }

                                                var end = $("#end").kendoDateTimePicker({
                                                    value: tempEndDate,
                                                    change: endChange,
                                                    format: "dd/MM/yyyy hh:mm tt",
                                                    parseFormats: ["dd/MM/yyyy hh:mm tt"]
                                                }).data("kendoDateTimePicker");

                                                var hfEndDate = $("#hfEndDate");
                                                if (hfEndDate != null) {
                                                    hfEndDate.val(kendo.toString(end.value(), "g"));
                                                }

                                                start.max(end.value());
                                                end.min(start.value());
                                            });
                                        </script>
                                    </div>
                                    <asp:HiddenField ID="hfStartDate" ClientIDMode="Static" runat="server" />
                                    <asp:HiddenField ID="hfEndDate" ClientIDMode="Static" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" style="width: 75px; padding: 5px;">
                        <asp:Button ID="btnRun" Text="Run" CssClass="RunButton" OnClick="btnRun_Click" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divHistory" class="ShadowBox" style="margin: 5px 0px 0px 0px; padding: 5px; width: 99%;">
            <asp:GridView ID="dgvHistory" runat="server" DataSourceID="HistoryDataSource" AutoGenerateColumns="False"
                BorderWidth="1px" BackColor="White" GridLines="Horizontal" CellPadding="3" BorderStyle="Solid"
                BorderColor="#E7E7FF" DataKeyNames="IntegrationTransactionID" Width="100%" CssClass="GridFonts">
                <FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
                <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF"></PagerStyle>
                <HeaderStyle Height="26px" HorizontalAlign="Left" ForeColor="#F7F7F7" Font-Bold="True"
                    BackColor="#4A3C8C"></HeaderStyle>
                <SelectedRowStyle ForeColor="#4A3C8C" Font-Bold="True" BackColor="#738A9C"></SelectedRowStyle>
                <RowStyle Height="24px" ForeColor="#4A3C8C" BackColor="#F9F9F9" BorderWidth="1px" BorderColor="#D7D7D7"></RowStyle>
                <AlternatingRowStyle ForeColor="#4A3C8C" BackColor="#F1F2F5" BorderWidth="1px" BorderColor="#D7D7D7"></AlternatingRowStyle>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img src="<%= ResolveUrl("~") %>/Contents/Images/Actions/i_load.png" alt="Details"
                                onclick="WindowUtilities.ShowIntegrationTransactionDetails(<%# Eval("IntegrationTransactionID") %>, 'View');"
                                style="cursor: pointer; margin-left: 3px; margin-top: 2px;" title="Details" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IntegrationTransactionTitle" HeaderText="Title" HeaderStyle-HorizontalAlign="Left"
                        SortExpression="IntegrationTransactionTitle" />
                    <asp:BoundField DataField="TransactionStatusName" HeaderText="Status" HeaderStyle-HorizontalAlign="Left"
                        SortExpression="TransactionStatusName" />
                    <asp:BoundField DataField="IntegrationTransactionDate" HeaderText="Timestamp" HeaderStyle-HorizontalAlign="Left"
                        SortExpression="IntegrationTransactionDate " />
                    <asp:BoundField DataField="RecordCreatedBy" HeaderText="Executed By" HeaderStyle-HorizontalAlign="Left"
                        SortExpression="RecordCreatedBy " />
                </Columns>
                <EmptyDataTemplate>
                    <div class="NoRecords">
                        .. No Integration Process History available for the selected search criteria ..
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="IntegrationProcessesDataSource" runat="server" SelectMethod="GetAllIntegrationProcesses"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessHistoryPresenter" OnObjectCreating="ObjectDataSource_ObjectCreating"
        OnObjectDisposing="ObjectDataSource_ObjectDisposing"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="HistoryDataSource" runat="server" SelectMethod="GetHistory"
        TypeName="ABATS.AppsTalk.Presentation.IntegrationProcessHistoryPresenter" DataObjectTypeName="ABATS.AppsTalk.Data.IntegrationTransaction"
        OnObjectCreating="ObjectDataSource_ObjectCreating" OnObjectDisposing="ObjectDataSource_ObjectDisposing">
        <SelectParameters>
            <asp:ControlParameter Name="pIntegrationProcessID" ControlID="cmbIntegrationProcess"
                PropertyName="SelectedValue" Type="Int32" />
            <asp:ControlParameter Name="pStartDate" ControlID="hfStartDate" PropertyName="Value"
                Type="String" />
            <asp:ControlParameter Name="pEndDate" ControlID="hfEndDate" PropertyName="Value"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
