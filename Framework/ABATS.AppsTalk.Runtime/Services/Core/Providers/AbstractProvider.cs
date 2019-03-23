using ABATS.AppsTalk.Data;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    ///     Abstract Provider
    /// </summary>
    public abstract class AbstractProvider : AppRuntimeComponent
    {
        #region Members

        private IntegrationAdapter _AdapterMetadata = null;

        #endregion

        #region Properties

        public IntegrationAdapter AdapterMetadata
        {
            get
            {
                return this._AdapterMetadata;
            }
            set
            {
                this._AdapterMetadata = value;
            }
        }

        #endregion

        #region Constructors

        public AbstractProvider(IntegrationAdapter pAdapterMetadata, IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {
            this.AdapterMetadata = pAdapterMetadata;
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}