using System.Text.Json.Serialization;

namespace OpayoPaymentsNet.Domain.Entities.Instructions
{
    public class OpayoInstructionResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OpayoInstructionType InstructionType { get; set; }
        public DateTime Date { get; set; }
    }
}
