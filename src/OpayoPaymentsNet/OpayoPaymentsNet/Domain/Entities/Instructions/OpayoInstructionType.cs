using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Entities.Instructions
{
    public enum OpayoInstructionType
    {
        Void,
        Abort,
        Release,
        Cancel
    }
}
