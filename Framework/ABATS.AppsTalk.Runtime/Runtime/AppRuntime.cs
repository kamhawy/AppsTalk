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
    ///     Represents the internal implementation of the application runtime
    /// </summary>
    [Serializable]
    internal class AppRuntime : DisposableBase, IAppRuntime
    {
        #region Members

        private ICoreService _coreService;
        private IDataService _dataService;
        private IMetadataService _metadataService;
        private IReportsService _reportsService;
        private ISecurityService _securityService;
        private ISettingsService _settingsService;

        #endregion

        #region Constructors

        internal AppRuntime()
        {
            InitializeServices();
        }

        #endregion

        #region IAppRuntime

        #region Services

        /// <summary>
        ///     Data Service
        /// </summary>
        public IDataService DataService
        {
            get { return _dataService ?? (_dataService = Services.Data.DataService.Create(this)); }
            private set { _dataService = value; }
        }

        /// <summary>
        ///     Core Service
        /// </summary>
        public ICoreService CoreService
        {
            get { return _coreService ?? (_coreService = Services.Core.CoreService.Create(this)); }
            private set { _coreService = value; }
        }

        /// <summary>
        ///     Security Service
        /// </summary>
        public ISecurityService SecurityService
        {
            get { return _securityService ?? (_securityService = Services.Security.SecurityService.Create(this)); }
            private set { _securityService = value; }
        }

        /// <summary>
        ///     Settings Service
        /// </summary>
        public ISettingsService SettingsService
        {
            get { return _settingsService ?? (_settingsService = Services.Settings.SettingsService.Create(this)); }
            private set { _settingsService = value; }
        }

        /// <summary>
        ///     Metadata Service
        /// </summary>
        public IMetadataService MetadataService
        {
            get { return _metadataService ?? (_metadataService = Services.Metadata.MetadataService.Create(this)); }
            private set { _metadataService = value; }
        }

        /// <summary>
        ///     Reports Service
        /// </summary>
        public IReportsService ReportsService
        {
            get { return _reportsService ?? (_reportsService = Services.Reports.ReportsService.Create(this)); }
            private set { _reportsService = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Dispose Runtime Service - Have the ability to dispose one of the Runtime Services
        /// </summary>
        /// <param name="pRuntimeService"></param>
        /// <returns></returns>
        public bool DisposeRuntimeService(RuntimeService pRuntimeService)
        {
            bool success = false;

            try
            {
                switch (pRuntimeService)
                {
                    case RuntimeService.Data:
                    {
                        CoreUtilities.SafeDispose(ref _dataService);
                        success = true;
                    }
                        break;
                    case RuntimeService.Security:
                    {
                        CoreUtilities.SafeDispose(ref _securityService);
                        success = true;
                    }
                        break;
                    case RuntimeService.Settings:
                    {
                        CoreUtilities.SafeDispose(ref _settingsService);
                        success = true;
                    }
                        break;
                    case RuntimeService.Metadata:
                    {
                        CoreUtilities.SafeDispose(ref _metadataService);
                        success = true;
                    }
                        break;
                    case RuntimeService.Reports:
                    {
                        CoreUtilities.SafeDispose(ref _reportsService);
                        success = true;
                    }
                        break;
                    default:
                    {
                    }
                        break;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        ///     Initialize Services
        /// </summary>
        private void InitializeServices()
        {
            try
            {
                DataService.Initialize();
                CoreService.Initialize();
                SecurityService.Initialize();
                SettingsService.Initialize();
                MetadataService.Initialize();
                ReportsService.Initialize();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        #endregion

        #region Factory

        internal static IAppRuntime Create()
        {
            return new AppRuntime();
        }

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            if (_reportsService != null)
            {
                _reportsService.Dispose();
                _reportsService = null;
            }

            if (_metadataService != null)
            {
                _metadataService.Dispose();
                _metadataService = null;
            }

            if (_settingsService != null)
            {
                _settingsService.Dispose();
                _settingsService = null;
            }

            if (_securityService != null)
            {
                _securityService.Dispose();
                _securityService = null;
            }

            if (_dataService != null)
            {
                _dataService.Dispose();
                _dataService = null;
            }

            base.DisposeManagedRessources();
        }

        #endregion
    }
}