using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Process Info
    /// </summary>
    [Serializable]
    public class ProcessInfo : DTOBase
    {
        #region Members

        private string _ProcessID = string.Empty;
        private string _ProcessCode = string.Empty;
        private Task<ProcessResult> _ProcessTask = null;
        private ProcessResult _Result = null;

        #endregion

        #region Properties

        [DataMember]
        public string ProcessID
        {
            get
            {
                return this._ProcessID;
            }
            set
            {
                this._ProcessID = value;
            }
        }

        [DataMember]
        public string ProcessCode
        {
            get
            {
                return this._ProcessCode;
            }
            set
            {
                this._ProcessCode = value;
            }
        }

        [DataMember]
        public Task<ProcessResult> ProcessTask
        {
            get
            {
                return this._ProcessTask;
            }
            set
            {
                this._ProcessTask = value;
            }
        }

        [DataMember]
        public ProcessResult Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                this._Result = value;
            }
        }

        #endregion

        #region Constructors

        public ProcessInfo()
        {
            this.ProcessID = Guid.NewGuid().ToString();
        }

        public ProcessInfo(string pProcessID, string pProcessName)
        {
            this.ProcessID = pProcessID;
            this.ProcessCode = pProcessName;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            CoreUtilities.SafeDispose(ref this._ProcessID);
            CoreUtilities.SafeDispose(ref this._ProcessTask);

            base.DisposeManagedRessources();
        }

        #endregion
    }
}