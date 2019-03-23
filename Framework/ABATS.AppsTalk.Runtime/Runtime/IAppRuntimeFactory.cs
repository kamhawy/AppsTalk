#region

using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime
{
    /// <summary>
    ///     IAppRuntimeFactory
    /// </summary>
    public static class AppRuntimeFactory
    {
        #region Factory

        /// <summary>
        ///     Create an instance of the IAppRuntime
        /// </summary>
        /// <param name="pCheckSession"></param>
        /// <returns></returns>
        public static IAppRuntime CreateAppRuntime(bool pCheckSession)
        {
            IAppRuntime appRunTime = null;

            try
            {
                if (pCheckSession)
                {
                    appRunTime = WebUtilities.GetSessionObject<IAppRuntime>(Constants.SessionKey_IAppRuntime);
                }

                if (appRunTime == null)
                {
                    appRunTime = AppRuntime.Create();
                }

                if (pCheckSession)
                {
                    WebUtilities.SetSessionObject(Constants.SessionKey_IAppRuntime, appRunTime);
                }
            }
            catch
            {
                throw;
            }

            return appRunTime;
        }

        /// <summary>
        ///     Dispose IAppRuntime
        /// </summary>
        /// <param name="pIAppRuntime"></param>
        /// <param name="pCheckSession"></param>
        public static void DisposeAppRuntime(IAppRuntime pIAppRuntime, bool pCheckSession)
        {
            try
            {
                if (pIAppRuntime == null && pCheckSession)
                {
                    pIAppRuntime = WebUtilities.GetSessionObject<IAppRuntime>(Constants.SessionKey_IAppRuntime);
                }

                if (pIAppRuntime != null)
                {
                    pIAppRuntime.Dispose();
                    pIAppRuntime = null;
                }

                if (pCheckSession)
                {
                    WebUtilities.RemoveSessionObject(Constants.SessionKey_IAppRuntime);
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}