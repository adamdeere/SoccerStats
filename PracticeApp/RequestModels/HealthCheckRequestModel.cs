using Newtonsoft.Json;

namespace PracticeApp.RequestModels
{
    public class HealthCheckRequestModel
    {
        [JsonProperty("resultCode")]
        public int ResultCode { get; set; }

        [JsonProperty("resultMsg")]
        public string ResultMsg { get; set; }
    }
}
