using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    public partial class ApplicationDatabaseQuery
    {
        public string ApplicationDatabaseQueryTypeDescription
        {
            get
            {
                return string.Format("{0} Query", ((IntegrationOperatoinType)this.ApplicationDatabaseQueryType).GetDescription());
            }
        }

        public string ApplicationDatabaseTitle
        {
            get
            {
                return this.ApplicationDatabas != null ? this.ApplicationDatabas.ApplicationDatabaseTitle : string.Empty;
            }
        }
    }
}