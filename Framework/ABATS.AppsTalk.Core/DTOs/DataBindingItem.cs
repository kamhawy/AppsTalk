using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Data Binding Item
    /// </summary>
    [Serializable]
    public partial class DataBindingItem : DisposableBase
    {
        #region Members

        private int _Value = 0;
        private string _Text = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        [Bindable(true)]
        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }

        [DataMember]
        [Bindable(true)]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }

        #endregion

        #region Constructors

        public DataBindingItem()
        {

        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}