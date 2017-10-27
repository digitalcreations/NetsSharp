namespace NetsSharp.Exceptions
{
    using System;
    using Models;

    class ProcessException : Exception
    {
        private readonly ProcessResponse _response;

        public ProcessException(ProcessResponse response)
            : base(response.ResponseText)
        {
            _response = response;
        }

        /// <summary>
        /// The response code will be set to the string “OK” if the transaction was processed correctly. Any other response is an error, and should be logged with the Response Source and the Response Text.
        /// </summary>
        public string Code => _response.ResponseCode;

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
        public override string Source => _response.ResponseSource;
    }
}