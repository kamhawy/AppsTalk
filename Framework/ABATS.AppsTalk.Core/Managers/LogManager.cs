using System;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Log Manager
    /// </summary>
    public static class LogManager
    {
        #region Methods

        /// <summary>
        /// Log Exception
        /// </summary>
        /// <param name="ex"></param>
        public static void LogException(Exception ex, string pExtraMessage = "")
        {
            EventLogger.WriteError(ex, pExtraMessage);
        }

        /// <summary>
        /// Log Message
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pOperationStatus"></param>
        public static void LogMessage(string pMessage, OperationStatus pOperationStatus = OperationStatus.Succeeded)
        {
            switch (pOperationStatus)
            {
                case OperationStatus.Succeeded:
                default:
                    {
                        EventLogger.WriteInformation(pMessage);
                    }
                    break;
                case OperationStatus.Failed:
                    {
                        EventLogger.WriteError(pMessage);
                    }
                    break;
            }
        }

        #endregion
    }

    /// <summary>
    /// Represent the Event Logger
    /// </summary>
    internal static class EventLogger
    {
        #region Members

        private static EventLog _EventLogger = EventLogger.InitializeEventLog();
        private const string EVENT_LOG_SOURCE_NAME = "Application";
        private const string EVENT_LOG_LOG_NAME = "Application";
        private const string EVENT_LOG_MESSAGES_FILE = "";

        #endregion

        #region Methods

        #region Initialization

        private static EventLog InitializeEventLog()
        {
            EventLog eventLogger = new EventLog();

            if (!EventLog.SourceExists(EventLogger.EVENT_LOG_SOURCE_NAME))
            {
                EventSourceCreationData data = new EventSourceCreationData(EventLogger.EVENT_LOG_SOURCE_NAME, EventLogger.EVENT_LOG_LOG_NAME);
                //data.MessageResourceFile = EventLogger.EVENT_LOG_MESSAGES_FILE;
                //data.ParameterResourceFile = EventLogger.EVENT_LOG_MESSAGES_FILE;
                //data.CategoryResourceFile = EventLogger.EVENT_LOG_MESSAGES_FILE;

                EventLog.CreateEventSource(data);
            }

            eventLogger.Source = EVENT_LOG_SOURCE_NAME;

            return eventLogger;
        }

        #endregion

        #region Error

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="message"></param>
        public static void WriteError(string message)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Error);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        public static void WriteError(string message, int eventId)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Error, eventId);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteError(string message, int eventId, short category)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Error, eventId, category);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteError(string message, int eventId, short category, byte[] rawData)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Error, eventId, category, rawData);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void WriteError(string format, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Error);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        public static void WriteError(string format, int eventId, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Error, eventId);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="parameters"></param>
        public static void WriteError(string format, int eventId, short category, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Error, eventId, category);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        /// <param name="parameters"></param>
        public static void WriteError(string format, int eventId, short category, byte[] rawData, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Error, eventId, category, rawData);
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="error"></param>
        public static void WriteError(Exception error, string pExtraMessage = "")
        {
            if (error != null)
            {
                string formatedMessage = error.Message;

                if (!string.IsNullOrEmpty(pExtraMessage))
                {
                    formatedMessage += string.Format("{0}{0}-Extra Message:{0}{1}", Environment.NewLine, pExtraMessage);
                }

                string strError = Properties.Resources.Exception_Template
                    .Replace("$Message$", formatedMessage)
                    .Replace("$Source$", error.Source)
                    .Replace("$StackTrace$", error.StackTrace);

                if (error.InnerException != null)
                {
                    strError += Properties.Resources.InnerException_Template
                        .Replace("$Message$", error.InnerException.Message)
                        .Replace("$Source$", error.InnerException.Source)
                        .Replace("$StackTrace$", error.InnerException.StackTrace);

                    if (error.InnerException.InnerException != null)
                    {
                        strError += Properties.Resources.InnerException_Template
                            .Replace("$Message$", error.InnerException.InnerException.Message)
                            .Replace("$Source$", error.InnerException.InnerException.Source)
                            .Replace("$StackTrace$", error.InnerException.InnerException.StackTrace);
                    }
                }

                if (error is DbEntityValidationException)
                {
                    string strValidationErrors = string.Format("{1}{1}{0}{1}{1}", "Validation Errors:", Environment.NewLine);

                    DbEntityValidationException dbValidationError = error as DbEntityValidationException;

                    foreach (var validationError in dbValidationError.EntityValidationErrors)
                    {
                        foreach (var errorItem in validationError.ValidationErrors)
                        {
                            strValidationErrors += string.Format("{0}{1}", errorItem.ErrorMessage, Environment.NewLine);
                        }
                    }

                    strError += strValidationErrors;
                }

                _EventLogger.WriteEntry(strError, EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="error"></param>
        /// <param name="eventId"></param>
        public static void WriteError(Exception error, int eventId)
        {
            if (error != null)
            {
                _EventLogger.WriteEntry(error.Message, EventLogEntryType.Error, eventId);
            }
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="error"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteError(Exception error, int eventId, short category)
        {
            if (error != null)
            {
                _EventLogger.WriteEntry(error.Message, EventLogEntryType.Error, eventId, category);
            }
        }

        /// <summary>
        /// Write Error
        /// </summary>
        /// <param name="error"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteError(Exception error, int eventId, short category, byte[] rawData)
        {
            if (error != null)
            {
                _EventLogger.WriteEntry(error.Message, EventLogEntryType.Error, eventId, category, rawData);
            }
        }

        #endregion

        #region Failure Audit

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="message"></param>
        public static void WriteFailureAudit(string message)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.FailureAudit);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        public static void WriteFailureAudit(string message, int eventId)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.FailureAudit, eventId);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteFailureAudit(string message, int eventId, short category)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.FailureAudit, eventId, category);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteFailureAudit(string message, int eventId, short category, byte[] rawData)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.FailureAudit, eventId, category, rawData);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void WriteFailureAudit(string format, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.FailureAudit);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        public static void WriteFailureAudit(string format, int eventId, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.FailureAudit, eventId);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="parameters"></param>
        public static void WriteFailureAudit(string format, int eventId, short category, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.FailureAudit, eventId, category);
        }

        /// <summary>
        /// Write Failure Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        /// <param name="parameters"></param>
        public static void WriteFailureAudit(string format, int eventId, short category, byte[] rawData, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.FailureAudit, eventId, category, rawData);
        }

        #endregion

        #region Information

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="message"></param>
        public static void WriteInformation(string message)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        public static void WriteInformation(string message, int eventId)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Information, eventId);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteInformation(string message, int eventId, short category)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Information, eventId, category);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteInformation(string message, int eventId, short category, byte[] rawData)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Information, eventId, category, rawData);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void WriteInformation(string format, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Information);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        public static void WriteInformation(string format, int eventId, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Information, eventId);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="parameters"></param>
        public static void WriteInformation(string format, int eventId, short category, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Information, eventId, category);
        }

        /// <summary>
        /// Write Information
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        /// <param name="parameters"></param>
        public static void WriteInformation(string format, int eventId, short category, byte[] rawData, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Information, eventId, category, rawData);
        }

        #endregion

        #region Success Audit

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="message"></param>
        public static void WriteSuccessAudit(string message)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.SuccessAudit);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        public static void WriteSuccessAudit(string message, int eventId)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.SuccessAudit, eventId);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteSuccessAudit(string message, int eventId, short category)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.SuccessAudit, eventId, category);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteSuccessAudit(string message, int eventId, short category, byte[] rawData)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.SuccessAudit, eventId, category, rawData);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void WriteSuccessAudit(string format, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.SuccessAudit);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        public static void WriteSuccessAudit(string format, int eventId, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.SuccessAudit, eventId);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="parameters"></param>
        public static void WriteSuccessAudit(string format, int eventId, short category, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.SuccessAudit, eventId, category);
        }

        /// <summary>
        /// Write Success Audit
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        /// <param name="parameters"></param>
        public static void WriteSuccessAudit(string format, int eventId, short category, byte[] rawData, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.SuccessAudit, eventId, category, rawData);
        }

        #endregion

        #region Warning

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="message"></param>
        public static void WriteWarning(string message)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        public static void WriteWarning(string message, int eventId)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Warning, eventId);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteWarning(string message, int eventId, short category)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Warning, eventId, category);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteWarning(string message, int eventId, short category, byte[] rawData)
        {
            _EventLogger.WriteEntry(message, EventLogEntryType.Warning, eventId, category, rawData);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="format"></param>
        /// <param name="parameters"></param>
        public static void WriteWarning(string format, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Warning);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        public static void WriteWarning(string format, int eventId, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Warning, eventId);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="parameters"></param>
        public static void WriteWarning(string format, int eventId, short category, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Warning, eventId, category);
        }

        /// <summary>
        /// Write Warning
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        /// <param name="parameters"></param>
        public static void WriteWarning(string format, int eventId, short category, byte[] rawData, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), EventLogEntryType.Warning, eventId, category, rawData);
        }

        #endregion

        #region Entry

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventLogEntryType"></param>
        public static void WriteEntry(string message, EventLogEntryType eventLogEntryType)
        {
            _EventLogger.WriteEntry(message, eventLogEntryType);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="eventId"></param>
        public static void WriteEntry(string message, EventLogEntryType eventLogEntryType, int eventId)
        {
            _EventLogger.WriteEntry(message, eventLogEntryType, eventId);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        public static void WriteEntry(string message, EventLogEntryType eventLogEntryType, int eventId, short category)
        {
            _EventLogger.WriteEntry(message, eventLogEntryType, eventId, category);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="message"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        public static void WriteEntry(string message, EventLogEntryType eventLogEntryType, int eventId, short category, byte[] rawData)
        {
            _EventLogger.WriteEntry(message, eventLogEntryType, eventId, category, rawData);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="parameters"></param>
        public static void WriteEntry(string format, EventLogEntryType eventLogEntryType, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), eventLogEntryType);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="eventId"></param>
        /// <param name="parameters"></param>
        public static void WriteEntry(string format, EventLogEntryType eventLogEntryType, int eventId, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), eventLogEntryType, eventId);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="parameters"></param>
        public static void WriteEntry(string format, EventLogEntryType eventLogEntryType, int eventId, short category, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), eventLogEntryType, eventId, category);
        }

        /// <summary>
        /// Write Entry
        /// </summary>
        /// <param name="format"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="eventId"></param>
        /// <param name="category"></param>
        /// <param name="rawData"></param>
        /// <param name="parameters"></param>
        public static void WriteEntry(string format, EventLogEntryType eventLogEntryType, int eventId, short category, byte[] rawData, params object[] parameters)
        {
            _EventLogger.WriteEntry(String.Format(format, parameters), eventLogEntryType, eventId, category, rawData);
        }

        #endregion

        #region Event

        /// <summary>
        /// Write Event
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="categoryId"></param>
        /// <param name="values"></param>
        public static void WriteEvent(long instanceId, int categoryId, params object[] values)
        {
            _EventLogger.WriteEvent(new EventInstance(instanceId, categoryId), values);
        }

        /// <summary>
        /// Write Event
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="categoryId"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="values"></param>
        public static void WriteEvent(long instanceId, int categoryId, EventLogEntryType eventLogEntryType, params object[] values)
        {
            _EventLogger.WriteEvent(new EventInstance(instanceId, categoryId, eventLogEntryType), values);
        }

        /// <summary>
        /// Write Event
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="categoryId"></param>
        /// <param name="data"></param>
        /// <param name="values"></param>
        public static void WriteEvent(long instanceId, int categoryId, byte[] data, params object[] values)
        {
            _EventLogger.WriteEvent(new EventInstance(instanceId, categoryId), data, values);
        }

        /// <summary>
        /// Write Event
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="categoryId"></param>
        /// <param name="eventLogEntryType"></param>
        /// <param name="data"></param>
        /// <param name="values"></param>
        public static void WriteEvent(long instanceId, int categoryId, EventLogEntryType eventLogEntryType, byte[] data, params object[] values)
        {
            _EventLogger.WriteEvent(new EventInstance(instanceId, categoryId, eventLogEntryType), data, values);
        }

        /// <summary>
        /// Write Event
        /// </summary>
        /// <param name="eventInstance"></param>
        /// <param name="values"></param>
        public static void WriteEvent(EventInstance eventInstance, params object[] values)
        {
            _EventLogger.WriteEvent(eventInstance, values);
        }

        /// <summary>
        /// Write Event
        /// </summary>
        /// <param name="eventInstance"></param>
        /// <param name="data"></param>
        /// <param name="values"></param>
        public static void WriteEvent(EventInstance eventInstance, byte[] data, params object[] values)
        {
            _EventLogger.WriteEvent(eventInstance, data, values);
        }

        #endregion

        #endregion
    }
}