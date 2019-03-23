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
    /// Application Web Service Presenter
    /// </summary>
    [Serializable()]
    public class ApplicationWebServicePresenter : EntityPresenterBase<ApplicationWebService>
    {
        #region Constructors

        public ApplicationWebServicePresenter()
            : base()
        {

        }

        public ApplicationWebServicePresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Application Web Service
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public ApplicationWebService GetApplicationWebService(int pEntityID)
        {
            ApplicationWebService entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<ApplicationWebService>.Create(c =>
                    c.ApplicationWebServiceID == pEntityID));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update Application Web Service
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateApplicationWebService(ApplicationWebService pEntity)
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
        /// Insert Application Web Service
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public ApplicationWebService InsertApplicationWebService(ApplicationWebService pEntity)
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
        /// Get Application WebService Requests
        /// </summary>
        /// <param name="pApplicationWebServiceID"></param>
        /// <returns></returns>
        public IEnumerable<ApplicationWebServiceRequest> GetApplicationWebServiceRequests(int pApplicationWebServiceID)
        {
            IEnumerable<ApplicationWebServiceRequest> list = null;

            try
            {
                list = base.AppRuntime.DataService.GetAll(GetDataRequest<ApplicationWebServiceRequest>.Create(c =>
                    c.ApplicationWebServiceID == pApplicationWebServiceID)).ToList();
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