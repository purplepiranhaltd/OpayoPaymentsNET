using OpayoPaymentsNet.Domain.Entities.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders.Instructions
{
    public interface IOpayoInstructionRequestBuilderWithInstructionTypeRelease : IBuilder<OpayoInstructionRequest>
    {
    }

    public interface IOpayoInstructionRequestBuilderWithInstructionTypeReleaseAndAmount : IBuilder<OpayoInstructionRequest>, IBuildableBuilder<OpayoInstructionRequest>
    {
    }

    public interface IOpayoInstructionRequestBuilderWithInstructionTypeVoidAbortCancel : IBuilder<OpayoInstructionRequest>, IBuildableBuilder<OpayoInstructionRequest>
    {
    }
}
