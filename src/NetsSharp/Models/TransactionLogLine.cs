namespace NetsSharp.Models
{
    using System;

    public class TransactionLogLine
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Operation { get; set; }
        public string TransactionReconRef { get; set; }
        public int BatchNumber { get; set; }
        public int Amount { get; set; }
    }
}