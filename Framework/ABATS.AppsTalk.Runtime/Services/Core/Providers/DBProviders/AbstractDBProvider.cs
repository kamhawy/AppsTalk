using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System.Collections.Generic;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    ///     Abstract DBProvider
    /// </summary>
    public abstract class AbstractDBProvider : AbstractProvider
    {
        #region Members

        private ApplicationDatabas _ApplicationDatabaseMetadata = null;
        private ApplicationDatabaseType _ProviderType = ApplicationDatabaseType.Oracle;

        #endregion

        #region Properties

        public ApplicationDatabas ApplicationDatabaseMetadata
        {
            get { return this._ApplicationDatabaseMetadata; }
            set { this._ApplicationDatabaseMetadata = value; }
        }

        public ApplicationDatabaseType ProviderType
        {
            get { return this._ProviderType; }
            private set { this._ProviderType = value; }
        }

        #endregion

        #region Constructors

        public AbstractDBProvider(IntegrationAdapter pAdapterMetadata, ApplicationDatabas pApplicationDatabaseMetadata, IAppRuntime pAppRuntime)
            : base(pAdapterMetadata, pAppRuntime)
        {
            this.ApplicationDatabaseMetadata = pApplicationDatabaseMetadata;

            if (this.ApplicationDatabaseMetadata != null)
            {
                this.ProviderType = this.ApplicationDatabaseMetadata.ApplicationDatabaseType.ToEnum<ApplicationDatabaseType>();
            }
        }

        #endregion

        #region Abstracts

        /// <summary>
        /// Run Select Query
        /// </summary>
        /// <param name="pApplicationDatabaseQuery"></param>
        /// <param name="providerConnectionString"></param>
        /// <returns></returns>
        public abstract IList<DBRecordInfo> RunSelectQuery(ApplicationDatabaseQuery pApplicationDatabaseQuery);

        /// <summary>
        /// Run Insert Query
        /// </summary>
        /// <param name="pApplicationDatabaseQuery"></param>
        /// <param name="pAdapterFields"></param>
        /// <param name="pDBRecord"></param>
        /// <returns></returns>
        public abstract RecordTransactionStatus RunInsertQuery(ApplicationDatabaseQuery pApplicationDatabaseQuery, ICollection<IntegrationAdapterField> pAdapterFields, DBRecordInfo pDBRecord);

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}