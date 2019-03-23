#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Metadata
{
    /// <summary>
    /// Metadata Service
    /// </summary>
    [Serializable]
    internal class MetadataService : AppServiceBase, IMetadataService
    {
        #region Members

        #endregion

        #region Constructor

        internal MetadataService(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {
        }

        #endregion

        #region IRuntimeService

        public bool Initialize()
        {
            bool success = false;

            try
            {
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #region IMetadataService

        public IntegrationProcess GetIntegrationProcessMetatdata(string pProcessCode) 
        {
            IntegrationProcess integrationProcessMetadata = null;

            try
            {
                integrationProcessMetadata = AppRuntime.DataService.GetEntity(DataUtilities.BuildIntegrationProcessGetDataRequest(pProcessCode));
            }            
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return integrationProcessMetadata;        
        }

        #endregion

        #region Factory

        internal static IMetadataService Create(IAppRuntime pIAppRuntime)
        {
            return new MetadataService(pIAppRuntime);
        }

        #endregion
    }
}