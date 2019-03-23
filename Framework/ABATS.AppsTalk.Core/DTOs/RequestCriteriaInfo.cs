using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Request Criteria Info
    /// </summary>
    [Serializable]
    public class RequestCriteriaInfo : DisposableBase
    {
        #region Members

        private DateTime? _StartDate = null;
        private DateTime? _EndDate = null;

        #endregion

        #region Properties

        /// <summary>
        /// Start Date
        /// </summary>
        [DataMember]
        public DateTime? StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }

        /// <summary>
        /// End Date
        /// </summary>
        [DataMember]
        public DateTime? EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }

        /// <summary>
        /// DateTimeSpan
        /// </summary>
        [DataMember]
        public int MonthsDifference
        {
            get
            {
                return this.GetMonthsDifference();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of Criteria Info
        /// </summary>
        public RequestCriteriaInfo()
        {

        }

        /// <summary>
        /// Create a new instance of Criteria Info
        /// </summary>
        /// <param name="pFromDate"></param>
        /// <param name="pToDate"></param>
        public RequestCriteriaInfo(DateTime? pFromDate, DateTime? pToDate)
        {
            StartDate = pFromDate;
            EndDate = pToDate;
        }

        #endregion

        #region Helpers

        private int GetMonthsDifference()
        {
            int monthsDifference = 0;

            if (StartDate > DateTime.MinValue && EndDate > DateTime.MinValue)
            {
                monthsDifference =
                    (12 * (StartDate.GetValueOrCurrent().Year) - EndDate.GetValueOrCurrent().Year) +
                    (StartDate.GetValueOrCurrent().Month - EndDate.GetValueOrCurrent().Month);
            }

            return Math.Abs(monthsDifference);
        }

        #endregion

        #region Builders

        /// <summary>
        /// Build History Request Criteria
        /// </summary>
        /// <param name="pRequestDateTime"></param>
        /// <param name="pHistortyMonthsCount"></param>
        /// <returns></returns>
        public static RequestCriteriaInfo BuildHistoryRequestCriteria(DateTime pRequestDateTime, int pHistortyMonthsCount)
        {
            DateTime dtHistoryMonth = pRequestDateTime;

            if (pHistortyMonthsCount > 0)
            {
                dtHistoryMonth = pRequestDateTime.AddMonths(CoreUtilities.GetNegativeNumber(pHistortyMonthsCount));
            }

            DateTime dtStart = CoreUtilities.GetFirstDayOfMonth(dtHistoryMonth);
            DateTime dtEnd = CoreUtilities.GetLastSecondOfDay(CoreUtilities.GetLastDayOfMonth(pRequestDateTime.AddMonths(-1)));

            return new RequestCriteriaInfo(dtStart, dtEnd);
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            _StartDate = null;
            _EndDate = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}