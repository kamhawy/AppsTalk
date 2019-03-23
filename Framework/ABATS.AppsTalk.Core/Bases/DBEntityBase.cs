using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Database Entity Base
    /// </summary>
    [Serializable]
    public abstract class DBEntityBase : DisposableBase, INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Members

        private string _GroupingField_Level_1 = string.Empty;
        private string _GroupingField_Level_2 = string.Empty;

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
        public bool IsActiveEntity
        {
            get
            {
                bool isActive = false;
                PropertyInfo propIsActive = this.GetType().GetProperty(Constants.PropertyName_IsActive);

                if (propIsActive != null)
                {
                    isActive = (Boolean)propIsActive.GetValue(this, null);
                }

                return isActive;
            }
            set
            {
                PropertyInfo propIsActive = this.GetType().GetProperty(Constants.PropertyName_IsActive);

                if (propIsActive != null)
                {
                    propIsActive.SetValue(this, value, null);
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// DB Entity Base
        /// </summary>
        public DBEntityBase()
        {

        }

        #endregion

        #region Abstracts

        /// <summary>
        /// Entity ID
        /// </summary>
        public abstract int EntityID { get; }

        /// <summary>
        /// Entity Key string
        /// </summary>
        public abstract string EntityKey { get; }

        /// <summary>
        /// Active Image Path
        /// </summary>
        //public abstract string ActiveImagePath { get; }

        #endregion

        #region Property Changes

        private static PropertyChangingEventArgs _EmptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        public void SendPropertyChanging()
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, _EmptyChangingEventArgs);
            }
        }

        public void SendPropertyChanged(String pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }

        #endregion

        #region Serialization

        protected bool IsDeserializing { get; private set; }

        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }

        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            this._GroupingField_Level_1 = null;
            this._GroupingField_Level_2 = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}