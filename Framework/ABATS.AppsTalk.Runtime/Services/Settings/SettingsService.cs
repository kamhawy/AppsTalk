#region

using System;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Settings
{
    /// <summary>
    ///     Settings Service
    /// </summary>
    [Serializable]
    internal class SettingsService : AppServiceBase, ISettingsService
    {
        #region Members

        private CommonSettingsInfo _commonSettings;

        #endregion

        #region Constructor

        internal SettingsService(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {
        }

        #endregion

        #region IRuntimeService

        /// <summary>
        ///     Initialize
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            bool success = false;

            try
            {
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #region ISettingsService

        #region Properties

        [DataMember]
        public CommonSettingsInfo CommonSettings
        {
            get { return _commonSettings ?? (_commonSettings = CommonSettingsInfo.Current); }
        }

        #endregion

        #endregion

        #region Factory

        internal static ISettingsService Create(IAppRuntime pIAppRuntime)
        {
            return new SettingsService(pIAppRuntime);
        }

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            if (_commonSettings != null)
            {
                _commonSettings.Dispose();
                _commonSettings = null;
            }

            base.DisposeManagedRessources();
        }

        #endregion
    }
}