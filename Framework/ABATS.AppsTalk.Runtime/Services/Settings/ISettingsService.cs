#region

using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Settings
{
    /// <summary>
    ///     ISettingsService
    /// </summary>
    public interface ISettingsService : IAppService
    {
        #region Properties

        /// <summary>
        ///     Common Settings
        /// </summary>
        CommonSettingsInfo CommonSettings { get; }

        #endregion
    }
}