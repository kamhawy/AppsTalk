using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime;
using ABATS.AppsTalk.UX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABATS.AppsTalk.Presentation
{
    /// <summary>
    /// Execute Integration Process Presenter
    /// </summary>
    [Serializable()]
    public class ExecuteIntegrationProcessPresenter : PresenterBase
    {
        #region Constructors

        public ExecuteIntegrationProcessPresenter()
            : base()
        {

        }

        public ExecuteIntegrationProcessPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All Integration Processes
        /// </summary>
        /// <returns></returns>
        public IList<IntegrationProcess> GetAllIntegrationProcesses()
        {
            IList<IntegrationProcess> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll<IntegrationProcess>().ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        #endregion
    }
}