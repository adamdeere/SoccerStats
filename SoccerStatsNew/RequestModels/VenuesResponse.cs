namespace SoccerStatsNew.RequestModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class VenuePaging
    {
        public int current { get; set; }
        public int total { get; set; }
    }

    public class VenueParameters
    {
        public string country { get; set; }
    }

    public class VenueResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int capacity { get; set; }
        public string surface { get; set; }
        public string image { get; set; }
    }

    public class VenueRoot
    {
        public string get { get; set; }
        public VenueParameters parameters { get; set; }
        public List<object> errors { get; set; }
        public int results { get; set; }
        public VenuePaging paging { get; set; }
        public List<VenueResponse> response { get; set; }
    }
}