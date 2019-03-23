using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Window Parameter Info
    /// </summary>
    [Serializable]
    public class WindowParameterInfo : DTOBase
    {
        #region Members

        private int _WindowParameterID = -1;
        private WindowInfo _Window = null;
        private string _WindowParameterName = string.Empty;
        private string _WindowParameterTitle = null;
        private short _DisplaySequence = 1;

        #endregion

        #region Properties

        [DataMember]
        public int WindowParameterID
        {
            get { return _WindowParameterID; }
            set { _WindowParameterID = value; }
        }

        [DataMember]
        public WindowInfo Window
        {
            get { return _Window; }
            set { _Window = value; }
        }

        [DataMember]
        public string WindowParameterName
        {
            get { return _WindowParameterName; }
            set { _WindowParameterName = value; }
        }

        [DataMember]
        public string WindowParameterTitle
        {
            get { return _WindowParameterTitle; }
            set { _WindowParameterTitle = value; }
        }

        [DataMember]
        public short DisplaySequence
        {
            get { return _DisplaySequence; }
            set { _DisplaySequence = value; }
        }

        #endregion

        #region Constructor

        public WindowParameterInfo()
        {

        }

        #endregion
    }
}