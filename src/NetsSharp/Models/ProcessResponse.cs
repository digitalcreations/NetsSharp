namespace NetsSharp.Models
{
    using System;

    public class ProcessResponse
    {
        /// <summary>
        /// The Process call will echo which operation was used for this call. This is more useful when doing batch processing, but the field is set for single operations as well.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// The transaction ID is echoed from the Process call.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// The merchant ID is echoed from the Process call.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// The response code will be set to the string “OK” if the transaction was processed correctly. Any other response is an error, and should be logged with the Response Source and the Response Text.
        /// </summary>
        public string ResponseCode { get; set; }

        /// <summary>
        /// The response source indicates where the transaction failed. The response source should be logged and included in any communication with Netaxept support. 
        /// 
        /// Response source values from the current version of Netaxept (version 2): 
        /// Netaxept
        /// Issuer
        /// Module
        /// Transport
        /// Terminal
        /// </summary>
        public string ResponseSource { get; set; }

        /// <summary>
        /// The response source indicates where the transaction failed. The response source should be logged and included in any communication with Netaxept support. 
        /// </summary>
        public string ResponseText { get; set; }

        /// <summary>
        /// An ID identifying this authorization. This ID is sent from the issuer. 
        /// </summary>
        public string AuthorizationId { get; set; }

        /// <summary>
        /// A timestamp indicating when the operation was finished. This timestamp is generated on the server.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}