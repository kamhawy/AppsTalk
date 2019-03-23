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
    /// Application Database Presenter
    /// </summary>
    [Serializable()]
    public class ApplicationDatabasePresenter : EntityPresenterBase<ApplicationDatabas>
    {
        #region Constructors

        public ApplicationDatabasePresenter()
            : base()
        {

        }

        public ApplicationDatabasePresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Application Database
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public ApplicationDatabas GetApplicationDatabase(int pEntityID)
        {
            ApplicationDatabas entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<ApplicationDatabas>.Create(c =>
                    c.ApplicationDatabaseID == pEntityID));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update Application Database
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateApplicationDatabase(ApplicationDatabas pEntity)
        {
            int results = 0;

            try
            {
                DataUtilities.UpdateRecordAuditInfo(pEntity);
                pEntity.ApplicationID = WebUtilities.GetObjectFromQueryString(Application.sEntityKey).SafeIntegerParse();
                results = base.AppRuntime.DataService.UpdateEntity(pEntity);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Insert Application Database
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public ApplicationDatabas InsertApplicationDatabase(ApplicationDatabas pEntity)
        {
            try
            {
                pEntity.ApplicationID = WebUtilities.GetObjectFromQueryString(Application.sEntityKey).SafeIntegerParse();

                DataUtilities.UpdateRecordAuditInfo(pEntity);
                base.AppRuntime.DataService.AddEntity(pEntity);
                base.AppRuntime.DataService.SaveChanges();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return pEntity;
        }

        /// <summary>
        /// Get Application Database Queries
        /// </summary>
        /// <param name="pApplicationDatabaseID"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationDatabaseQuery> GetApplicationDatabaseQueries(int pApplicationDatabaseID)
        {
            IEnumerable<ApplicationDatabaseQuery> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<ApplicationDatabaseQuery>.Create(c =>
                    c.ApplicationDatabaseID == pApplicationDatabaseID)).ToList();
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