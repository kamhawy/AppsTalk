using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// OpenWindowParameterInfo
    /// </summary>
    [Serializable]
    public class OpenWindowParameterInfo : DisposableBase
    {
        #region Members

        private string _WindowParameterName = null;
        private object _WindowParameterValue = null;

        #endregion

        #region Properties

        [DataMember]
        public string WindowParameterName
        {
            get { return _WindowParameterName; }
            set { _WindowParameterName = value; }
        }

        [DataMember]
        public object WindowParameterValue
        {
            get { return _WindowParameterValue; }
            set { _WindowParameterValue = value; }
        }

        #endregion

        #region Constructors

        public OpenWindowParameterInfo()
        { 
        
        }

        public OpenWindowParameterInfo(string pWindowParameterName, object pWindowParameterValue)
        {
            this.WindowParameterName = pWindowParameterName;
            this.WindowParameterValue = pWindowParameterValue;
        }

        #endregion
    }
}
