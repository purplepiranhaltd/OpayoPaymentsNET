using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public static class Opayo3DSecureChallengeResponseRequestBuilderExtensions
    {
        public static IBuildableBuilder<Opayo3DSecureChallengeResponseRequest> WithRequiredChallengeResult(this INewBuilder<Opayo3DSecureChallengeResponseRequest> builder, string cRes)
        {
            builder.Request.CRes = cRes;
            return (IBuildableBuilder<Opayo3DSecureChallengeResponseRequest>)builder;
        }
    }
}
