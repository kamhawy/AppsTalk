using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Open Window Info  
    /// </summary>
    [Serializable]
    public class OpenWindowInfo : DisposableBase
    {
        #region Members

        private WindowInfo _Window = null;
        private UIMode _WindowUIMode = UIMode.None;
        private string _OnClientClose = "null";
        private string _Behaviors = "null";
        private List<OpenWindowParameterInfo> _OpenWindowParameters = null;

        #endregion

        #region Properties

        [DataMember]
        public WindowInfo Window
        {
            get
            {
                return this._Window;
            }
            set
            {
                this._Window = value;
            }
        }

        [DataMember]
        public UIMode WindowUIMode
        {
            get
            {
                return this._WindowUIMode;
            }
            set
            {
                this._WindowUIMode = value;
            }
        }

        [DataMember]
        public string OnClientClose
        {
            get
            {
                return this._OnClientClose;
            }
            set
            {
                this._OnClientClose = value == null ? "null" : value;
            }
        }

        [DataMember]
        public string Behaviors
        {
            get
            {
                return this._Behaviors;
            }
            set
            {
                this._Behaviors = value == null ? "null" : value;
            }
        }

        [DataMember]
        public List<OpenWindowParameterInfo> OpenWindowParameters
        {
            get
            {
                if (this._OpenWindowParameters == null)
                {
                    this._OpenWindowParameters = new List<OpenWindowParameterInfo>();
                }

                return this._OpenWindowParameters;
            }
            set
            {
                this._OpenWindowParameters = value;
            }
        }

        #endregion
    }
}