using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// System Web Utilities
    /// </summary>
    public static class WebUtilities
    {
        #region Misc Utilities

        /// <summary>
        /// Get Host IP
        /// </summary>
        /// <returns>The host machine IP</returns>
        public static string GetHostIP(string pHostName)
        {
            string ip = string.Empty;

            IPHostEntry ipEntry = Dns.GetHostEntry(pHostName);

            if (ipEntry != null)
            {
                IPAddress address = ipEntry.AddressList.LastOrDefault();

                if (address != null)
                {
                    ip = address.ToString();
                }
            }

            return ip;
        }

        /// <summary>
        /// Get Current Http Context Request URL
        /// </summary>
        /// <returns></returns>
        public static Uri GetRequestUri(System.Web.HttpContext pHttpContext)
        {
            Uri uri = null;

            if (pHttpContext != null && pHttpContext.Request != null)
            {
                uri = System.Web.HttpContext.Current.Request.Url;
            }

            return uri;
        }

        /// <summary>
        /// GetCurrentUserName
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUserName()
        {
            string userName = string.Empty;

            if (HttpContext.Current != null &&
                HttpContext.Current.Request != null &&
                HttpContext.Current.Request.LogonUserIdentity != null &&
                !string.IsNullOrEmpty(HttpContext.Current.Request.LogonUserIdentity.Name))
            {
                string[] userParts = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name.Split('\\');

                if (userParts.Length > 1)
                {
                    userName = userParts[1];
                }
            }
            else
            {
                userName = Constants.SystemUser;
            }

            return userName;
        }

        /// <summary>
        /// GetObjectFromQueryString
        /// </summary>
        /// <param name="pQueryStringKey"></param>
        /// <returns></returns>
        public static string GetObjectFromQueryString(string pQueryStringKey)
        {
            string retVal = string.Empty;

            if (HttpContext.Current != null &&
                HttpContext.Current.Request != null &&
                HttpContext.Current.Request.QueryString != null)
            {
                if (HttpContext.Current.Request.QueryString.AllKeys.Contains(pQueryStringKey))
                {
                    retVal = HttpContext.Current.Request.QueryString[pQueryStringKey];
                }
            }

            return retVal;
        }

        /// <summary>
        /// Add Custom Validator
        /// </summary>
        /// <param name="pUserControl"></param>
        /// <param name="pErrorMessage"></param>
        public static void AddCustomValidator(UserControl pUserControl, string pErrorMessage)
        {
            WebUtilities.AddCustomValidator(pUserControl.Page, pErrorMessage, Constants.DefaultValidationGroup);
        }

        /// <summary>
        /// Add Custom Validator
        /// </summary>
        /// <param name="pUserControl"></param>
        /// <param name="pErrorMessage"></param>
        /// <param name="pValidationGroup"></param>
        public static void AddCustomValidator(UserControl pUserControl, string pErrorMessage, string pValidationGroup)
        {
            WebUtilities.AddCustomValidator(pUserControl.Page, pErrorMessage, pValidationGroup);
        }

        /// <summary>
        /// Add Page Custom Validator
        /// </summary>
        /// <param name="pPage"></param>
        /// <param name="pErrorMessage"></param>
        public static void AddCustomValidator(Page pPage, string pErrorMessage)
        {
            WebUtilities.AddCustomValidator(pPage, pErrorMessage, Constants.DefaultValidationGroup);
        }

        /// <summary>
        /// Add Page Custom Validator
        /// </summary>
        /// <param name="pPage"></param>
        /// <param name="pErrorMessage"></param>
        /// <param name="pValidationGroup"></param>
        public static void AddCustomValidator(Page pPage, string pErrorMessage, string pValidationGroup)
        {
            using (CustomValidator custValidator = new CustomValidator())
            {
                custValidator.ValidationGroup = pValidationGroup;
                custValidator.IsValid = false;
                custValidator.ErrorMessage = pErrorMessage;

                pPage.Validators.Add(custValidator);
            }
        }

        /// <summary>
        /// Get Page Firendly Name
        /// </summary>
        /// <param name="pHttpRequest"></param>
        /// <returns></returns>
        public static string GetPageFirendlyName(HttpRequest pHttpRequest)
        {
            string pageFirendlyName = string.Empty;

            if (pHttpRequest != null &&
               !string.IsNullOrEmpty(pHttpRequest.Path))
            {
                string fullPath = pHttpRequest.Path;

                pageFirendlyName = fullPath.Substring(pHttpRequest.ApplicationPath.Length + 1);
            }

            return pageFirendlyName;
        }

        /// <summary>
        /// Get Application Full Path
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationFullPath()
        {
            string appFullPath = string.Empty;

            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                appFullPath = WebUtilities.GetApplicationFullPath(HttpContext.Current.Request);
            }

            return appFullPath;
        }

        /// <summary>
        /// Get Application Full Path
        /// </summary>
        /// <param name="pHttpRequest"></param>
        /// <returns></returns>
        public static string GetApplicationFullPath(HttpRequest pHttpRequest)
        {
            string appFullPath = string.Empty;

            if (pHttpRequest != null && pHttpRequest.Url != null)
            {
                appFullPath = string.Format("{0}://{1}{2}",
                    pHttpRequest.Url.Scheme,
                    pHttpRequest.Url.Authority,
                    pHttpRequest.ApplicationPath);
            }

            return appFullPath;
        }

        /// <summary>
        /// Get Active Image Path
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public static string GetActiveImagePath(bool pIsActive)
        {
            return pIsActive ? @"~/Contents/Images/Status/De-Activate.png" : "~/Contents/Images/Status/Published.png";
        }

        /// <summary>
        /// Clear App Root Symbol (~/)
        /// </summary>
        /// <param name="pFullPath"></param>
        /// <returns></returns>
        public static string ClearAppRootSymbol(string pFullPath)
        {
            string clearPath = pFullPath;

            if (clearPath.StartsWith("~/"))
            {
                clearPath = clearPath.Substring(2);
            }

            return clearPath;
        }

        #endregion

        #region Session Utilities

        /// <summary>
        /// Used to get object instance from Current Context Session by key
        /// </summary>
        /// <param name="pKey">Session object Key</param>
        /// <returns>Session object instance</returns>
        public static object GetSessionObject(string pKey)
        {
            object obj = default(object);

            try
            {
                if (WebUtilities.IsSessionValid())
                {
                    obj = HttpContext.Current.Session[pKey];
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return obj;
        }

        /// <summary>
        /// Used to get object instance from Current Context Session by key
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="pKey">Session object Key</param>
        /// <returns>Session object instance</returns>
        public static T GetSessionObject<T>(string pKey) where T : class
        {
            T obj = default(T);

            try
            {
                if (WebUtilities.IsSessionValid())
                {
                    obj = HttpContext.Current.Session[pKey] as T;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return obj;
        }

        /// <summary>
        /// Used to get object instance from Current Context Session by key
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="pKey">Session object Key</param>
        /// <returns>Session object instance</returns>
        public static T GetSessionObject<T>() where T : class
        {
            T obj = default(T);

            try
            {
                if (WebUtilities.IsSessionValid())
                {
                    foreach (string itemKey in HttpContext.Current.Session.Keys)
                    {
                        obj = HttpContext.Current.Session[itemKey] as T;

                        if (obj != null)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return obj;
        }

        /// <summary>
        /// Used to get object instance from Current Context Session by key
        /// </summary>
        /// <typeparam name="U">Type of object</typeparam>
        /// <param name="pKey">Session object Key</param>
        /// <returns>Session object instance</returns>
        public static U GetSessionStruct<U>(string pKey) where U : struct
        {
            U obj = default(U);

            try
            {
                if (WebUtilities.IsSessionValid())
                {
                    obj = (U)HttpContext.Current.Session[pKey];
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return obj;
        }

        /// <summary>
        /// Used to store an object instance in the Current Context Session
        /// </summary>
        /// <param name="pKey">Session object key</param>
        /// <param name="pObject">Session object instance</param>
        public static bool SetSessionObject(string pKey, object pObject)
        {
            bool success = false;

            try
            {
                if (WebUtilities.IsSessionValid())
                {
                    HttpContext.Current.Session[pKey] = pObject;
                    success = true;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        /// <summary>
        /// Used to Remove object instance from Current Context Session by key
        /// </summary>
        /// <param name="pKey">Session object Key</param>
        public static void RemoveSessionObject(string pKey)
        {
            try
            {
                if (IsSessionValid() && HttpContext.Current.Session[pKey] != null)
                {
                    HttpContext.Current.Session[pKey] = null;
                    HttpContext.Current.Session.Remove(pKey);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        /// Is Session Valid
        /// </summary>
        /// <returns></returns>
        public static bool IsSessionValid()
        {
            bool valid = false;

            try
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        valid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return valid;
        }

        /// <summary>
        /// Is Session Expired
        /// </summary>
        /// <returns></returns>
        public static bool IsSessionExpired()
        {
            bool expired = false;

            try
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        if (HttpContext.Current.Session.IsNewSession)
                        {
                            string CookieHeaders = HttpContext.Current.Request.Headers["Cookie"];

                            if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
                            {
                                // IsNewSession is true, but session cookie exists, so, ASP.NET session is expired
                                expired = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return expired;
        }

        #endregion

        #region ViewState Utilities

        /// <summary>
        /// Used to get object instance from Current ViewState by key
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="pKey">ViewState object Key</param>
        /// <returns>ViewState object instance</returns>
        public static T GetViewStateObject<T>(this StateBag pStateBag, string pKey) where T : class
        {
            T obj = default(T);

            try
            {
                if (pStateBag != null)
                {
                    obj = pStateBag[pKey] as T;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return obj;
        }

        /// <summary>
        /// Used to store an object instance in the Current ViewState
        /// </summary>
        /// <param name="pKey">ViewState object key</param>
        /// <param name="pObject">ViewState object instance</param>
        public static bool SetViewStateObject(this StateBag pStateBag, string pKey, object pObject)
        {
            bool success = false;

            try
            {
                if (pStateBag != null)
                {
                    pStateBag[pKey] = pObject;
                    success = true;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #region Cache Utilities

        /// <summary>
        /// Used to get object instance from Current Context Cache by key
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="pKey">Cache object Key</param>
        /// <returns>Cache object instance</returns>
        public static T GetCacheObject<T>(string pKey) where T : class
        {
            T obj = default(T);

            try
            {
                if (WebUtilities.IsCacheOValid())
                {
                    obj = HttpContext.Current.Cache[pKey] as T;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
            return obj;
        }

        /// <summary>
        /// Used to store an object instance in the Current Context Cache
        /// </summary>
        /// <param name="pKey">Cache object key</param>
        /// <param name="pObject">Cache object instance</param>
        public static bool SetCacheObject(string pKey, object pObject)
        {
            bool success = false;

            try
            {
                if (WebUtilities.IsCacheOValid())
                {
                    HttpContext.Current.Cache[pKey] = pObject;
                    success = true;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        /// <summary>
        /// Is Cache Valid
        /// </summary>
        /// <returns></returns>
        public static bool IsCacheOValid()
        {
            bool valid = false;

            try
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Cache != null)
                    {
                        valid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return valid;
        }

        #endregion
    }
}