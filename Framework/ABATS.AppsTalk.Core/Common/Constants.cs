using System;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represents the Application Constants Store
    /// </summary>
    public static class Constants
    {
        #region Core

        /// <summary>
        /// System User
        /// </summary>
        public const string SystemUser = "System";

        /// <summary>
        /// Visitor User
        /// </summary>
        public const string VisitorUser = "Visitor";

        /// <summary>
        /// Default Page Validation Group
        /// </summary>
        public const string DefaultValidationGroup = "ValidGroup";

        /// <summary>
        /// DefaultDateFormat
        /// </summary>
        public const string DefaultDateFormat = "dd/MM/yyyy";

        /// <summary>
        /// DefaultUIDateFormat
        /// </summary>
        public const string DefaultUIDateFormat = "{0:dd/MM/yyyy}";

        /// <summary>
        /// DefaultUIDateTimeFormat
        /// </summary>
        public const string DefaultUIDateTimeFormat = "{0:dd/MM/yyyy hh:mm:ss tt}";

        /// <summary>
        /// DefaultUITimeFormat
        /// </summary>
        public const string DefaultUITimeFormat = "{0:HH:mm:ss tt}";

        /// <summary>
        /// DefaultMonthlyUIDateFormat
        /// </summary>
        public const string DefaultMonthlyUIDateFormat = "{0:MMM-yyyy}";

        /// <summary>
        /// DefaultDateTimeFormat
        /// </summary>
        public const string DefaultDateTimeFormat = "dd/MM/yyyy hh:mm tt";

        /// <summary>
        /// DefaultDateTimeFormat - Full
        /// </summary>
        public const string DefaultDateTimeFormat_Full = "dd/MM/yyyy hh:mm:ss tt";

        /// <summary>
        /// Default Decimal Digits
        /// </summary>
        public const short DefaultDecimalDigits = 4;

        /// <summary>
        /// Get Min Price Date
        /// </summary>
        public static DateTime GetMinPriceDate()
        {
            return new DateTime(1980, 1, 1);
        }

        #endregion

        #region Session Keys

        #region Common

        /// <summary>
        /// Session Key - SessionKey_IAppRuntime
        /// </summary>
        public const string SessionKey_IAppRuntime = "SK_IAppRuntime";

        /// <summary>
        /// Session Key - Windows Manager
        /// </summary>
        public const string SessionKey_WindowsManager = "SK_WindowsManager";

        /// <summary>
        /// Session Key - Current Exported Chart
        /// </summary>
        public const string SessionKey_CurrentExportedChart = "SK_CurrentExportedChart";

        /// <summary>
        /// Session Key - History Manager
        /// </summary>
        public const string SessionKey_HistoryManager = "SK_HistoryManager";

        /// <summary>
        /// Prefix SessionKey Presenter
        /// </summary>
        public const string Prefix_SessionKey_Presenter = "SK_Presenter_";

        #endregion

        #region Presenters

        /// <summary>
        /// Session Key - HomePresenter
        /// </summary>
        public const string SessionKey_HomePresenter = "SK_Presenter_Home";

        /// <summary>
        /// Session Key - PriceSeriesPresenter
        /// </summary>
        public const string SessionKey_PriceSeriesPresenter = "SK_Presenter_PricesSeriesPresenter";

        /// <summary>
        /// Session Key - PricesSnapshotConfigPresenter
        /// </summary>
        public const string SessionKey_PricesSnapshotConfigPresenter = "SK_Presenter_PricesSnapshotConfigPresenter";

        /// <summary>
        /// Session Key - PricesSnapshotConfigDetailPresenter
        /// </summary>
        public const string SessionKey_PricesSnapshotConfigDetailPresenter = "SK_Presenter_PricesSnapshotConfigDetailPresenter";

        /// <summary>
        /// Session Key - PricesSheetConfigPresenter
        /// </summary>
        public const string SessionKey_PricesSheetConfigPresenter = "SK_Presenter_PricesSheetConfigPresenter";

        /// <summary>
        /// Session Key - PricesSheetConfigDetailPresenter
        /// </summary>
        public const string SessionKey_PricesSheetConfigDetailPresenter = "SK_Presenter_PricesSheetConfigDetailPresenter";

        /// <summary>
        /// Session Key - PricesSheetReportPresenter
        /// </summary>
        public const string SessionKey_PricesSheetReportPresenter = "SK_Presenter_PricesSheetReportPresenter";

        /// <summary>
        /// Session Key - DataPointPresenter
        /// </summary>
        public const string SessionKey_DataPointPresenter = "SK_Presenter_DataPointPresenter";

        /// <summary>
        /// Session Key - SecurityPresenter
        /// </summary>
        public const string SessionKey_SecurityPresenter = "SK_Presenter_SecurityPresenter";

        /// <summary>
        /// Session Key - FieldPresenter
        /// </summary>
        public const string SessionKey_FieldPresenter = "SK_Presenter_FieldPresenter";

        /// <summary>
        /// Session Key - TimeCodePresenter
        /// </summary>
        public const string SessionKey_TimeCodePresenter = "SK_Presenter_TimeCodePresenter";

        /// <summary>
        /// Session Key - CurrenciesPresenter
        /// </summary>
        public const string SessionKey_CurrenciesPresenter = "SK_Presenter_CurrenciesPresenter";

        /// <summary>
        /// Session Key - UnitsPresenter
        /// </summary>
        public const string SessionKey_UnitPresenter = "SK_Presenter_UnitPresenter";

        /// <summary>
        /// Session Key - UserPresenter
        /// </summary>
        public const string SessionKey_UserPresenter = "SK_Presenter_UserPresenter";

        /// <summary>
        /// Session Key - SnapshotDashboardPresenter
        /// </summary>
        public const string SessionKey_SnapshotDashboardPresenter = "SK_Presenter_SnapshotDashboardPresenter";

        /// <summary>
        /// Session Key - PricingDashboardPresenter
        /// </summary>
        public const string SessionKey_PricesDashboardPresenter = "SK_Presenter_PricesDashboardPresenter";

        /// <summary>
        /// Session Key - PricingChartsPresenter
        /// </summary>
        public const string SessionKey_PricingChartsPresenter = "SK_Presenter_PricingChartsPresenter";

        /// <summary>
        /// Session Key - FuturePricesChartConfigPresenter
        /// </summary>
        public const string SessionKey_FuturePricesChartConfigPresenter = "SK_Presenter_FuturePricesChartConfigPresenter";

        /// <summary>
        /// Session Key - SpotPricesChartConfigPresenter
        /// </summary>
        public const string SessionKey_SpotPricesChartConfigPresenter = "SK_Presenter_SpotPricesChartConfigPresenter";

        /// <summary>
        /// Session Key - ManualPriceSeriesConfigPresenter
        /// </summary>
        public const string SessionKey_ManualPriceSeriesConfigPresenter = "SK_Presenter_ManualPriceSeriesConfigPresenter";

        /// <summary>
        /// Session Key - MarketInfoReportConfigPresenter
        /// </summary>
        public const string SessionKey_MarketInfoReportConfigPresenter = "SK_Presenter_MarketInfoReportConfigPresenter";

        /// <summary>
        /// Session Key - InfoReportBoxesConfigPresenter
        /// </summary>
        public const string SessionKey_InfoReportBoxesConfigPresenter = "SK_Presenter_InfoReportBoxesConfigPresenter";

        /// <summary>
        /// Session Key - MarketInfoReportPresenter
        /// </summary>
        public const string SessionKey_MarketInfoReportPresenter = "SK_Presenter_MarketInfoReportPresenter";

        /// <summary>
        /// Session Key - SnapshotToolsPresenter
        /// </summary>
        public const string SessionKey_SnapshotToolsPresenter = "SK_Presenter_SnapshotToolsPresenter";

        /// <summary>
        /// Session Key - FixSnapshotPresenter
        /// </summary>
        public const string SessionKey_FixSnapshotPresenter = "SK_Presenter_FixSnapshotPresenter";

        /// <summary>
        /// Session Key - ReviewSnapshotPresenter
        /// </summary>
        public const string SessionKey_ReviewSnapshotPresenter = "SK_Presenter_ReviewSnapshotPresenter";

        /// <summary>
        /// Session Key - ChangeLinkedHistorySnapshotPresenter
        /// </summary>
        public const string SessionKey_ChangeLinkedHistorySnapshotPresenter = "SK_Presenter_ChangeLinkedHistorySnapshotPresenter";

        /// <summary>
        /// Session Key - PricingAccessMonitorPresenter
        /// </summary>
        public const string SessionKey_PricingAccessMonitorPresenter = "SK_Presenter_PricingAccessMonitorPresenter";

        /// <summary>
        /// Session Key - LockConfigsPresenter
        /// </summary>
        public const string SessionKey_LockConfigsPresenter = "SK_Presenter_LockConfigsPresenter";

        /// <summary>
        /// Session Key - PricingSettingsPresenter
        /// </summary>
        public const string SessionKey_PricingSettingsPresenter = "SK_Presenter_PricingSettingsPresenter";

        /// <summary>
        /// Session Key - SnapshotAuditReportPresenter
        /// </summary>
        public const string SessionKey_SnapshotAuditReportPresenter = "SK_Presenter_SnapshotAuditReportPresenter";

        /// <summary>
        /// Session Key - SnapshotAnalysisReportPresenter
        /// </summary>
        public const string SessionKey_SnapshotAnalysisReportPresenter = "SK_Presenter_SnapshotAnalysisReportPresenter";

        /// <summary>
        /// Session Key - ExecuteSnapshotPresenter
        /// </summary>
        public const string SessionKey_ExecuteSnapshotPresenter = "SK_Presenter_ExecuteSnapshotPresenter";

        /// <summary>
        /// Session Key - AuditTrailReportPresenter
        /// </summary>
        public const string SessionKey_AuditTrailReportPresenter = "SK_Presenter_AuditTrailReportPresenter";

        /// <summary>
        /// Session Key - ConfigObjectPresenter
        /// </summary>
        public const string SessionKey_SystemObjectPresenter = "SK_Presenter_SystemObjectPresenter";

        /// <summary>
        /// Session Key - DailyManualInputsPresenter
        /// </summary>
        public const string SessionKey_DailyManualInputsPresenter = "SK_Presenter_DailyManualInputsPresenter";

        /// <summary>
        /// Session Key - PricesForecastConfigPresenter
        /// </summary>
        public const string SessionKey_PricesForecastConfigPresenter = "SK_Presenter_PricesForecastConfigPresenter";

        /// <summary>
        /// Session Key - PricesForecastConfigDetailPresenter
        /// </summary>
        public const string SessionKey_PricesForecastConfigDetailPresenter = "SK_Presenter_PricesForecastConfigDetailPresenter";

        /// <summary>
        /// Session Key - PricesForecastPresenter
        /// </summary>
        public const string SessionKey_PricesForecastPresenter = "SK_Presenter_PricesForecastPresenter";

        /// <summary>
        /// Session Key - ControlReportConfigPresenter
        /// </summary>
        public const string SessionKey_ControlReportConfigPresenter = "SK_Presenter_ControlReportConfigPresenter";

        /// <summary>
        /// Session Key - ControlReportConfigApproverPresenter
        /// </summary>
        public const string SessionKey_ControlReportConfigApproverPresenter = "SK_Presenter_ControlReportConfigApproverPresenter";

        /// <summary>
        /// Session Key - ControlReportPresenter
        /// </summary>
        public const string SessionKey_ControlReportPresenter = "SK_Presenter_ControlReportPresenter";

        #endregion

        #endregion

        #region Cache Keys

        /// <summary>
        /// Cache Key - Authentication Manager
        /// </summary>
        public const string CacheKey_AuthenticationManager = "CK_AuthenticationManager";

        /// <summary>
        /// Cache Key - ApplicationRoles
        /// </summary>
        public const string CacheKey_ApplicationRoles = "CK_ApplicationRoles";

        #endregion

        #region Query String Keys

        /// <summary>
        /// Query String - UIMode
        /// </summary>
        public const string QueryStringKey_UIMode = "UIMode";

        /// <summary>
        /// Query String - UserControlFullPath
        /// </summary>
        public const string QueryStringKey_UserControlFullPath = "UserControlFullPath";

        /// <summary>
        /// Query String - System Appointment Type
        /// </summary>
        public const string QueryStringKey_SystemAppointmentType = "SystemAppointmentType";

        /// <summary>
        /// Query String - System Appointment Ref ID
        /// </summary>
        public const string QueryStringKey_SystemAppointmentRefID = "SystemAppointmentRefID";

        /// <summary>
        /// Query String - PricesSnapshotID
        /// </summary>
        public const string QueryStringKey_PricesSnapshotID = "PricesSnapshotID";

        /// <summary>
        /// Query String - PricesSnapshotVersionID
        /// </summary>
        public const string QueryStringKey_PricesSnapshotVersionID = "PricesSnapshotVersionID";

        /// <summary>
        /// Query String - PricesSnapshotLogID
        /// </summary>
        public const string QueryStringKey_PricesSnapshotLogID = "PricesSnapshotLogID";

        /// <summary>
        /// Query String - PriceSeriesConfigID
        /// </summary>
        public const string QueryStringKey_PriceSeriesConfigID = "PriceSeriesConfigID";

        /// <summary>
        /// Query String - PricesSnapshotConfigID
        /// </summary>
        public const string QueryStringKey_PricesSnapshotConfigID = "PricesSnapshotConfigID";

        /// <summary>
        /// Query String - PricesSnapshotConfigDetailID
        /// </summary>
        public const string QueryStringKey_PricesSnapshotConfigDetailID = "PricesSnapshotConfigDetailID";

        /// <summary>
        /// Query String - PricesSheetConfigID
        /// </summary>
        public const string QueryStringKey_PricesSheetConfigID = "PricesSheetConfigID";

        /// <summary>
        /// Query String - PricesSheetConfigDetailID
        /// </summary>
        public const string QueryStringKey_PricesSheetConfigDetailID = "PricesSheetConfigDetailID";

        /// <summary>
        /// Query String - MarketInfoReportConfigID
        /// </summary>
        public const string QueryStringKey_MarketInfoReportConfigID = "MarketInfoReportConfigID";

        /// <summary>
        /// Query String - InfoReportBoxesConfigID
        /// </summary>
        public const string QueryStringKey_InfoReportBoxesConfigID = "InfoReportBoxesConfigID";

        /// <summary>
        /// Query String - DataPointID
        /// </summary>
        public const string QueryStringKey_DataPointID = "DataPointID";

        /// <summary>
        /// Query String - FieldID
        /// </summary>
        public const string QueryStringKey_FieldID = "FieldID";

        /// <summary>
        /// Query String - SecurityID
        /// </summary>
        public const string QueryStringKey_SecurityID = "SecurityID";

        /// <summary>
        /// Query String - TimeCodeID
        /// </summary>
        public const string QueryStringKey_TimeCodeID = "TimeCodeID";

        /// <summary>
        /// Query String - TickerTitle
        /// </summary>
        public const string QueryStringKey_TickerTitle = "TickerTitle";

        /// <summary>
        /// Query String - User ID
        /// </summary>
        public const string QueryStringKey_UserID = "ApplicationUserID";

        /// <summary>
        /// Query String - System Object ID
        /// </summary>
        public const string QueryStringKey_SystemObjectID = "SystemObjectID";

        /// <summary>
        /// Query String - ManualPriceSeriesConfigID
        /// </summary>
        public const string QueryStringKey_ManualPriceSeriesConfigID = "ManualPriceSeriesConfigID";

        /// <summary>
        /// Query String - PricesForecastConfigID
        /// </summary>
        public const string QueryStringKey_PricesForecastConfigID = "PricesForecastConfigID";

        /// <summary>
        /// Query String - PricesForecastConfigDetailID
        /// </summary>
        public const string QueryStringKey_PricesForecastConfigDetailID = "PricesForecastConfigDetailID";

        /// <summary>
        /// Query String - PricesForecastID
        /// </summary>
        public const string QueryStringKey_PricesForecastID = "PricesForecastID";

        /// <summary>
        /// Query String - PricesSnapshotAuditID
        /// </summary>
        public const string QueryStringKey_PricesSnapshotAuditID = "PricesSnapshotAuditID";

        /// <summary>
        /// Query String - SpotPricesChartConfigID
        /// </summary>
        public const string QueryStringKey_SpotPricesChartConfigID = "SpotPricesChartConfigID";

        /// <summary>
        /// Query String - FuturePricesChartConfigID
        /// </summary>
        public const string QueryStringKey_FuturePricesChartConfigID = "FuturePricesChartConfigID";

        /// <summary>
        /// Query String - ControlReportConfigID
        /// </summary>
        public const string QueryStringKey_ControlReportConfigID = "ControlReportConfigID";

        /// <summary>
        /// Query String - ControlReportConfigApproverID
        /// </summary>
        public const string QueryStringKey_ControlReportConfigApproverID = "ControlReportConfigApproverID";

        /// <summary>
        /// Query String - ControlReportID
        /// </summary>
        public const string QueryStringKey_ControlReportID = "ControlReportID";

        /// <summary>
        /// Query String - Align
        /// </summary>
        public const string QueryStringKey_Align = "Align";

        /// <summary>
        /// Query String - IntegrationAdapterType
        /// </summary>
        public const string QueryStringKey_IntegrationAdapterType = "IntegrationAdapterType";

        #endregion

        #region Commands

        /// <summary>
        /// Command - View Entity
        /// </summary>
        public const string Command_ViewEntity = "ViewEntity";

        /// <summary>
        /// Command - Add Action
        /// </summary>
        public const string Command_AddAction = "AddAction";

        /// <summary>
        /// Command - Edit Action
        /// </summary>
        public const string Command_EditAction = "EditAction";

        /// <summary>
        /// Command - Delete Action
        /// </summary>
        public const string Command_DeleteAction = "DeleteAction";

        /// <summary>
        /// Command - ShowScheduler
        /// </summary>
        public const string Command_ShowScheduler = "ShowScheduler";

        /// <summary>
        /// Command - Change Status
        /// </summary>
        public const string Command_ChangeStatus = "ChangeStatus";

        /// <summary>
        /// Command - Copy
        /// </summary>
        public const string Command_Copy = "Copy";

        #endregion

        #region Table Names

        /// <summary>
        /// Table Name - Results
        /// </summary>
        public const string TableName_Results = "Results";

        /// <summary>
        /// Table Name - RecordDetails
        /// </summary>
        public const string TableName_RecordDetails = "RecordDetails";

        #endregion

        #region Column Names

        /// <summary>
        /// Column Name - View Column
        /// </summary>
        public const string ColumnName_ViewColumn = "ViewColumn";

        /// <summary>
        /// Column Name - Edit Column
        /// </summary>
        public const string ColumnName_EditColumn = "EditColumn";

        /// <summary>
        /// Column Name - Delete Column
        /// </summary>
        public const string ColumnName_DeleteColumn = "DeleteColumn";

        /// <summary>
        /// Column Name - Select Column
        /// </summary>
        public const string ColumnName_SelectColumn = "SelectColumn";

        /// <summary>
        /// Column Name - Add Action Column
        /// </summary>
        public const string ColumnName_AddActionColumn = "AddAction";

        /// <summary>
        /// Column Name - Edit Action Column
        /// </summary>
        public const string ColumnName_EditActionColumn = "EditAction";

        /// <summary>
        /// Column Name - Delete Action Column
        /// </summary>
        public const string ColumnName_DeleteActionColumn = "DeleteAction";

        /// <summary>
        /// Column Name - Attachment
        /// </summary>
        public const string ColumnName_Attachment = "AttachmentColumn";

        /// <summary>
        /// Column Name - Date
        /// </summary>
        public const string ColumnName_Date = "Date";

        /// <summary>
        /// Column Name - RowID
        /// </summary>
        public const string ColumnName_RowID = "RowID";

        /// <summary>
        /// Column Name - ID
        /// </summary>
        public const string ColumnName_ID = "ID";

        /// <summary>
        /// Column Name - RecordStatus
        /// </summary>
        public const string ColumnName_RecordStatus = "RecordStatus";

        #endregion

        #region Column Header Text

        /// <summary>
        /// Column Header Text - View
        /// </summary>
        public const string ColumnHeaderText_View = "View";

        /// <summary>
        /// Column Header Text - Edit
        /// </summary>
        public const string ColumnHeaderText_Edit = "Edit";

        #endregion

        #region Images

        /// <summary>
        /// ImageUrl - Edit
        /// </summary>
        public const string ImageUrl_Edit = "~/Contents/Images/i_edit.gif";

        #endregion

        #region Font Names

        /// <summary>
        /// Font Name - Font Tahoma
        /// </summary>
        public const string FontName_Tahoma = "Tahoma";

        /// <summary>
        /// Font Name - Font Candara
        /// </summary>
        public const string FontName_Candara = "Candara";

        #endregion

        #region Property Names

        /// <summary>
        /// PropertyName - RecordCreated
        /// </summary>
        public const string PropertyName_RecordCreated = "RecordCreated";

        /// <summary>
        /// PropertyName - RecordCreatedBy
        /// </summary>
        public const string PropertyName_RecordCreatedBy = "RecordCreatedBy";

        /// <summary>
        /// PropertyName - RecordLastUpdate
        /// </summary>
        public const string PropertyName_RecordLastUpdate = "RecordLastUpdate";

        /// <summary>
        /// PropertyName - RecordLastUpdateBy
        /// </summary>
        public const string PropertyName_RecordLastUpdateBy = "RecordLastUpdateBy";

        #endregion

        #region Misc

        /// <summary>
        /// Control Name - Select CheckBox
        /// </summary>
        public const string ControlName_SelectCheckBox = "chkSelect";

        /// <summary>
        /// Property Name - Is Active
        /// </summary>
        public const string PropertyName_IsActive = "IsActive";

        /// <summary>
        /// True Value
        /// </summary>
        public const bool TrueValue = true;

        /// <summary>
        /// False Value
        /// </summary>
        public const bool FalseValue = false;

        /// <summary>
        /// Sheet Name - Forecasts
        /// </summary>
        public const string SheetName_Forecasts = "Forecasts";

        /// <summary>
        /// Page_NotAuthorized
        /// </summary>
        public const string Page_NotAuthorized = "~/Views/Core/NotAuthorized.aspx";

        #endregion
    }
}