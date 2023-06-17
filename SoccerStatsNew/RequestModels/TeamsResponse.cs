using Newtonsoft.Json;

namespace SoccerStatsNew.RequestModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TeamPaging
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class TeamParameters
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class TeamResponse
    {
        [JsonProperty("team")]
        public TeamTeam Team { get; set; }

        [JsonProperty("venue")]
        public TeamVenue Venue { get; set; }
    }

    public class TeamRoot
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        [JsonProperty("parameters")]
        public TeamParameters Parameters { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("paging")]
        public TeamPaging Paging { get; set; }

        [JsonProperty("response")]
        public List<TeamResponse> Response { get; set; }
    }

    public class TeamTeam
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("founded")]
        public int Founded { get; set; }

        [JsonProperty("national")]
        public bool National { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    public class TeamVenue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("surface")]
        public string Surface { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }


}
