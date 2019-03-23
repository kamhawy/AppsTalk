using System;
using System.Collections.Generic;
using System.Web;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// Presenter Factory
    /// </summary>
    public static class PresenterFactory
    {
        #region Factory

        /// <summary>
        /// Get Presenter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pAppRuntime"></param>
        /// <param name="pSessionKey"></param>
        /// <returns></returns>
        public static T GetPresenter<T>(IAppRuntime pAppRuntime, string pSessionKey) where T : PresenterBase
        {
            T presenter = null;

            try
            {
                presenter = WebUtilities.GetSessionObject<T>(pSessionKey);

                if (presenter == null)
                {
                    presenter = Activator.CreateInstance(typeof(T), new object[] { pAppRuntime }, null) as T;

                    if (presenter != null)
                    {
                        WebUtilities.SetSessionObject(pSessionKey, presenter);
                    }
                }

            }
            catch { throw; }

            return presenter;
        }

        /// <summary>
        /// Remove Presenters From Session
        /// </summary>
        public static void RemovePresentersFromSession()
        {
            if (WebUtilities.IsSessionValid())
            {
                List<string> presenterKeys = new List<string>();

                foreach (string key in HttpContext.Current.Session.Keys)
                {
                    if (key.StartsWith("SK_Presenter"))
                    {
                        PresenterBase presenter = HttpContext.Current.Session[key] as PresenterBase;

                        if (presenter != null && presenter.IsDisposable)
                        {
                            presenter.Dispose();
                            presenter = null;
                            presenterKeys.Add(key);
                        }
                    }
                }

                foreach (string key in presenterKeys)
                {
                    HttpContext.Current.Session[key] = null;
                    HttpContext.Current.Session.Remove(key);
                }
            }
        }

        #endregion
    }
}