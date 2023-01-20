using OpayoPaymentsNet.Domain.Entities.Enums;

namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoStrongCustomerAuthentication
    {
        /// <summary>
        /// Fully qualified URL of the system that receives the CRes message or Error Message and where your customer will be returned once they have completed their challenge. 
        /// The CRes message is posted by the ACS through the Cardholder browser at the end of the challenge AND once it receives an RRes (Result Response) message from Sage Pay.
        /// </summary>
        public string? NotificationURL { get; set; }

        /// <summary>
        /// Fully qualified URL of the system that receives the CRes message or Error Message and where your customer will be returned once they have completed their challenge. 
        /// The CRes message is posted by the ACS through the Cardholder browser at the end of the challenge AND once it receives an RRes (Result Response) message from Sage Pay.
        /// </summary>
        public string? BrowserIP { get; set; }

        /// <summary>
        /// Exact content of the HTTP accept headers as sent to the 3DS Requestor from the Cardholder’s browser.
        /// </summary>
        public string? BrowserAcceptHeader { get; set; }

        /// <summary>
        /// Boolean that represents the ability of the cardholder browser to execute JavaScript.
        /// </summary>
        public bool? BrowserJavascriptEnabled { get; set; } = false;

        /// <summary>
        /// Boolean that represents the ability of the cardholder browser to execute Java.
        /// Value is returned from the navigator.javaEnabled property.
        /// Required if browserJavascriptEnabled is true.
        /// </summary>
        public bool? BrowserJavaEnabled { get; set; } = false;

        /// <summary>
        /// Value representing the browser language as defined in IETF BCP47. Returned from navigator.language property.
        /// </summary>
        public string? BrowserLanguage { get; set; }

        /// <summary>
        /// Value representing the bit depth of the colour palette for displaying images, in bits per pixel.
        /// Required if browserJavascriptEnabled is true.
        /// </summary>
        public string? BrowserColorDepth { get; set; }

        /// <summary>
        /// Total height of the Cardholder’s screen in pixels. Value is returned from the screen.height property. 
        /// Required if BrowserJavascriptEnabled is true.
        /// </summary>
        public string? BrowserScreenHeight { get; set; }

        /// <summary>
        /// Total width of the cardholder’s screen in pixels.Value is returned from the screen.width property.
        /// Required if BrowserJavascriptEnabled is true.
        /// </summary>
        public string? BrowserScreenWidth { get; set; }

        /// <summary>
        /// Time-zone offset in minutes between UTC and the Cardholder browser local time.
        /// 
        /// Note : The offset is positive if the local time zone is behind UTC and negative if it is ahead.
        /// 
        /// Example time zone offset values in minutes:
        /// 
        /// If UTC -5 hours(-300 minutes) :
        /// 
        /// 300
        /// +300
        /// 
        /// If UTC +5 hours(300 minutes) :
        /// 
        /// -300
        /// 
        /// Required if browserJavascriptEnabled is true.
        /// </summary>
        public string? BrowserTZ { get; set; }

        /// <summary>
        /// Exact content of the HTTP accept headers as sent to the 3DS Requestor from the Cardholder’s browser.
        /// </summary>
        public string? BrowserUserAgent { get; set; }

        /// <summary>
        /// Dimensions of the challenge window that has been displayed to the Cardholder.
        /// </summary>
        public string? ChallengeWindowSize { get; set; }

        /// <summary>
        /// The account ID, if applicable, of your customers account on your website.
        /// </summary>
        public string? AcctID { get; set; }

        /// <summary>
        /// Identifies the type of transaction being authenticated.
        /// </summary>
        public TransType? TransType { get; set; }

        /// <summary>
        /// Information about how you authenticated the cardholder before or during the transaction. 
        /// E.g. Did your customer log into their online account on your website, using two-factor authentication, 
        /// or did they log in as a guest.
        /// </summary>
        public OpayoThreeDSRequestorAuthenticationInfo? ThreeDSRequestorAuthenticationInfo { get; set; }

        /// <summary>
        /// Information about how you authenticated the cardholder as part of a previous 3DS transaction. 
        /// E.g. Were they authenticated via frictionless authentication or did a cardholder challenge occur.
        /// </summary>
        public OpayoThreeDSRequestorPriorAuthenticationInfo? ThreeDSRequestorPriorAuthenticationInfo { get; set; }

        /// <summary>
        /// Additional information about the Cardholder's account that has been provided by you.
        /// E.g. How long has the cardholder had the account on your website.
        /// </summary>
        public OpayoAccountInfo? AcctInfo { get; set; }

        /// <summary>
        /// Indicates the reason you're bypassing 3D Secure authentication. Use in conjunction with apply3DSecure:Disable.
        /// You must first get permission from your acquirer to use exemptions. Using exemptions means that fraud liability,
        /// for the transaction, is shifted to you the merchant. If the card issuer does not agree with the exemption, they can return a
        /// 'soft decline' - response code of bankResponseCode:65 or bankResponseCode:1A - Opayo will automatically request for 3D Secure
        /// authentication and submit another authorisation request to the card issuer with 3D Secure authentication data.
        /// It is important that you correctly populate the required field values for the strongCustomerAuthentication object.
        /// </summary>
        public OpayoMerchantRiskIndicator? MerchantRiskIndicator { get; set; }

        /// <summary>
        /// Fully qualified URL of the website this transaction came from. This field is useful if transactions
        /// can originate from more than one website. Supplying this information will enable reporting to be performed by website.
        /// </summary>
        public string? Website { get; set; }
    }
}
