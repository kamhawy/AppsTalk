#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime.Common.Requests;
using ABATS.AppsTalk.Runtime.Common.Responses;

#endregion

namespace ABATS.AppsTalk.Runtime
{
    /// <summary>
    ///     Execution Manager
    /// </summary>
    public class ExecutionManager : DisposableBase
    {
        #region Members

        protected object Lockobj = new object();
        private List<ProcessInfo> _processes = null;

        #endregion

        #region Properties

        protected List<ProcessInfo> Processes
        {
            get
            {
                return _processes ?? (_processes = new List<ProcessInfo>());
            }
            private set
            {
                _processes = value;
            }
        }

        #endregion

        #region Constructor

        #endregion

        #region Methods

        /// <summary>
        ///     Try Execute
        /// </summary>
        /// <param name="pParameters"></param>
        public void TryExecute(List<ParameterInfo> pParameters)
        {
            Task<ProcessResult>[] tasks = null;

            try
            {
                if (pParameters == null)
                    return;

                foreach (ProcessInfo process in
                            pParameters.Where(c => c.SystemParameter == SystemParameter.code)
                                .Select(param => new ProcessInfo(Guid.NewGuid().ToString(), param.ParameterValue)))
                {
                    Processes.Add(process);

                    process.ProcessTask = Task<ProcessResult>.Factory.StartNew(() =>
                    {
                        ProcessResult result = null;

                        lock (Lockobj)
                        {
                            using (IAppRuntime appRuntime = AppRuntimeFactory.CreateAppRuntime(false))
                            {
                                using (ProcessExecutionRequest request = new ProcessExecutionRequest
                                    {
                                        ProcessCode = process.ProcessCode
                                    })
                                {
                                    using (ProcessExecutionResponse response =
                                            appRuntime.CoreService.ExecuteIntegrationProcess(request))
                                    {
                                        //TODO:
                                        //Build ProcessResult(result) from the ProcessExecutionResponse(response)
                                    }
                                }
                            }
                        }

                        return result;
                    });
                }

                tasks = Processes.Where(c => c.ProcessTask != null).Select(c => c.ProcessTask).ToArray();

                if (tasks != null && tasks.Length > 0)
                {
                    Task.WaitAll(tasks);

                    Processes.Where(c => c.ProcessTask != null).ToList().ForEach(c =>
                        c.Result = c.ProcessTask.Result);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
            finally
            {
                tasks = null;
            }
        }

        #endregion
    }
}