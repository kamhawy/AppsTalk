
namespace ABATS.AppsTalk.Data
{
    public partial class IntegrationProcess
    {
        public string IntegrationProcessFullName
        {
            get
            {
                return string.Format("{0} [{1}]", this.IntegrationProcessTitle, this.IntegrationProcessCode);
            }
        }
    }
}