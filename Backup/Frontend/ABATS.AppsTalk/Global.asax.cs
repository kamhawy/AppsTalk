using System;
using System.Web;
using System.Web.UI;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk
{
    /// <summary>
    /// Global Application Class
    /// </summary>
    public class Global : HttpApplication
    {
        #region Overrides

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Init()
        {
            base.Init();

            this.Error += new EventHandler(this.Application_Error);
            this.BeginRequest += new EventHandler(this.Application_BeginRequest);
            this.EndRequest += new EventHandler(this.Application_EndRequest);
        }

        #endregion

        #region Application Global Events

        /// <summary>
        /// Application Start Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Application Error Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lastErrorWrapper = Server.GetLastError() as Exception;
            string extraMessage = string.Empty;

            if (lastErrorWrapper != null)
            {
                if (sender is Page)
                {
                    extraMessage = string.Format("Source Page Relative Virtual Path: {0}", (sender as Page).AppRelativeVirtualPath);
                }
                else if (sender != null)
                {
                    extraMessage = sender.ToString();
                }

                LogManager.LogException(lastErrorWrapper, extraMessage);
                Server.ClearError();
            }
        }

        /// <summary>
        /// Application Begin Request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Application End Request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(object sender, EventArgs e)
        {

        }

        #endregion
    }
}