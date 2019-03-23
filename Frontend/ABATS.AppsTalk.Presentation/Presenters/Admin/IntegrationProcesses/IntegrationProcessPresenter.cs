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
    /// Integration Process Presenter
    /// </summary>
    [Serializable()]
    public class IntegrationProcessPresenter : EntityPresenterBase<IntegrationProcess>
    {
        #region Constructors

        public IntegrationProcessPresenter()
            : base()
        {

        }

        public IntegrationProcessPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Overrides

        public override string[] Includes
        {
            get
            {
                return new string[] { "SourceIntegrationAdapter", "DestinationIntegrationAdapter" };
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Integration Adapters
        /// </summary>
        /// <returns></returns>
        public IList<IntegrationAdapter> GetIntegrationAdapters()
        {
            IList<IntegrationAdapter> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll<IntegrationAdapter>().ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

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

        /// <summary>
        /// Get IntegrationProcess
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public IntegrationProcess GetIntegrationProcess(int pEntityID)
        {
            IntegrationProcess entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationProcess>.Create(c =>
                    c.IntegrationProcessID == pEntityID));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update IntegrationProcess
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateIntegrationProcess(IntegrationProcess pEntity)
        {
            int results = 0;

            try
            {
                pEntity.SourceIntegrationAdapterID = this.Entity.SourceIntegrationAdapterID;
                pEntity.DestinationIntegrationAdapterID = this.Entity.DestinationIntegrationAdapterID;

                DataUtilities.UpdateRecordAuditInfo(pEntity);
                results = base.AppRuntime.DataService.UpdateEntity(pEntity);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Insert IntegrationProcess
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertIntegrationProcess(IntegrationProcess pEntity)
        {
            int results = 0;

            try
            {
                DataUtilities.UpdateRecordAuditInfo(pEntity);

                pEntity.SourceIntegrationAdapterID = null;
                pEntity.DestinationIntegrationAdapterID = null;

                base.AppRuntime.DataService.AddEntity(pEntity);
                results = base.AppRuntime.DataService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        #endregion
    }
}