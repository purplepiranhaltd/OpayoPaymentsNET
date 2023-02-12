using OpayoPaymentsNet.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders
{
    public interface IBuilder<T> where T : class
    {
        internal T Request { get; }
    }
}
