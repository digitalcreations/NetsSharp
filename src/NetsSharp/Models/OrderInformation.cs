namespace NetsSharp.Models
{
    public class OrderInformation
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int Fee { get; set; }
        public string OrderDescription { get; set; }
        public int Total { get; set; }
    }
}