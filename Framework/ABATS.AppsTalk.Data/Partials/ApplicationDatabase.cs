using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    public partial class ApplicationDatabas
    {
        public string ApplicationDatabaseTypeDescription
        {
            get
            {
                return ((ApplicationDatabaseType)this.ApplicationDatabaseType).GetDescription();
            }
        }
    }
}