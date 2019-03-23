#region

using System;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Services
{
    /// <summary>
    ///     Represents the abstract base class of all Application Services
    /// </summary>
    [Serializable]
    internal abstract class AppServiceBase : DisposableBase
    {
        #region Members

        #endregion

        #region Properties

        [DataMember]
        public IAppRuntime AppRuntime { get; set; }

        #endregion

        #region Constructor

        protected AppServiceBase()
        {
        }

        protected AppServiceBase(IAppRuntime pIAppRuntime)
        {
            AppRuntime = pIAppRuntime;
        }

        #endregion
    }
}