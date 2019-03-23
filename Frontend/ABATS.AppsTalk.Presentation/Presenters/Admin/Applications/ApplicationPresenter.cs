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
    /// Application Presenter
    /// </summary>
    [Serializable()]
    public class ApplicationPresenter : EntityPresenterBase<Application>
    {
        #region Constructors

        public ApplicationPresenter()
            : base()
        {

        }

        public ApplicationPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get All Applications
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Application> GetAllApplications()
        {
            IList<Application> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll<Application>().ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Get Application Databases
        /// </summary>
        /// <param name="pApplicationID"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationDatabas> GetApplicationDatabases(int pApplicationID)
        {
            IList<ApplicationDatabas> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<ApplicationDatabas>.Create(c =>
                    c.ApplicationID == pApplicationID)).ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Get Application Web Services
        /// </summary>
        /// <param name="pApplicationID"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationWebService> GetApplicationWebServices(int pApplicationID)
        {
            IList<ApplicationWebService> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<ApplicationWebService>.Create(c =>
                    c.ApplicationID == pApplicationID)).ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return list;
        }

        #endregion

        #region Data Source

        /// <summary>
        /// GetEntityTest
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public Application GetApplication(int pEntityID)
        {
            Application entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<Application>.Create(c =>
                    c.ApplicationID == pEntityID));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateApplication(Application pEntity)
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
        /// Insert Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertApplication(Application pEntity)
        {
            int results = 0;

            try
            {
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

        #endregion

        #region Overrides

        /// <summary>
        /// Before Insert Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public override bool BeforeInsertEntity(Application pEntity)
        {
            return base.BeforeInsertEntity(pEntity);
        }

        /// <summary>
        /// After Insert Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pResult"></param>
        public override void AfterInsertEntity(Application pEntity, int pResult)
        {
            base.AfterInsertEntity(pEntity, pResult);
        }

        /// <summary>
        /// Before Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public override bool BeforeUpdateEntity(Application pEntity)
        {
            return base.BeforeUpdateEntity(pEntity);
        }

        /// <summary>
        /// After Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pResult"></param>
        public override void AfterUpdateEntity(Application pEntity, int pResult)
        {
            base.AfterUpdateEntity(pEntity, pResult);
        }

        #endregion
    }
}