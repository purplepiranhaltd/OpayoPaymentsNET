using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Instructions
{
    public class OpayoInstructionRequest
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OpayoInstructionType InstructionType { get; set; }
        public int? Amount { get; set; }
    }
}
