using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// UserInfo
    /// </summary>
    [Serializable]
    public class UserInfo : DTOBase
    {
        #region Members

        private int _ApplicationUserID = -1;
        private string _UserName = "Visitor";
        private string _FullName = "Visitor";
        private string _EMail = string.Empty;
        private string _StaffNumber = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public int ApplicationUserID
        {
            get
            {
                return this._ApplicationUserID;
            }
            set
            {
                this._ApplicationUserID = value;
            }
        }

        [DataMember]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        [DataMember]
        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {
                this._FullName = value;
            }
        }

        [DataMember]
        public string EMail
        {
            get
            {
                return this._EMail;
            }
            set
            {
                this._EMail = value;
            }
        }

        [DataMember]
        public string StaffNumber
        {
            get
            {
                return this._StaffNumber;
            }
            set
            {
                this._StaffNumber = value;
            }
        }

        #endregion

        #region Constrcutor

        public UserInfo()
        {

        }

        public UserInfo(string pUserName)
        {
            this.UserName = pUserName;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            this._UserName = null;
            this._FullName = null;
            this._EMail = null;
            this._StaffNumber = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}