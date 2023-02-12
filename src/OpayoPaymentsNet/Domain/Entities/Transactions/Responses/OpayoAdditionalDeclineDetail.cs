using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoAdditionalDeclineDetail
    {
        /// <summary>
        /// This contains the additional decline code. (example values, 03, R1, N4, 59 etc.)
        /// </summary>
        public string AdditionalDeclineCode { get; set; }

        /// <summary>
        /// Description of the additional decline code. This will vary according to your acquiring bank
        /// </summary>
        public string AdditionalDeclineCodeDescription { get; set; }

        /// <summary>
        /// This is the category of the decline. Currently there are 4 categories, but could increase in future. (Example 01, 02, 03, 04.)
        /// 01: Card declined, do not re-attempt within a rolling 30 day period.
        /// 02: Card issuer cannot approve at this time. Re-attempt authorisation permitted, but limited to 15 re-attempts within a rolling 30 day period.
        /// 03: Incorrect data, or updated or additional card account information is required. 
        ///     For these the authorisation data will need to be corrected before re-attempt. 
        ///     Such issues are incorrect / missing expiry date, authentication value. 
        ///     Contact cardholder and correct information. 
        ///     Note: Limited to 15 re-attempts within a rolling 30 day period and no more than 25,000 category 03 declines per MID per rolling 
        ///           30 day period per card scheme.
        /// 04: Re-attempt authorisation permitted. Re-attempts limited to 15 within a rolling 30 day period.
        /// </summary>
        public string AdditionalDeclineCodeCategory { get; set; }
    }
}
