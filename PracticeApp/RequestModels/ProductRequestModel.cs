using Newtonsoft.Json;

namespace PracticeApp.RequestModels
{
    public class ProductList
    {
        [JsonProperty(nameof(SKU))]
        public string SKU { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("length")]
        public double Length { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("test1")]
        public string Test1 { get; set; }
    }

    public class ProductRoot
    {
        [JsonProperty("List")]
        public List<ProductList> List { get; set; }

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
