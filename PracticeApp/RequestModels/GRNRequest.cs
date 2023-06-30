using Newtonsoft.Json;

namespace PracticeApp.RequestModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Filter
    {
        [JsonProperty(nameof(Field))]
        public string Field { get; set; }

        [JsonProperty("Operand")]
        public string Operand { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public class GRNList
    {
        [JsonProperty(nameof(GRN))]
        public string GRN { get; set; }

        [JsonProperty(nameof(ItemNo))]
        public int ItemNo { get; set; }

        [JsonProperty(nameof(Quantity))]
        public double Quantity { get; set; }

        [JsonProperty(nameof(SKU))]
        public string SKU { get; set; }
    }

    public class GRNRoot
    {
        [JsonProperty("List")]
        public List<GRNList> ListOfGRN { get; set; }

        [JsonProperty(nameof(QueryTotal))]
        public int QueryTotal { get; set; }

        [JsonProperty(nameof(RecordTotal))]
        public int RecordTotal { get; set; }

        [JsonProperty(nameof(Limit))]
        public int Limit { get; set; }

        [JsonProperty(nameof(Page))]
        public int Page { get; set; }

        [JsonProperty(nameof(Filter))]
        public List<Filter> Filter { get; set; }

        [JsonProperty(nameof(Message))]
        public string Message { get; set; }
    }


}
