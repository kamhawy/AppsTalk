using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// WindowInfo
    /// </summary>
    [Serializable]
    public class WindowInfo : DTOBase
    {
        #region Members

        private int _WindowID = -1;
        private string _WindowFullName = string.Empty;
        private string _WindowTitle = string.Empty;
        private string _WindowVirtualPath = string.Empty;
        private string _WindowImageVirtualPath = string.Empty;
        private string _WindowSmallImageVirtualPath = string.Empty;
        private short _WindowWidth = 600;
        private short _WindowHeight = 400;
        private bool _ShowInMenu = false;
        private bool _IsModal = false;
        private short _DisplaySequence = 1;
        private List<WindowParameterInfo> _WindowParameters = null;

        #endregion

        #region Properties

        [DataMember]
        public int WindowID
        {
            get { return _WindowID; }
            set { _WindowID = value; }
        }

        [DataMember]
        public string WindowFullName
        {
            get { return _WindowFullName; }
            set { _WindowFullName = value; }
        }

        [DataMember]
        public string WindowTitle
        {
            get { return _WindowTitle; }
            set { _WindowTitle = value; }
        }

        [DataMember]
        public string WindowVirtualPath
        {
            get { return _WindowVirtualPath; }
            set { _WindowVirtualPath = value; }
        }

        [DataMember]
        public string WindowImageVirtualPath
        {
            get { return _WindowImageVirtualPath; }
            set { _WindowImageVirtualPath = value; }
        }

        [DataMember]
        public string WindowSmallImageVirtualPath
        {
            get { return _WindowSmallImageVirtualPath; }
            set { _WindowSmallImageVirtualPath = value; }
        }

        [DataMember]
        public short WindowWidth
        {
            get { return _WindowWidth; }
            set { _WindowWidth = value; }
        }

        [DataMember]
        public short WindowHeight
        {
            get { return _WindowHeight; }
            set { _WindowHeight = value; }
        }

        [DataMember]
        public bool ShowInMenu
        {
            get { return _ShowInMenu; }
            set { _ShowInMenu = value; }
        }

        [DataMember]
        public bool IsModal
        {
            get { return _IsModal; }
            set { _IsModal = value; }
        }

        [DataMember]
        public short DisplaySequence
        {
            get { return _DisplaySequence; }
            set { _DisplaySequence = value; }
        }

        [DataMember]
        public List<WindowParameterInfo> WindowParameters
        {
            get
            {
                if (_WindowParameters == null)
                {
                    _WindowParameters = new List<WindowParameterInfo>();
                }

                return _WindowParameters;
            }
            set
            {
                _WindowParameters = value;
            }
        }

        #endregion

        #region Constructors

        public WindowInfo()
        {

        }

        #endregion
    }
}