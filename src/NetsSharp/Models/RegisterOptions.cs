using System;

namespace NetsSharp.Models
{
    public class RegisterOptions
    {
        public RegisterOptions()
        {
            ServiceType = ServiceType.Hosted;
            Language = Language.Norwegian;
            EnvironmentLanguage = "C#";
        }

        /// <summary>
        /// The Service Type indicates which kind of terminal will be used for this transaction. There are currently three different kinds of terminals available:
        ///
        /// B: The terminal will be hosted by Netaxept
        /// M: The terminal will be hosted by the merchant
        /// C: The transaction will be a call center transaction, and no terminal will be shown to the card holder
        /// 
        /// The parameter is optional, and will default to “B” if omitted.
        /// </summary>
        public ServiceType ServiceType { get; set; }


        /// <summary>
        /// The Transaction ID is a unique ID that is used to reference the transaction in our systems at any point. The Transaction ID needs to be unique for the merchant ID. If the Transaction ID is omitted, the Netaxept service will generate an ID for you.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// A description string for the merchant.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Set this variable to true if the card holder must be fully verified by 3D-secure to complete the transaction. (Only completed transaction with ECI: VISA: 05, MasterCard: 02) 
        /// </summary>
        public bool Force3DSecure { get; set; }

        /// <summary>
        /// If this variable is set, the terminal will work in “EasyPayment” update-mode, and will not make complete transactions. The interface will change to reflect the fact that the cardholder is not completing a full transaction, rather changing or updating his payment information for future EasyPayments or RecurringPayments
        /// 
        /// With UpdateStoredPaymentInfo, the AUTH call is available for the transaction. The AUTH call will change its meaning slightly, as it will run an online AUTH to check that the card is “alive”, then immediately ANNUL the transaction, so the AUTH-call is not effectuated.
        /// 
        /// The other calls (CREDIT, CAPTURE, SALE, ANNUL) will give out NotSupportedExceptions. 
        /// </summary>
        public bool UpdateStoredPaymentInfo { get; set; }

        /// <summary>
        /// Ordering Netaxept to automatically do a CAPTURE call at that date. The merchant does an AUTH after the REGISTER call as normal (but the CAPTURE will the taken care of by Netaxept).
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Which programming language is being used to implement the merchant solution.
        /// </summary>
        public string EnvironmentLanguage { get; private set; }

        /// <summary>
        /// A textual description of the order. This can be HTML-formatted. If you are using NETS-hosted terminal this description will appear in the terminal. Unlike the other fields, the order description will not cause the call to fail if it exceeds its maximum amount, rather the field will be truncated to its maximum amount.
        /// </summary>
        public string OrderDescription { get; set; }

        /// <summary>
        /// For ServiceType.Hosted, which language is used in the terminal presented by NETS. Valid values are "no_NO" (Norwegian), "sv_SE" (Swedish), "da_DK" (Danish), "de_DE (German), "fi_FI" (Finnish), "ru_RU" (Russian), "pl_PL" (Polish), "es_ES" (Spanish) and "en_GB" (English). If the terminal language is omitted, the default language is set to Norwegian; “no_NO”.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Where to send the customer when the transaction has been registered at NETS. This URL can contain GET-parameters. The redirect URL is not used with callcenter-transactions.
        ///
        /// The redirect URL is optional when using “AutoAuth”.
        /// </summary>
        public Uri RedirectUrl { get; set; }

        /// <summary>
        /// Specifies how much of the transaction amount is value added tax (VAT). Specified as an amount in the lowest monitary unit (such as transaction amount). Specify 10000 to indicate a VAT amount of 100.00 in the specified currency.
        /// 
        /// The VAT will be presented in the terminal, and in the Netaxept administration interface.
        /// 
        /// Note that Netaxept regards this amount as a part of the total transaction amount, as to not affect this amount. This is different from fee.
        /// </summary>
        public int TerminalVat { get; set; }

        /// <summary>
        /// If the terminal is set to use automatic authorization, a financial call is made at the end of the registration process. This financial call is an “authorization”. This call is only recommended used by merchants who do not have their own webshop.
        /// 
        /// Using automatic authorization allows merchants to send out a payment request using other means than a web based shop, for example email. If used without a redirect URL, the terminal will show a localized “payment completed”-message.
        /// 
        /// Auto auth and auto sale should not be specified together, as they are mutually exclusive.
        /// </summary>
        public bool AutoAuth { get; set; }

