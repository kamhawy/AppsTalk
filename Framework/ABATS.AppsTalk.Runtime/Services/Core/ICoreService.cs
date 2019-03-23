#region

using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core
{
    /// <summary>
    ///     ICoreService
    /// </summary>
    public interface ICoreService : IAppService
    {
        #region Methods

        /// <summary>
        ///     Execute Integration Process
        /// </summary>
        /// <param name="pProcessExecutionRequest"></param>
        /// <returns></returns>
        ProcessExecutionResponse ExecuteIntegrationProcess(ProcessExecutionRequest pProcessExecutionRequest);

        #endregion
    }
}