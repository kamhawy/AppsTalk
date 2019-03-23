#region

using System;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime.Services.Core;
using ABATS.AppsTalk.Runtime.Services.Data;
using ABATS.AppsTalk.Runtime.Services.Metadata;
using ABATS.AppsTalk.Runtime.Services.Reports;
using ABATS.AppsTalk.Runtime.Services.Security;
using ABATS.AppsTalk.Runtime.Services.Settings;

#endregion

namespace ABATS.AppsTalk.Runtime
{
    /// <summary>
    ///     Represents the application runtime interface
    /// </summary>
    public interface IAppRuntime : IDisposable
    {
        #region Services

        /// <summary>
        ///     Data Service
        /// </summary>
        IDataService DataService { get; }

        /// <summary>
        ///     Core Service
        /// </summary>
        ICoreService CoreService { get; }

        /// <summary>
        ///     Security Service
        /// </summary>
        ISecurityService SecurityService { get; }

        /// <summary>
        ///     Settings Service
        /// </summary>
        ISettingsService SettingsService { get; }

        /// <summary>
        ///     Metadata Service
        /// </summary>
        IMetadataService MetadataService { get; }

        /// <summary>
        ///     Reports Service
        /// </summary>
        IReportsService ReportsService { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Dispose Runtime Service - Have the ability to dispose one of the Runtime Services
        /// </summary>
        /// <param name="pRuntimeService"></param>
        /// <returns></returns>
        bool DisposeRuntimeService(RuntimeService pRuntimeService);

        #endregion
    }
}