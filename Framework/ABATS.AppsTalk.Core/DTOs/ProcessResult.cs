using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Process Result
    /// </summary>
    [Serializable]
    public class ProcessResult : DTOBase
    {
        #region Members

        private TimeSpan? _ExecutionTime = null;

        #endregion

        #region Properties

        [DataMember]
        public TimeSpan? ExecutionTime
        {
            get
            {
                return this._ExecutionTime;
            }
            set
            {
                this._ExecutionTime = value;
            }
        }

        #endregion

        #region Constrcutor

        public ProcessResult()
        {

        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            this._ExecutionTime = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}