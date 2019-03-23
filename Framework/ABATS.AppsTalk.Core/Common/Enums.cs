using System.ComponentModel;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Runtime Service
    /// </summary>
    [DataContract]
    [DefaultValue(RuntimeService.None)]
    public enum RuntimeService : short
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Data")]
        [EnumMember(Value = "1")]
        Data = 1,

        [Description("Security")]
        [EnumMember(Value = "2")]
        Security = 2,

        [Description("Settings")]
        [EnumMember(Value = "3")]
        Settings = 3,

        [Description("Metadata")]
        [EnumMember(Value = "4")]
        Metadata = 4,

        [Description("Reports")]
        [EnumMember(Value = "5")]
        Reports = 5,
    }

    /// <summary>
    /// User Interface Mode
    /// </summary>
    [DataContract]
    [DefaultValue(UIMode.None)]
    public enum UIMode : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Add")]
        [EnumMember(Value = "1")]
        Add = 1,

        [Description("Edit")]
        [EnumMember(Value = "2")]
        Edit = 2,

        [Description("View")]
        [EnumMember(Value = "3")]
        View = 3,

        [Description("Admin")]
        [EnumMember(Value = "4")]
        Admin = 4
    }

    /// <summary>
    /// Data Types
    /// </summary>
    [DataContract]
    [DefaultValue(DataTypes.None)]
    public enum DataTypes : byte
    {
        /// <summary>
        /// None
        /// </summary>
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        /// <summary>
        /// String
        /// </summary>
        [Description("String")]
        [EnumMember(Value = "1")]
        String = 1,

        /// <summary>
        /// Boolean
        /// </summary>
        [Description("Boolean")]
        [EnumMember(Value = "2")]
        Boolean = 2,

        /// <summary>
        /// DateTime
        /// </summary>
        [Description("DateTime")]
        [EnumMember(Value = "3")]
        DateTime = 3,

        /// <summary>
        /// Integer
        /// </summary>
        [Description("Integer")]
        [EnumMember(Value = "4")]
        Integer = 4,

        /// <summary>
        /// Enum
        /// </summary>
        [Description("Enum")]
        [EnumMember(Value = "5")]
        Enum = 5,

        /// <summary>
        /// Double
        /// </summary>
        [Description("Double")]
        [EnumMember(Value = "6")]
        Double = 6,

        /// <summary>
        /// Decimal
        /// </summary>
        [Description("Decimal")]
        [EnumMember(Value = "7")]
        Decimal = 7,
    }

    /// <summary>
    /// Cache Item
    /// </summary>
    [DataContract]
    [DefaultValue(CacheItem.None)]
    public enum CacheItem : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("ApplicationRoles")]
        [EnumMember(Value = "1")]
        ApplicationRoles = 1,

        [Description("ApplicationMenus")]
        [EnumMember(Value = "2")]
        ApplicationMenus = 2,

        [Description("SystemObjects")]
        [EnumMember(Value = "3")]
        SystemObjects = 3,

        [Description("ApplicationModules")]
        [EnumMember(Value = "4")]
        ApplicationModules = 4
    }

    /// <summary>
    /// SettingsKey
    /// </summary>
    [DataContract]
    [DefaultValue(SettingsKey.None)]
    public enum SettingsKey : int
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Skin")]
        [EnumMember(Value = "1")]
        Skin = 1,
    }

    /// <summary>
    /// Database Record Status
    /// </summary>
    [DataContract]
    [DefaultValue(RecordAuditStatus.Active)]
    public enum RecordAuditStatus : byte
    {
        /// <summary>
        /// Active
        /// </summary>
        [Description("Active")]
        [EnumMember(Value = "0")]
        Active = 0,

        /// <summary>
        /// In-Active
        /// </summary>
        [Description("InActive")]
        [EnumMember(Value = "1")]
        InActive = 1,

        /// <summary>
        /// Boolean
        /// </summary>
        [Description("Archived")]
        [EnumMember(Value = "2")]
        Archived = 2,

        /// <summary>
        /// Deleted
        /// </summary>
        [Description("Deleted")]
        [EnumMember(Value = "3")]
        Deleted = 3,
    }

    /// <summary>
    /// Operation Status
    /// </summary>
    [DataContract]
    [DefaultValue(OperationStatus.Succeeded)]
    public enum OperationStatus : byte
    {
        [Description("Succeeded")]
        [EnumMember(Value = "0")]
        Succeeded = 0,

        [Description("Failed")]
        [EnumMember(Value = "1")]
        Failed = 1,
    }

    /// <summary>
    /// Record Transaction Status
    /// </summary>
    [DataContract]
    [DefaultValue(RecordTransactionStatus.None)]
    public enum RecordTransactionStatus : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Succeeded")]
        [EnumMember(Value = "1")]
        Succeeded = 1,

        [Description("Duplicated")]
        [EnumMember(Value = "2")]
        Duplicated = 2,

        [Description("Failed")]
        [EnumMember(Value = "3")]
        Failed = 3,
    }

    /// <summary>
    /// Record Cache Status
    /// </summary>
    [DataContract]
    [DefaultValue(RecordCacheStatus.InQueue)]
    public enum RecordCacheStatus : byte
    {
        [Description("InQueue")]
        [EnumMember(Value = "0")]
        InQueue = 0,

        [Description("Succeeded")]
        [EnumMember(Value = "1")]
        Succeeded = 1,

        [Description("Failed")]
        [EnumMember(Value = "2")]
        Failed = 2,
    }

    /// <summary>
    /// Data Request Type
    /// </summary>
    [DataContract]
    [DefaultValue(DataRequestType.AppendOnly)]
    public enum DataRequestType : byte
    {
        [Description("Append Only")]
        [EnumMember(Value = "0")]
        AppendOnly = 0,

        [Description("Overwrite Changes")]
        [EnumMember(Value = "1")]
        OverwriteChanges = 1,

        [Description("No Tracking")]
        [EnumMember(Value = "2")]
        NoTracking = 2,
    }

    /// <summary>
    /// UI Action
    /// </summary>
    [DataContract]
    [DefaultValue(UIAction.Cancel)]
    public enum UIAction : byte
    {
        [Description("Cancel")]
        [EnumMember(Value = "0")]
        Cancel = 0,

        [Description("Save")]
        [EnumMember(Value = "1")]
        Save = 1,

        [Description("Delete")]
        [EnumMember(Value = "2")]
        Delete = 2,

        [Description("Preview")]
        [EnumMember(Value = "3")]
        Preview = 3,

        [Description("Publish")]
        [EnumMember(Value = "4")]
        Publish = 4,

        [Description("Load")]
        [EnumMember(Value = "5")]
        Load = 5,

        [Description("Print")]
        [EnumMember(Value = "6")]
        Print = 6,

        [Description("Search")]
        [EnumMember(Value = "7")]
        Search = 7,

        [Description("Change Status")]
        [EnumMember(Value = "14")]
        ChangeStatus = 14,

        [Description("Add")]
        [EnumMember(Value = "15")]
        Add = 15,

        [Description("Edit")]
        [EnumMember(Value = "16")]
        Edit = 16,

        [Description("View")]
        [EnumMember(Value = "17")]
        View = 17,

        [Description("Activate")]
        [EnumMember(Value = "18")]
        Activate = 18,

        [Description("DeActivate")]
        [EnumMember(Value = "19")]
        DeActivate = 19,

        [Description("Schedule")]
        [EnumMember(Value = "20")]
        Schedule = 20,

        [Description("Close")]
        [EnumMember(Value = "21")]
        Close = 21,

        [Description("UserDefined")]
        [EnumMember(Value = "22")]
        UserDefined = 22,

        [Description("Scalling")]
        [EnumMember(Value = "26")]
        Scalling = 26,

        [Description("Select")]
        [EnumMember(Value = "27")]
        Select = 27,

        [Description("Run Report")]
        [EnumMember(Value = "28")]
        RunReport = 28,

        [Description("Start")]
        [EnumMember(Value = "29")]
        Start = 29,

        [Description("End")]
        [EnumMember(Value = "30")]
        End = 30,

        [Description("Custom Action")]
        [EnumMember(Value = "99")]
        CustomAction = 99
    }

    /// <summary>
    /// System Appointment Type
    /// </summary>
    [DefaultValue(SystemAppointmentType.General)]
    [DataContract]
    public enum SystemAppointmentType : byte
    {
        [Description("General")]
        [EnumMember(Value = "0")]
        General = 0,

        [Description("Integration Process")]
        [EnumMember(Value = "1")]
        IntegrationProcess = 1,
    }

    /// <summary>
    /// Report Status
    /// </summary>
    [DefaultValue(ObjectStatus.None)]
    [DataContract]
    public enum ObjectStatus : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Pending")]
        [EnumMember(Value = "1")]
        Pending = 1,

        [Description("In-Progress")]
        [EnumMember(Value = "2")]
        InProgress = 2,

        [Description("Published")]
        [EnumMember(Value = "4")]
        Published = 4,

        [Description("Locked")]
        [EnumMember(Value = "9")]
        Locked = 9,
    }

    /// <summary>
    /// System Parameter
    /// </summary>
    [DefaultValue(SystemParameter.None)]
    [DataContract]
    public enum SystemParameter : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("code")]
        [EnumMember(Value = "1")]
        code = 1
    }

    /// <summary>
    /// Application End-Point Type
    /// </summary>
    [DefaultValue(EndPointType.None)]
    [DataContract]
    public enum EndPointType : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Database")]
        [EnumMember(Value = "1")]
        Database = 1,

        [Description("Web Service")]
        [EnumMember(Value = "2")]
        WebService = 2
    }

    /// <summary>
    /// Application Database Type
    /// </summary>
    [DefaultValue(ApplicationDatabaseType.None)]
    [DataContract]
    public enum ApplicationDatabaseType : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("SQL-Server")]
        [EnumMember(Value = "1")]
        SQLServer = 1,

        [Description("Oracle")]
        [EnumMember(Value = "2")]
        Oracle = 2,

        [Description("My SQL")]
        [EnumMember(Value = "3")]
        MySQL = 3,

        [Description("Sybase")]
        [EnumMember(Value = "4")]
        Sybase = 4
    }

    /// <summary>
    /// Integration Channel Type
    /// </summary>
    [DefaultValue(IntegrationChannelType.None)]
    [DataContract]
    public enum IntegrationChannelType : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Source")]
        [EnumMember(Value = "1")]
        Source = 1,

        [Description("Destination")]
        [EnumMember(Value = "2")]
        Destination = 2
    }

    /// <summary>
    /// Integration Adapter Query Type
    /// </summary>
    [DefaultValue(IntegrationOperatoinType.None)]
    [DataContract]
    public enum IntegrationOperatoinType : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Select")]
        [EnumMember(Value = "1")]
        Select = 1,

        [Description("Insert")]
        [EnumMember(Value = "2")]
        Insert = 2,

        [Description("Update")]
        [EnumMember(Value = "3")]
        Update = 3,

        [Description("Delete")]
        [EnumMember(Value = "4")]
        Delete = 4
    }

    /// <summary>
    /// Field Category
    /// </summary>
    [DefaultValue(FieldCategory.None)]
    [DataContract]
    public enum FieldCategory : byte
    {
        [Description("None")]
        [EnumMember(Value = "0")]
        None = 0,

        [Description("Standard")]
        [EnumMember(Value = "1")]
        Standard = 1,
    }
}