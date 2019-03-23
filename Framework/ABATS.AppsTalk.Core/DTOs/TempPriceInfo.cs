using System;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// TempPriceInfo
    /// </summary>
    public class TempPriceInfo : DisposableBase
    {
        #region Members

        private int? _PriceID;
        private DateTime? _PriceDate;
        private decimal? _Price = null;

        #endregion

        #region Properties

        public int? PriceID
        {
            get { return _PriceID; }
            set { _PriceID = value; }
        }

        public DateTime? PriceDate
        {
            get { return _PriceDate; }
            set { _PriceDate = value; }
        }

        public decimal? Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        #endregion

        #region Constructors

        public TempPriceInfo()
        {

        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            _PriceID = null;
            _PriceDate = null;
            _Price = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}