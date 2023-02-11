using OpayoPaymentsNet.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Domain.Builders
{
    public interface INewBuilder<T> : IBuilder<T> where T : class
    {
    }
}
