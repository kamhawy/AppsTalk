using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// DTO Base
    /// </summary>
    [Serializable]
    public abstract class DTOBase : DisposableBase
    {
        #region Members

        private string _GroupingField_Level_1 = string.Empty;
        private string _GroupingField_Level_2 = string.Empty;
        private string _Description = string.Empty;
        private bool _IsActive = true;
        private string _CreationUser = null;
        private DateTime _CreationDate = DateTime.MinValue;
        private string _LastUpdateUser = null;
        private DateTime _LastUpdate = DateTime.MinValue;

        #endregion

        #region Properties

        [DataMember]
        public string GroupingField_Level_1
        {
            get { return this._GroupingField_Level_1; }
            set { this._GroupingField_Level_1 = value; }
        }

        [DataMember]
        public string GroupingField_Level_2
        {
            get { return this._GroupingField_Level_2; }
            set { this._GroupingField_Level_2 = value; }
        } 

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        [DataMember]
        public string CreationUser
        {
            get { return _CreationUser; }
            set { _CreationUser = value; }
        }

        [DataMember]
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        [DataMember]
        public string LastUpdateUser
        {
            get { return _LastUpdateUser; }
            set { _LastUpdateUser = value; }
        }

        [DataMember]
        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }

        #endregion

        #region Constructors

        public DTOBase()
        {

        }

        #endregion
    }
}