using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Settings
{
    public class OpayoSettings
    {
        public static Dictionary<OpayoEnvironment, string> EnvironmentServerUrl { get; }
        public static JsonSerializerOptions JsonSerializerOptions { get; }
        private static string sandboxServerUrl = "https://pi-test.sagepay.com/api/v1";
        private static string liveServerUrl = "https://pi-live.sagepay.com/api/v1";

        static OpayoSettings()
        {
            EnvironmentServerUrl = new Dictionary<OpayoEnvironment, string>();
            EnvironmentServerUrl.Add(OpayoEnvironment.Sandbox, sandboxServerUrl);
            EnvironmentServerUrl.Add(OpayoEnvironment.Live, liveServerUrl);

            JsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public OpayoSettings(string vendorName, string integrationKey, string integrationPassword, OpayoEnvironment environment)
        {
            VendorName = vendorName;
            IntegrationKey = integrationKey;
            IntegrationPassword = integrationPassword;
            Environment = environment;
        }

        public string VendorName { get; private set; }
        public string IntegrationKey { get; private set; }
        public string IntegrationPassword { get; private set; }
        public OpayoEnvironment Environment { get; private set; }
        public string OpayoEnvironmentUrl { get { return EnvironmentServerUrl[Environment]; } }
    }
}
