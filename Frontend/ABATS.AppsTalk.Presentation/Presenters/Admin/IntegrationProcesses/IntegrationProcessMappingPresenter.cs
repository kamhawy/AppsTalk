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
    /// Integration Process Mapping Presenter
    /// </summary>
    [Serializable()]
    public class IntegrationProcessMappingPresenter : EntityPresenterBase<IntegrationProcess>
    {
        #region Constructors

        public IntegrationProcessMappingPresenter()
            : base()
        {

        }

        public IntegrationProcessMappingPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// GetIntegrationProcessMappings
        /// </summary>
        /// <param name="pIntegrationProcessID"></param>
        /// <returns></returns>
        public List<IntegrationProcessMapping> GetIntegrationProcessMappings(int pIntegrationProcessID)
        {
            List<IntegrationProcessMapping> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<IntegrationProcessMapping>.Create(c =>
                    c.IntegrationProcessID == pIntegrationProcessID,
                    "IntegrationProcess",
                    "SourceIntegrationAdapterField",
                    "DestinationIntegrationAdapterField")).ToList();

                if (list != null && list.Count == 0)
                {
                    list.Add(new IntegrationProcessMapping() { IsRowVisible = false });
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Update IntegrationProcessMapping
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateIntegrationProcessMapping(IntegrationProcessMapping pEntity)
        {
            int results = 0;

            try
            {
                pEntity.IntegrationProcessID = WebUtilities.GetObjectFromQueryString(IntegrationProcess.sEntityKey).SafeIntegerParse();

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
        /// Insert IntegrationProcessMapping
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertIntegrationProcessMapping(IntegrationProcessMapping pEntity)
        {
            int results = 0;

            try
            {
                pEntity.IntegrationProcessID = WebUtilities.GetObjectFromQueryString(IntegrationProcess.sEntityKey).SafeIntegerParse();

                DataUtilities.UpdateRecordAuditInfo(pEntity);
                base.AppRuntime.DataService.AddEntity(pEntity);
                results = base.AppRuntime.DataService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Delete IntegrationProcessMapping
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int DeleteIntegrationProcessMapping(IntegrationProcessMapping pEntity)
        {
            int results = 0;

            try
            {
                pEntity = base.AppRuntime.DataService.GetEntity<IntegrationProcessMapping>(pEntity.IntegrationProcessMappingID);

                if (pEntity != null)
                {
                    results = base.AppRuntime.DataService.DeleteEntity(pEntity);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// GetSourceFields
        /// </summary>
        /// <param name="pIntegrationProcessID"></param>
        /// <returns></returns>
        public List<IntegrationAdapterField> GetSourceFields(int pIntegrationProcessID)
        {
            List<IntegrationAdapterField> list = null;

            try
            {
                IntegrationProcess process = base.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationProcess>.Create(c =>
                    c.IntegrationProcessID == pIntegrationProcessID,
                    "SourceIntegrationAdapter.IntegrationAdapterFields"));

                if (process != null && process.SourceIntegrationAdapter != null)
                {
                    list = process.SourceIntegrationAdapter.IntegrationAdapterFields.ToList();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// GetDestinationFields
        /// </summary>
        /// <param name="pIntegrationProcessID"></param>
        /// <returns></returns>
        public List<IntegrationAdapterField> GetDestinationFields(int pIntegrationProcessID)
        {
            List<IntegrationAdapterField> list = null;

            try
            {
                IntegrationProcess process = base.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationProcess>.Create(c =>
                    c.IntegrationProcessID == pIntegrationProcessID,
                    "DestinationIntegrationAdapter.IntegrationAdapterFields"));

                if (process != null && process.DestinationIntegrationAdapter != null)
                {
                    list = process.DestinationIntegrationAdapter.IntegrationAdapterFields.ToList();
                }
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