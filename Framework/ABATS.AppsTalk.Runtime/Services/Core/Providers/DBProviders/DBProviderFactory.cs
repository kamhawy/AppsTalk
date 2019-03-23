using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    ///     DBProvider Factory
    /// </summary>
    public static class DBProviderFactory
    {
        /// <summary>
        /// Create DBProvider
        /// </summary>
        /// <param name="pAdapterMetadata"></param>
        /// <param name="pApplicationDatabase"></param>
        /// <param name="pAppRuntime"></param>
        /// <returns></returns>
        public static AbstractDBProvider CreateDBProvider(IntegrationAdapter pAdapterMetadata, ApplicationDatabas pApplicationDatabase, IAppRuntime pAppRuntime)
        {
            AbstractDBProvider dbProvider = null;

            try
            {
                switch (pApplicationDatabase.ApplicationDatabaseType.ToEnum<ApplicationDatabaseType>())
                {
                    case ApplicationDatabaseType.SQLServer:
                        {
                            dbProvider = SQLProvider.Create(pAdapterMetadata, pApplicationDatabase, pAppRuntime);
                        }
                        break;
                    case ApplicationDatabaseType.Oracle:
                        {
                            dbProvider = OracleProvider.Create(pAdapterMetadata, pApplicationDatabase, pAppRuntime);
                        }
                        break;
                    case ApplicationDatabaseType.MySQL:
                        {
                            //Not yet Implemented
                        }
                        break;
                    case ApplicationDatabaseType.Sybase:
                        {
                            //Not yet Implemented
                        }
                        break;
                    default:
                        { }
                        break;
                }
            }
            catch { throw; }

            return dbProvider;
        }
    }
}