#region

using System;
using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Reports
{
    /// <summary>
    ///     Reports Service
    /// </summary>
    [Serializable]
    internal class ReportsService : AppServiceBase, IReportsService
    {
        #region Members

        #endregion

        #region Properties

        #endregion

        #region Constructor

        internal ReportsService(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {
        }

        #endregion

        #region IRuntimeService

        public bool Initialize()
        {
            bool success = false;

            try
            {
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #region IReportsService

        #endregion

        #region Factory

        internal static IReportsService Create(IAppRuntime pIAppRuntime)
        {
            return new ReportsService(pIAppRuntime);
        }

        #endregion
    }
}