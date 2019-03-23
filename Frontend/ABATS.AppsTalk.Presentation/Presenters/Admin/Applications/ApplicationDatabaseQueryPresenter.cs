using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime;
using ABATS.AppsTalk.UX;
using System;

namespace ABATS.AppsTalk.Presentation
{
    /// <summary>
    /// Integration Adapter Query Presenter
    /// </summary>
    [Serializable()]
    public class ApplicationDatabaseQueryPresenter : EntityPresenterBase<ApplicationDatabaseQuery>
    {
        #region Properties

        public int ApplicationDatabaseID
        {
            get
            {
                return WebUtilities.GetObjectFromQueryString(ApplicationDatabas.sEntityKey).SafeIntegerParse();
            }
        }

        #endregion

        #region Constructors

        public ApplicationDatabaseQueryPresenter()
            : base()
        {

        }

        public ApplicationDatabaseQueryPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Application Database Query
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public ApplicationDatabaseQuery GetApplicationDatabaseQuery(int pEntityID)
        {
            ApplicationDatabaseQuery entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<ApplicationDatabaseQuery>.Create(c =>
                    c.ApplicationDatabaseQueryID == pEntityID, "ApplicationDatabas"));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update Application Database Query
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateApplicationDatabaseQuery(ApplicationDatabaseQuery pEntity)
        {
            int results = 0;

            try
            {
                pEntity.ApplicationDatabaseID = this.ApplicationDatabaseID;

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
        /// Insert Application Database Query
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertApplicationDatabaseQuery(ApplicationDatabaseQuery pEntity)
        {
            int results = 0;

            try
            {
                pEntity.ApplicationDatabaseID = this.ApplicationDatabaseID;

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
        /// Get Application Database
        /// </summary>
        /// <param name="pApplicationDatabaseID"></param>
        /// <returns></returns>
        public ApplicationDatabas GetApplicationDatabase(int pApplicationDatabaseID)
        {
            ApplicationDatabas entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<ApplicationDatabas>.Create(c =>
                    c.ApplicationDatabaseID == pApplicationDatabaseID));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        #endregion
    }
}