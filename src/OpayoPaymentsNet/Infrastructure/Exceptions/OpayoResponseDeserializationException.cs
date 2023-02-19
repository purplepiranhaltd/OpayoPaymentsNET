using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpayoPaymentsNet.Infrastructure.Exceptions
{
    public class OpayoResponseDeserializationException : Exception
    {
        const string MESSAGE = "Could not deserialize response from Opayo. The raw response is available for inspection.";
        public string? RawResponse { get; private set; }
        public OpayoResponseDeserializationException(string? rawResponse) : base(MESSAGE)
        {
            RawResponse = rawResponse;
        }

        public OpayoResponseDeserializationException(string? rawResponse, Exception inner) : base(MESSAGE, inner)
        {
            RawResponse = rawResponse;
        }
    }
}
