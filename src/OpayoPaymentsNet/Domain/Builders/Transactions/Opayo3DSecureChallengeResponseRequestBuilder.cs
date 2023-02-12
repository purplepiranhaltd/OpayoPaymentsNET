using OpayoPaymentsNet.Domain.Entities.Transactions.Requests;
using OpayoPaymentsNet.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.Transactions
{
    public class Opayo3DSecureChallengeResponseRequestBuilder :
        IBuilder<Opayo3DSecureChallengeResponseRequest>,
        INewBuilder<Opayo3DSecureChallengeResponseRequest>,
        IBuildableBuilder<Opayo3DSecureChallengeResponseRequest>
    {
        Opayo3DSecureChallengeResponseRequest _request;

        public Opayo3DSecureChallengeResponseRequestBuilder()
        {
            _request = new Opayo3DSecureChallengeResponseRequest();
        }

        public static INewBuilder<Opayo3DSecureChallengeResponseRequest> Create()
        {
            return new Opayo3DSecureChallengeResponseRequestBuilder();
        }

        Opayo3DSecureChallengeResponseRequest IBuilder<Opayo3DSecureChallengeResponseRequest>.Request => _request;

        public Result<Opayo3DSecureChallengeResponseRequest> Build()
        {
            // nothing to validate
            return new Result<Opayo3DSecureChallengeResponseRequest>(_request, true, Error.None);
        }
    }
}
