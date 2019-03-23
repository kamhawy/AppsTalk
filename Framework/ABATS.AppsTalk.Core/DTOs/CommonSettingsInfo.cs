using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Common Settings Info
    /// </summary>
    [Serializable]
    public class CommonSettingsInfo : DisposableBase
    {
        #region Members

        private string _Skin = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public string Skin
        {
            get { return this._Skin; }
            set { this._Skin = value; }
        }

        #endregion

        #region Static Properties

        [DataMember]
        public static CommonSettingsInfo Current
        {
            get
            {
                return CommonSettingsInfo.GetCommonSettingsInfo();
            }
        }

        [DataMember]
        public static string CurrentUser
        {
            get
            {
                return WebUtilities.GetCurrentUserName();
            }
        }

        #endregion

        #region Constructors

        public CommonSettingsInfo()
        {

        }

        #endregion

        #region Helpers

        /// <summary>
        /// GetCommonSettingsInfo
        /// </summary>
        /// <returns></returns>
        private static CommonSettingsInfo GetCommonSettingsInfo()
        {
            return new CommonSettingsInfo()
            {
                Skin = CoreUtilities.GetSettingsItemValue(SettingsKey.Skin),
            };
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            this._Skin = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}