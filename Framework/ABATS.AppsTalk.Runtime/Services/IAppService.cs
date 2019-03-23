#region

using System;

#endregion

namespace ABATS.AppsTalk.Runtime.Services
{
    /// <summary>
    ///     IAppService
    /// </summary>
    public interface IAppService : IDisposable
    {
        #region Methods

        /// <summary>
        ///     Initialize
        /// </summary>
        /// <returns></returns>
        bool Initialize();

        #endregion
    }
}