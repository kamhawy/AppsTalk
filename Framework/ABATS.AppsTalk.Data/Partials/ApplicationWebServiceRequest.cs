using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    public partial class ApplicationWebServiceRequest
    {
        public string ApplicationWebServiceRequestTypeDescription
        {
            get
            {
                return ((IntegrationOperatoinType)this.ApplicationWebServiceRequestType).GetDescription();
            }
        }

        public string ApplicationWebServiceTitle
        {
            get
            {
                return this.ApplicationWebService != null ? this.ApplicationWebService.ApplicationWebServiceTitle : string.Empty;
            }
        }
    }
}