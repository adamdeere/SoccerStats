using Newtonsoft.Json;

namespace PracticeApp.RequestModels
{
    public class ItemRequestModel
    {
        public class ItemList
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

        public class ItemRoot
        {
            [JsonProperty("List")]
            public List<ItemList> ListOfItems { get; set; }

            [JsonProperty(nameof(QueryTotal))]
            public int QueryTotal { get; set; }

            [JsonProperty(nameof(Limit))]
            public int Limit { get; set; }

            [JsonProperty(nameof(Page))]
            public int Page { get; set; }

            [JsonProperty(nameof(Message))]
            public string Message { get; set; }
        }


    }
}
