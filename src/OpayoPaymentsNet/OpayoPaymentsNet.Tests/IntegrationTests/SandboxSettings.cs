using OpayoPaymentsNet.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Tests.IntegrationTests
{
    public static class SandboxSettings
    {
        public static OpayoSettings Get => new(
                "sandbox",
                "hJYxsw7HLbj40cB8udES8CDRFLhuJ8G54O6rDpUXvE6hYDrria",
                "o2iHSrFybYMZpmWOQMuhsXP52V4fBtpuSDshrKDSWsBY1OiN6hwd9Kb12z4j5Us5u",
                OpayoEnvironment.Sandbox);

        public static OpayoSettings GetExtraChecks => new(
                "sandboxEC",
                "dq9w6WkkdD2y8k3t4olqu8H6a0vtt3IY7VEsGhAtacbCZ2b5Ud",
                "hno3JTEwDHy7hJckU4WuxfeTrjD0N92pIaituQBw5Mtj7RG3V8zOdHCSPKwJ02wAV",
                OpayoEnvironment.Sandbox);
    }
}
