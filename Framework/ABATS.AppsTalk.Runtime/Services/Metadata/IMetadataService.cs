using ABATS.AppsTalk.Data;

namespace ABATS.AppsTalk.Runtime.Services.Metadata
{
    /// <summary>
    /// IMetadataService
    /// </summary>
    public interface IMetadataService : IAppService
    {
        #region Methods

        IntegrationProcess GetIntegrationProcessMetatdata(string pProcessCode);

        #endregion
    }
}