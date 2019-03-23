using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;
using System;
using System.Reflection;

namespace ABATS.AppsTalk.Runtime.Services.Core.Providers
{
    /// <summary>
    /// WS Provider Factory
    /// </summary>
    public static class WSProviderFactory
    {
        /// <summary>
        /// Create WSProvider
        /// </summary>
        /// <param name="pAdapterMetadata"></param>
        /// <param name="pApplicationWebServiceRequest"></param>
        /// <param name="pAppRuntime"></param>
        /// <returns></returns>
        public static AbstractWSProvider CreateWSProvider(IntegrationAdapter pAdapterMetadata, ApplicationWebServiceRequest pApplicationWebServiceRequest, IAppRuntime pAppRuntime)
        {
            AbstractWSProvider wsProvider = null;

            try
            {
                Assembly assembly = Assembly.LoadFrom(pApplicationWebServiceRequest.ApplicationWebService.AssemblyFullPath);

                if (assembly != null)
                {
                    Type requestType = assembly.GetType(pApplicationWebServiceRequest.ImplementationTypeFullName);

                    if (requestType != null)
                    {
                        wsProvider = assembly.CreateInstance(
                            pApplicationWebServiceRequest.ImplementationTypeFullName, false, BindingFlags.CreateInstance, null,
                            new object[] { pAdapterMetadata, pApplicationWebServiceRequest.ApplicationWebService, pAppRuntime }, null, null) as AbstractWSProvider;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return wsProvider;
        }
    }
}