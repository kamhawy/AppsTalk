#region

using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Core.Adapters
{
    internal static class AdapterFactory
    {
        /// <summary>
        /// Create Adapter
        /// </summary>
        /// <param name="pProcessMetadata"></param>
        /// <param name="pAdapterMetadata"></param>
        /// <param name="pAppRuntime"></param>
        /// <returns></returns>
        internal static AbstractAdapter CreateAdapter(IntegrationProcess pProcessMetadata, IntegrationAdapter pAdapterMetadata, IAppRuntime pAppRuntime)
        {
            AbstractAdapter adapter = null;

            switch (pAdapterMetadata.EndPointType.ToEnum<EndPointType>())
            {
                case EndPointType.Database:
                    {
                        adapter = DBAdapter.Create(pProcessMetadata, pAdapterMetadata, pAppRuntime);
                    }
                    break;
                case EndPointType.WebService:
                    {
                        adapter = WSAdapter.Create(pProcessMetadata, pAdapterMetadata, pAppRuntime);
                    }
                    break;
                default:
                    { }
                    break;
            }

            return adapter;
        }
    }
}