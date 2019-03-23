#region

using System;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Common.Requests
{
    /// <summary>
    ///     Process Execution Request
    /// </summary>
    [Serializable]
    public class ProcessExecutionRequest : RequestBase
    {
        #region Members

        #endregion

        #region Properties

        [DataMember]
        public string ProcessCode { get; set; }

        #endregion

        #region Constructors

        public ProcessExecutionRequest()
        {
            ProcessCode = string.Empty;
        }

        public ProcessExecutionRequest(string pProcessCode)
        {
            ProcessCode = pProcessCode;
        }

        public ProcessExecutionRequest(string pProcessCode, DateTime pRequestDate, string pRequestUser)
            : base(pRequestDate, pRequestUser)
        {
            ProcessCode = pProcessCode;
        }

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            ProcessCode = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}