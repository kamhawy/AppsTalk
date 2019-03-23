
namespace ABATS.AppsTalk.Data
{
    public partial class IntegrationProcessMapping
    {
        public string SourceIntegrationAdapterFieldName
        {
            get
            {
                return this.SourceIntegrationAdapterField != null ? this.SourceIntegrationAdapterField.FieldName : string.Empty;
            }
        }

        public string DestinationIntegrationAdapterFieldName
        {
            get
            {
                return this.DestinationIntegrationAdapterField != null ? this.DestinationIntegrationAdapterField.FieldName : string.Empty;
            }
        }

        private bool _IsRowVisible = true;

        public bool IsRowVisible
        {
            get { return _IsRowVisible; }
            set { _IsRowVisible = value; }
        }
    }
}