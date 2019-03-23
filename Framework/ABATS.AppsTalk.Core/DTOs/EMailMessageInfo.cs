using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// EMailMessageInfo
    /// </summary>
    [Serializable]
    public class EMailMessageInfo : DisposableBase
    {
        #region Members

        private string _From = string.Empty;
        private string _To = string.Empty;
        private string _CC = string.Empty;
        private string _Bcc = string.Empty;
        private string _Subject = string.Empty;
        private string _Body = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public string From
        {
            get { return this._From; }
            set { this._From = value; }
        }

        [DataMember]
        public string To
        {
            get { return this._To; }
            set { this._To = value; }
        }

        [DataMember]
        public string CC
        {
            get { return this._CC; }
            set { this._CC = value; }
        }

        [DataMember]
        public string Bcc
        {
            get { return this._Bcc; }
            set { this._Bcc = value; }
        }

        [DataMember]
        public string Subject
        {
            get { return this._Subject; }
            set { this._Subject = value; }
        }

        [DataMember]
        public string Body
        {
            get { return this._Body; }
            set { this._Body = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// EMailMessageInfo
        /// </summary>
        public EMailMessageInfo()
        {

        }

        /// <summary>
        /// EMailMessageInfo
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        /// <param name="pCC"></param>
        /// <param name="pBcc"></param>
        /// <param name="pSubject"></param>
        /// <param name="pBody"></param>
        public EMailMessageInfo(string pFrom, string pTo, string pCC, string pBcc, string pSubject, string pBody)
        {
            this.From = pFrom;
            this.To = pTo;
            this.CC = pCC;
            this.Bcc = pBcc;
            this.Subject = pSubject;
            this.Body = pBody;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            _From = null;
            _To = null;
            _CC = null;
            _Bcc = null;
            _Subject = null;
            _Body = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}