using System.ComponentModel;
using System.Data;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// Data UI Component
    /// </summary>
    public class DataUIComponent<T> : UIComponent where T : DBEntityBase
    {
        #region Members

        private T _DataObject = null;

        #endregion

        #region Properties

        [Bindable(true)]
        public T DataObject
        {
            get
            {
                return this._DataObject;
            }
            set
            {
                this._DataObject = value;
            }
        }

        #endregion
    }
}
