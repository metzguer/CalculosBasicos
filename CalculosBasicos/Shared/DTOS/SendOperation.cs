using CalculosBasicos.Shared.Utils;
using Newtonsoft.Json;

namespace CalculosBasicos.Shared.DTOS
{
    public class SendOperation
    {
        [JsonProperty("Val1")]
        public string Val1 { get; set; }
        [JsonProperty("Val2")]
        public string Val2 { get; set; }
        [JsonProperty("Operacion")]
        public Operacion Operacion { get; set; }
    }
}
