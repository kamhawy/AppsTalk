using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represents Response base abstract class
    /// </summary>
    [Serializable()]
    public abstract class ResponseBase : DisposableBase
    {
        #region Members

        private RequestBase _Request = null;
        private OperationStatus _Status = OperationStatus.Succeeded;
        private string _StatusDescription = string.Empty;
        private string _Message = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Request
        /// </summary>
        [DataMember]
        public RequestBase Request
        {
            get
            {
                return this._Request;
            }
            set
            {
                this._Request = value;
            }
        }

        [DataMember]
        public OperationStatus Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }

        [DataMember]
        public string StatusDescription
        {
            get
            {
                return this._StatusDescription;
            }
            set
            {
                this._StatusDescription = value;
            }
        }

        [DataMember]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this._Message = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize Response Base
        /// </summary>
        public ResponseBase()
        {
        
        }

        /// <summary>
        /// Initialize Response Base
        /// </summary>
        /// <param name="pRequest">Request</param>
        public ResponseBase(RequestBase pRequest)
        {
            Request = pRequest;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            if (this._Request != null)
                this._Request.Dispose(); 

            base.DisposeManagedRessources();
        }

        #endregion
    }
}