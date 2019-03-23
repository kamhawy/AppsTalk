using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represents Request base abstract class
    /// </summary>
    [Serializable()]
    public abstract class RequestBase : DisposableBase
    {
        #region Members

        private DateTime _RequestDate = DateTime.Now;
        private string _RequestUser = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Request Date
        /// </summary>
        [DataMember]
        public DateTime RequestDate
        {
            get
            {
                return _RequestDate;
            }
            set
            {
                _RequestDate = value;
            }
        }

        [DataMember]
        public string RequestUser
        {
            get
            {
                return this._RequestUser;
            }
            set
            {
                this._RequestUser = value;
            }
        }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Initialize the Request Base
        /// </summary>
        public RequestBase()
        {

        }

        /// <summary>
        /// Initialize the Request Base
        /// </summary>
        /// <param name="pRequestDate"></param>
        public RequestBase(DateTime pRequestDate)
        {
            this.RequestDate = pRequestDate;
        }

        /// <summary>
        /// Initialize the Request Base
        /// </summary>
        /// <param name="pRequestDate"></param>
        /// <param name="pRequestUser"></param>
        public RequestBase(DateTime pRequestDate, string pRequestUser)
        {
            this.RequestDate = pRequestDate;
            this.RequestUser = pRequestUser;
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