using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// History Manager
    /// </summary>
    public class HistoryManager : AppRuntimeComponent
    {
        #region Members

        private List<HistoryPointInfo> _HistoryPoints = null;

        #endregion

        #region Properties

        public List<HistoryPointInfo> HistoryPoints
        {
            get
            {
                if (this._HistoryPoints == null)
                {
                    this._HistoryPoints = new List<HistoryPointInfo>();
                }

                return this._HistoryPoints;
            }
            set
            {
                this._HistoryPoints = value;
            }
        }

        #endregion

        #region Constructors

        public HistoryManager(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Add History Point
        /// </summary>
        /// <param name="pNewURL"></param>
        /// <param name="pHistoryURL"></param>
        public void AddHistoryPoint(string pKey, string pHistoryURL)
        {
            bool performAdd = true;

            try
            {
                HistoryPointInfo item = this.HistoryPoints.FirstOrDefault(c => c.Key == pKey);

                if (item != null && this.HistoryPoints.IndexOf(item) == 0)
                {
                    performAdd = false;
                }

                if (performAdd)
                {
                    this.HistoryPoints.Add(new HistoryPointInfo(pKey, pHistoryURL));
                }
            }
            catch (System.Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        /// Remove History Point
        /// </summary>
        /// <param name="pKey"></param>
        public void RemoveHistoryPoint(string pKey)
        {
            try
            {
                HistoryPointInfo item = this.HistoryPoints.FirstOrDefault(c => c.Key == pKey);

                if (item != null)
                {
                    this.HistoryPoints.Remove(item);
                }
            }
            catch (System.Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        /// Get History Point
        /// </summary>
        /// <param name="pKey"></param>
        public string GetHistoryPointURL(string pKey)
        {
            string historyPointURL = string.Empty;

            try
            {
                HistoryPointInfo item = this.HistoryPoints.FirstOrDefault(c => c.Key == pKey);

                if (item != null)
                {
                    historyPointURL = item.HistoryURL;
                }
            }
            catch (System.Exception ex)
            {
                LogManager.LogException(ex);
            }

            return historyPointURL;
        }

        #endregion

        #region Factory

        /// <summary>
        /// Get History Manager
        /// </summary>
        /// <param name="pAppRuntime"></param>
        /// <param name="pSessionKey"></param>
        /// <returns></returns>
        public static HistoryManager GetHistoryManager(IAppRuntime pAppRuntime, string pSessionKey)
        {
            HistoryManager manager = null;

            try
            {
                manager = WebUtilities.GetSessionObject<HistoryManager>(pSessionKey);

                if (manager == null)
                {
                    manager = Activator.CreateInstance(typeof(HistoryManager), new object[] { pAppRuntime }, null) as HistoryManager;

                    if (manager != null)
                    {
                        WebUtilities.SetSessionObject(pSessionKey, manager);
                    }
                }

            }
            catch { throw; }

            return manager;
        }

        #endregion
    }

    /// <summary>
    /// History Point Info
    /// </summary>
    [Serializable]
    public class HistoryPointInfo : DisposableBase
    {
        #region Members

        private string _Key = string.Empty;
        private string _HistoryURL = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public string Key
        {
            get { return this._Key; }
            set { this._Key = value; }
        }

        [DataMember]
        public string HistoryURL
        {
            get { return this._HistoryURL; }
            set { this._HistoryURL = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// History Point Info
        /// </summary>
        public HistoryPointInfo()
        {

        }

        /// <summary>
        /// History Point Info
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pHistoryURL"></param>
        public HistoryPointInfo(string pKey, string pHistoryURL)
        {
            this.Key = pKey;
            this.HistoryURL = pHistoryURL;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            this._Key = null;
            this._HistoryURL = null;
            base.DisposeManagedRessources();
        }

        #endregion
    }
}