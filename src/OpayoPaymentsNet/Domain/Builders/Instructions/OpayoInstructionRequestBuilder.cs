using OpayoPaymentsNet.Domain.Entities.Instructions;
using OpayoPaymentsNet.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.Instructions
{
    public class OpayoInstructionRequestBuilder :
        IBuilder<OpayoInstructionRequest>,
        IBuildableBuilder<OpayoInstructionRequest>,
        INewBuilder<OpayoInstructionRequest>,
        IOpayoInstructionRequestBuilderWithInstructionTypeRelease,
        IOpayoInstructionRequestBuilderWithInstructionTypeReleaseAndAmount,
        IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel

    {
        OpayoInstructionRequest _request;

        public OpayoInstructionRequestBuilder()
        {
            _request= new OpayoInstructionRequest();
        }

        OpayoInstructionRequest IBuilder<OpayoInstructionRequest>.Request => _request;

        public static INewBuilder<OpayoInstructionRequest> Create()
        {
            return new OpayoInstructionRequestBuilder();
        }

        public Result<OpayoInstructionRequest> Build()
        {
            // nothing to validate as required fields are dealt with via the fluent builder.
            return new Result<OpayoInstructionRequest>(_request, true, Error.None);
        }
    }
}
