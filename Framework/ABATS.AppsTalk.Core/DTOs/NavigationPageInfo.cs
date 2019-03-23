using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represents the Navigation Page
    /// </summary>
    [Serializable()]
    public class NavigationPageInfo : DisposableBase
    {
        #region Members

        private string _PageID = string.Empty;
        private string _PreviousPage = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public string PageID
        {
            get { return this._PageID; }
            set { this._PageID = value; }
        }

        [DataMember]
        public string PreviousPage
        {
            get { return this._PreviousPage; }
            set { this._PreviousPage = value; }
        }

        #endregion

        #region Constructors

        public NavigationPageInfo()
        {

        }

        public NavigationPageInfo(string pPageID, string pPreviousPage)
        {
            this.PageID = pPageID;
            this.PreviousPage = pPreviousPage;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            _PageID = null;
            _PreviousPage = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}