namespace NetsSharp.Models
{
    using System;

    public class PaymentError
    {
        public string Operation { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseText { get; set; }
        public string ResponseSource { get; set; }
        public DateTime DateTime { get; set; }
    }
}