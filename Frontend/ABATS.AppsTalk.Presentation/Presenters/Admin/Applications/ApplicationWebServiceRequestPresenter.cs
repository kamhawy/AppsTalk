using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using ABATS.AppsTalk.Runtime;
using ABATS.AppsTalk.UX;
using System;

namespace ABATS.AppsTalk.Presentation
{
    /// <summary>
    /// Application Web Service Request Presenter
    /// </summary>
    [Serializable()]
    public class ApplicationWebServiceRequestPresenter : EntityPresenterBase<ApplicationWebServiceRequest>
    {
        #region Constructors

        public ApplicationWebServiceRequestPresenter()
            : base()
        {

        }

        public ApplicationWebServiceRequestPresenter(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Application Web Service Request
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public ApplicationWebServiceRequest GetApplicationWebServiceRequest(int pEntityID)
        {
            ApplicationWebServiceRequest entity = null;

            try
            {
                entity = base.AppRuntime.DataService.GetEntity(GetDataRequest<ApplicationWebServiceRequest>.Create(c =>
                    c.ApplicationWebServiceID == pEntityID, "ApplicationWebService"));
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Update Application Web Service Request
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateApplicationWebServiceRequest(ApplicationWebServiceRequest pEntity)
        {
            int results = 0;

            try
            {
                DataUtilities.UpdateRecordAuditInfo(pEntity);
                pEntity.ApplicationWebServiceID = WebUtilities.GetObjectFromQueryString(ApplicationWebService.sEntityKey).SafeIntegerParse();
                results = base.AppRuntime.DataService.UpdateEntity(pEntity);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Insert Application Web Service Request
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public ApplicationWebServiceRequest InsertApplicationWebServiceRequest(ApplicationWebServiceRequest pEntity)
        {
            try
            {
                pEntity.ApplicationWebServiceID = WebUtilities.GetObjectFromQueryString(ApplicationWebService.sEntityKey).SafeIntegerParse();

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

        #endregion
    }
}