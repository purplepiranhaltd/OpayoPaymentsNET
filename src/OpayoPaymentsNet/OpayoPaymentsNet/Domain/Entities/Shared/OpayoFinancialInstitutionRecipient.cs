namespace OpayoPaymentsNet.Domain.Entities.Shared
{
    public class OpayoFinancialInstitutionRecipient
    {
        /// <summary>
        /// Primary recipient's account number. This can either be:
        /// - The first 6 and last 4 characters of the primary recipient's card PAN (no spaces).
        /// - Where the primary recipient's account is not a card PAN;
        ///   this will contain up to 10 characters of the account number (alphanumeric),
        ///   unless the account number is less than 10 characters long, 
        ///   in which case the account number will be present in its entirety.
        /// </summary>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// This is the surname of the primary recipient. 
        /// No special characters such as apostrophes or hyphens are permitted.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// This is the postcode of the primary recipient.
        /// </summary>
        public string? Postcode { get; set; }

        /// <summary>
        /// This is the date of birth of the primary recipient in the format YYYYMMDD.
        /// </summary>
        public string? DateOfBirth { get; set; }
    }
}
