namespace NetsSharp.Models
{
    public class ProcessRequestOptions
    {
        /// <summary>
        /// A description string for the merchant.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The amount described as the lowest monetary unit, example: 100,00 NOK is noted as "10000", 9.99 USD is noted as "999". Note that both CREDIT and CAPTURE support partial captures and credits.
        /// 
        /// If no transaction amount is specified, for CAPTURE and CREDIT, the full available amount will be catured or credited, respectively.
        /// </summary>
        public int? TransactionAmount { get; set; }

        /// <summary>
        /// The transaction reconciliation reference is a merchant created reference local to a transaction. It is sent to certain acquirers and is returned with settlement. Not all acquirers support returning transaction reconciliation references.
        /// 
        /// A transaction reconciliation reference can be submitted when a transaction is registered with the Register call. This reference will then serve as a default reference if the reconciliation reference is omitted in the Process-call.
        /// 
        /// The transaction reconciliation reference can also be omitted altogether.
        /// </summary>
        public string TransactionReconRef { get; set; }
    }
}
