using Newtonsoft.Json;

namespace PracticeApp.RequestModels
{
    public class LocationList
    {
        [JsonProperty(nameof(LocationId))]
        public string LocationId { get; set; }

        [JsonProperty(nameof(Weight))]
        public double Weight { get; set; }

        [JsonProperty(nameof(Height))]
        public double Height { get; set; }

        [JsonProperty(nameof(Width))]
        public double Width { get; set; }

        [JsonProperty(nameof(Length))]
        public double Length { get; set; }
    }

    public class LocationRoot
    {
        [JsonProperty("List")]
        public List<LocationList> List { get; set; }

        [JsonProperty(nameof(QueryTotal))]
        public int QueryTotal { get; set; }

        [JsonProperty(nameof(RecordTotal))]
        public int RecordTotal { get; set; }

        [JsonProperty(nameof(Limit))]
        public int Limit { get; set; }

        [JsonProperty(nameof(Page))]
        public int Page { get; set; }

        [JsonProperty(nameof(Message))]
        public string Message { get; set; }
    }




}