        /// <summary>
        /// If the terminal is set to use automatic sale, a financial call is made at the end of the registration process. This financial call is an “sale”, which combines the "auth" and "capture" operations. This call is only recommended used by merchants who do not have their own webshop.
        /// 
        /// Using automatic sale allows merchants to send out a payment request using other means than a web based shop, for example email. If used without a redirect URL, the terminal will show a localized “payment completed”-message.
        /// 
        /// Auto auth and auto sale should not be specified together, as they are mutually exclusive.
        /// </summary>
        public bool AutoSale { get; set; }

        /// <summary>
        /// The terminal design parameter can control the look of the terminal on a per transaction basis. If this optional parameter is sent in, it will look up the template from the template names in the list of available templates. If the template cannot be looked up by name, the default template will be used.
        /// </summary>
        public string TerminalDesign { get; set; }

        /// <summary>
        /// The terminal single page option can be used to change the behavior of the Netaxept terminal from being multipage to being single page. In single page mode, the card input fields will be consolidated into a single input field, with the different card options shown as small icons. On entering the card number, the selected card type will light up as visual feedback to the user.
        /// 
        /// Because of the nature of this terminal mode, singlePage works only for card payments, and excludes other payment methods.
        /// </summary>
        public bool TerminalSinglePage { get; set; }

        /// <summary>
        /// Set this variable to "mini" to activate the minimized version of the terminal.
        /// 
        /// Error messages will not be displayed inside this terminal (in order to keep it as minimized as possible). The error message can be placed anywhere else on the webpage using a template tag (see Terminal design templates).
        /// 
        /// Given that an iPhone/iOS template is used for Netaxept mobile, the top navigation bar will not be shown if terminalLayout is specified as "mini". This does currently not apply to the other templates.
        /// </summary>
        public string TerminalLayout { get; set; }

        /// <summary>
        /// Your internal customer number.
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Customer e-mail.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// The customer's phone number.
        /// 
        /// The phone number should be given on the format of +[country code][phone number], eg: +4712345678, +469876543.
        /// </summary>
        public string CustomerPhoneNumber { get; set; }

        /// <summary>
        /// The customer's first name.
        /// </summary>
        public string CustomerFirstName { get; set; }

        /// <summary>
        /// The customer's last name.
        /// </summary>
        public string CustomerLastName { get; set; }

        /// <summary>
        /// The customer's first address line.
        /// </summary>
        public string CustomerAddress1 { get; set; }

        /// <summary>
        /// The customer's second address line.
        /// </summary>
        public string CustomerAddress2 { get; set; }

        public string CustomerPostCode { get; set; }
        public string CustomerTown { get; set; }

        /// <summary>
        /// The customer's country. This should follow ISO 3166-1 Alpha 2 code. Typical examples would be "NO", "SE", "DK", "FI" etc.
        /// </summary>
        public string CustomerCountry { get; set; }

        /// <summary>
        /// The customer's social security number. Required for PayByBill.
        /// </summary>
        public string CustomerSocialSecurityNumber { get; set; }

        /// <summary>
        /// The customer's company name.
        /// 
        /// Set this field for SEB direct payment to indicate direct payment as a business customer.
        /// 
        /// Let this field be empty for SEB direct payment to indicate direct payment as a private customer.
        /// </summary>
        public string CustomerCompanyName { get; set; }

        /// <summary>
        /// Notify Klarna that invoice is to be sent by post or email.
        /// 
        /// Set NotificationMode to "MAIL" to inform Klarna that invoice is to be sent to customer by post. 
        /// Set NotificationMode to "EMAIL" to inform Klarna that invoice is to be sent to customer by email.
        /// </summary>
        public string CustomerNotificationMode { get; set; }

        /// <summary>
        /// Personal account number. The card number to be used for this transaction.
        /// 
        /// Note: Only used with call center transactions.
        /// </summary>
        public string Pan { get; set; }

        /// <summary>
        /// The expiry date for the card used for this transaction, on the form MMYY.
        /// 
        /// Note: Only used with call center transactions.
        /// </summary>
        public string ExpiryDate { get; set; }

        /// <summary>
        /// The security code for the card.
        /// 
        /// Note: Only used with call center transactions.
        /// </summary>
        public int? SecurityCode { get; set; }

        /// <summary>
        /// A transaction reconciliation reference can be submitted when a transaction is registered. This reference will be used on any subsequent financial operations on this transaction, unless it is overridden when the financial transaction is sent in. The transaction reconciliation reference in the register call can be seen as a “default” reconciliation reference for this transaction.
        /// 
        /// The order number and transaction reconcilliation reference are subject to acquirer support as to what data is supplied for the settlement report. See the transaction reference page for details as to what format your acquirer supports.
        /// </summary>
        public string TransactionReconRef { get; set; }
    }
}