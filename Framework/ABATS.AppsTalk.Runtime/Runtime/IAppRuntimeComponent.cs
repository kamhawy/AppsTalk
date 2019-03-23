using System;

namespace ABATS.AppsTalk.Runtime
{
    /// <summary>
    /// IAppRuntimeComponent
    /// </summary>
    interface IAppRuntimeComponent : IDisposable
    {
        /// <summary>
        /// AppRuntime
        /// </summary>
        IAppRuntime AppRuntime { get; }
    }
}