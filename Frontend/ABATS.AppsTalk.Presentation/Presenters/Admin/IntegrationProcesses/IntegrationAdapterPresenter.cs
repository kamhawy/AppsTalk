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
    /// Integration Adapter Presenter
    /// </summary>
    [Serializable()]
    public class IntegrationAdapterPresenter : EntityPresenterBase<IntegrationAdapter>
    {
        #region QueryString Properties

        public int IntegrationProcessID
        {
            get
            {
                return WebUtilities.GetObjectFromQueryString(IntegrationProcess.sEntityKey).SafeIntegerParse();
            }
        }

        public IntegrationChannelType IntegrationAdapterType
        {
            get
            {
                return WebUtilities.GetObjectFromQueryString(Constants.QueryStringKey_IntegrationAdapterType).SafeIntegerParse().ToEnum<IntegrationChannelType>();
            }
        }

        #endregion

        #region Constructors

        public IntegrationAdapterPresenter()
            : base()
        {

        }

        public IntegrationAdapterPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Data Source

        /// <summary>
        /// Get IntegrationAdapter
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public IntegrationAdapter GetIntegrationAdapter(int pEntityID)
        {
            IntegrationAdapter entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationAdapter>.Create(c =>
                    c.IntegrationAdapterID == pEntityID,
                    "IntegrationAdapterFields",
                    "ApplicationDatabaseQuery.ApplicationDatabas",
                    "ApplicationWebServiceRequest.ApplicationWebService"));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update IntegrationAdapter
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateIntegrationAdapter(IntegrationAdapter pEntity)
        {
            int results = 0;

            try
            {
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
        /// Insert IntegrationAdapter
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertIntegrationAdapter(IntegrationAdapter pEntity)
        {
            int results = 0;

            try
            {
                DataUtilities.UpdateRecordAuditInfo(pEntity);
                base.AppRuntime.DataService.AddEntity(pEntity);
                results = base.AppRuntime.DataService.SaveChanges();

                if (pEntity.IntegrationAdapterID > 0)
                {
                    IntegrationProcess process = base.AppRuntime.DataService.GetEntity(GetDataRequest<IntegrationProcess>.Create(c =>
                        c.IntegrationProcessID == this.IntegrationProcessID));

                    if (process != null)
                    {
                        if (this.IntegrationAdapterType == IntegrationChannelType.Source)
                        {
                            process.SourceIntegrationAdapterID = pEntity.IntegrationAdapterID;
                        }
                        else if (this.IntegrationAdapterType == IntegrationChannelType.Destination)
                        {
                            process.DestinationIntegrationAdapterID = pEntity.IntegrationAdapterID;
                        }

                        DataUtilities.UpdateRecordAuditInfo(process);
                        base.AppRuntime.DataService.UpdateEntity(process);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Get Application Database Queries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationDatabaseQuery> GetApplicationDatabaseQueries()
        {
            IEnumerable<ApplicationDatabaseQuery> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<ApplicationDatabaseQuery>.Create()).ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Get Application Web Service Requests
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationWebServiceRequest> GetApplicationWebServiceRequests()
        {
            IEnumerable<ApplicationWebServiceRequest> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<ApplicationWebServiceRequest>.Create()).ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        #endregion

        #region Integration Adapter Fields

        /// <summary>
        /// Get Integration Adapter Fields
        /// </summary>
        /// <param name="pIntegrationAdapterID"></param>
        /// <returns></returns>
        public List<IntegrationAdapterField> GetIntegrationAdapterFields(int pIntegrationAdapterID)
        {
            List<IntegrationAdapterField> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<IntegrationAdapterField>.Create(c =>
                    c.IntegrationAdapterID == pIntegrationAdapterID)).ToList();

                if (list != null && list.Count == 0)
                {
                    list.Add(new IntegrationAdapterField() { IsRowVisible = false });
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Update Integration Adapter Field
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateIntegrationAdapterField(IntegrationAdapterField pEntity)
        {
            int results = 0;

            try
            {
                pEntity.IntegrationAdapterID = this.Entity.IntegrationAdapterID;

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
        /// Insert Integration Adapter Field
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertIntegrationAdapterField(IntegrationAdapterField pEntity)
        {
            int results = 0;

            try
            {
                pEntity.IntegrationAdapterID = this.Entity.IntegrationAdapterID;

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
        /// Delete Integration Adapter Field
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int DeleteIntegrationAdapterField(IntegrationAdapterField pEntity)
        {
            int results = 0;

            try
            {
                pEntity = base.AppRuntime.DataService.GetEntity<IntegrationAdapterField>(pEntity.IntegrationAdapterFieldID);

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

        #endregion
    }
}