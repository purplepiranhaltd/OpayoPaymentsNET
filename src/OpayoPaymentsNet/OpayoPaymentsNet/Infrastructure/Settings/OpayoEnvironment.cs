using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Settings
{
    public enum OpayoEnvironment
    {
        /// <summary>
        /// Production server (uses live data)
        /// </summary>
        Live,

        /// <summary>
        /// Sandbox server (uses test data, not connected to banks)
        /// </summary>
        Sandbox
    }
}
