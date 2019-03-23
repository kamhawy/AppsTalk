using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    public partial class IntegrationAdapter
    {
        public string IntegrationAdapterTypeDescription
        {
            get
            {
                return this.IntegrationAdapterType.ToEnum<IntegrationChannelType>().GetDescription();
            }
        }

        public string EndPointTypeDescription
        {
            get
            {
                return this.EndPointType.ToEnum<EndPointType>().GetDescription();
            }
        }

        public string ApplicationDatabaseQueryTitle
        {
            get
            {
                return this.ApplicationDatabaseQuery != null ? this.ApplicationDatabaseQuery.ApplicationDatabaseQueryTitle : string.Empty;
            }
        }

        public string ApplicationWebServiceRequestTitle
        {
            get
            {
                return this.ApplicationWebServiceRequest != null ? this.ApplicationWebServiceRequest.ApplicationWebServiceRequestTitle : string.Empty;
            }
        }
    }
}