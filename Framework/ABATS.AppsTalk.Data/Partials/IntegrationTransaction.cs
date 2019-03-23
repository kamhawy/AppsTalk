using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    public partial class IntegrationTransaction
    {
        public string TransactionStatusName
        {
            get
            {
                return ((OperationStatus)this.TransactionStatus).GetDescription();
            }
        }
    }
}