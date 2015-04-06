namespace NetsSharp.Models
{
    public class PaymentInfo
    {
        public string MerchantId { get; set; }
        public string TransactionId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDescription { get; set; }

        public CustomerInformation CustomerInformation { get; set; }
        public CardInformation CardInformation { get; set; }
        public OrderInformation OrderInformation { get; set; }
        public SecurityInformation SecurityInformation { get; set; }
        public Summary Summary { get; set; }
        public TerminalInformation TerminalInformation { get; set; }

        public TransactionLogLine[] History { get; set; }
    }
}
