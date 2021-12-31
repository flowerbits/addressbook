using Newtonsoft.Json;

namespace AddressbookServer.Models
{
    public class JsonReturnData
    {
        public JsonReturnData() { }
        public JsonReturnData (bool success, object data)
        {
            IsOk = success;
            Data = data;
        }
        [JsonProperty("ok")]
        public bool IsOk { get; set; }
        [JsonProperty("statusText")]
        public object Status { get { return Data as string; } }
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
