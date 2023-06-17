using Newtonsoft.Json;

namespace SoccerStatsNew.RequestModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class _015
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _106120
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _1630
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _3145
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _4660
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _6175
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _7690
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class _91105
    {
        [JsonProperty("total")]
        public object Total { get; set; }

        [JsonProperty("percentage")]
        public object Percentage { get; set; }
    }

    public class Against
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("average")]
        public string Average { get; set; }

        [JsonProperty("minute")]
        public Minute Minute { get; set; }

        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }
    }

    public class Att
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }

    public class Average
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
    }

    public class Away
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("last_5")]
        public Last5 Last5 { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("winner")]
        public bool Winner { get; set; }
    }

    public class Biggest
    {
        [JsonProperty("streak")]
        public Streak Streak { get; set; }

        [JsonProperty("wins")]
        public Wins Wins { get; set; }

        [JsonProperty("loses")]
        public Loses Loses { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }
    }

    public class Cards
    {
        [JsonProperty("yellow")]
        public Yellow Yellow { get; set; }

        [JsonProperty("red")]
        public Red Red { get; set; }
    }

    public class CleanSheet
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Comparison
    {
        [JsonProperty("form")]
        public Form Form { get; set; }

        [JsonProperty("att")]
        public Att Att { get; set; }

        [JsonProperty("def")]
        public Def Def { get; set; }

        [JsonProperty("poisson_distribution")]
        public PoissonDistribution PoissonDistribution { get; set; }

        [JsonProperty("h2h")]
        public H2h H2h { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        [JsonProperty("total")]
        public Total Total { get; set; }
    }

    public class Def
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }

    public class Draws
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Extratime
    {
        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }
    }

    public class FailedToScore
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Fixture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("referee")]
        public string Referee { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("periods")]
        public Periods Periods { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public class Fixtures
    {
        [JsonProperty("played")]
        public Played Played { get; set; }

        [JsonProperty("wins")]
        public Wins Wins { get; set; }

        [JsonProperty("draws")]
        public Draws Draws { get; set; }

        [JsonProperty("loses")]
        public Loses Loses { get; set; }
    }

    public class For
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("average")]
        public string Average { get; set; }

        [JsonProperty("minute")]
        public Minute Minute { get; set; }

        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }
    }

    public class Form
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }

    public class Fulltime
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }
    }

    public class Goals
    {
        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }

        [JsonProperty("for")]
        public For For { get; set; }

        [JsonProperty("against")]
        public Against Against { get; set; }
    }

    public class H2h
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }

        [JsonProperty("fixture")]
        public Fixture Fixture { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("teams")]
        public Teams Teams { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        [JsonProperty("score")]
        public Score Score { get; set; }
    }

    public class Halftime
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }
    }

    public class Home
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("last_5")]
        public Last5 Last5 { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("winner")]
        public bool Winner { get; set; }
    }

    public class Last5
    {
        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("att")]
        public string Att { get; set; }

        [JsonProperty("def")]
        public string Def { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }
    }

    public class League
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("form")]
        public object Form { get; set; }

        [JsonProperty("fixtures")]
        public Fixtures Fixtures { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        [JsonProperty("biggest")]
        public Biggest Biggest { get; set; }

        [JsonProperty("clean_sheet")]
        public CleanSheet CleanSheet { get; set; }

        [JsonProperty("failed_to_score")]
        public FailedToScore FailedToScore { get; set; }

        [JsonProperty("penalty")]
        public Penalty Penalty { get; set; }

        [JsonProperty("lineups")]
        public List<object> Lineups { get; set; }

        [JsonProperty("cards")]
        public Cards Cards { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }
    }

    public class Loses
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Minute
    {
        [JsonProperty("0-15")]
        public _015 _015 { get; set; }

        [JsonProperty("16-30")]
        public _1630 _1630 { get; set; }

        [JsonProperty("31-45")]
        public _3145 _3145 { get; set; }

        [JsonProperty("46-60")]
        public _4660 _4660 { get; set; }

        [JsonProperty("61-75")]
        public _6175 _6175 { get; set; }

        [JsonProperty("76-90")]
        public _7690 _7690 { get; set; }

        [JsonProperty("91-105")]
        public _91105 _91105 { get; set; }

        [JsonProperty("106-120")]
        public _106120 _106120 { get; set; }
    }

    public class Missed
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
    }

    public class Paging
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("fixture")]
        public string Fixture { get; set; }
    }

    public class Penalty
    {
        [JsonProperty("scored")]
        public Scored Scored { get; set; }

        [JsonProperty("missed")]
        public Missed Missed { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("home")]
        public object Home { get; set; }

        [JsonProperty("away")]
        public object Away { get; set; }
    }

    public class Percent
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("draw")]
        public string Draw { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }

    public class Periods
    {
        [JsonProperty("first")]
        public int First { get; set; }

        [JsonProperty("second")]
        public int Second { get; set; }
    }

    public class Played
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class PoissonDistribution
    {
        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("away")]
        public string Away { get; set; }
    }

    public class Predictions
    {
        [JsonProperty("winner")]
        public Winner Winner { get; set; }

        [JsonProperty("win_or_draw")]
        public bool WinOrDraw { get; set; }

        [JsonProperty("under_over")]
        public object UnderOver { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        [JsonProperty("advice")]
        public string Advice { get; set; }

        [JsonProperty("percent")]
        public Percent Percent { get; set; }
    }

    public class Red
    {
        [JsonProperty("0-15")]
        public _015 _015 { get; set; }

        [JsonProperty("16-30")]
        public _1630 _1630 { get; set; }

        [JsonProperty("31-45")]
        public _3145 _3145 { get; set; }

        [JsonProperty("46-60")]
        public _4660 _4660 { get; set; }

        [JsonProperty("61-75")]
        public _6175 _6175 { get; set; }

        [JsonProperty("76-90")]
        public _7690 _7690 { get; set; }

        [JsonProperty("91-105")]
        public _91105 _91105 { get; set; }

        [JsonProperty("106-120")]
        public _106120 _106120 { get; set; }
    }

    public class Response
    {
        [JsonProperty("predictions")]
        public Predictions Predictions { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("teams")]
        public Teams Teams { get; set; }

        [JsonProperty("comparison")]
        public Comparison Comparison { get; set; }

        [JsonProperty("h2h")]
        public List<H2h> H2h { get; set; }
    }

    public class PredictionRoot
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("results")]
        public int Results { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }

        [JsonProperty("response")]
        public List<Response> Response { get; set; }
    }

    public class Score
    {
        [JsonProperty("halftime")]
        public Halftime Halftime { get; set; }

        [JsonProperty("fulltime")]
        public Fulltime Fulltime { get; set; }

        [JsonProperty("extratime")]
        public Extratime Extratime { get; set; }

        [JsonProperty("penalty")]
        public Penalty Penalty { get; set; }
    }

    public class Scored
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
    }

    public class Status
    {
        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }
    }

    public class Streak
    {
        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("loses")]
        public int Loses { get; set; }
    }

    public class Teams
    {
        [JsonProperty("home")]
        public Home Home { get; set; }

        [JsonProperty("away")]
        public Away Away { get; set; }
    }

    public class Total
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int TotalGoal { get; set; }
    }

    public class Venue
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }

    public class Winner
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }

    public class Wins
    {
        [JsonProperty("home")]
        public int Home { get; set; }

        [JsonProperty("away")]
        public int Away { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Yellow
    {
        [JsonProperty("0-15")]
        public _015 _015 { get; set; }

        [JsonProperty("16-30")]
        public _1630 _1630 { get; set; }

        [JsonProperty("31-45")]
        public _3145 _3145 { get; set; }

        [JsonProperty("46-60")]
        public _4660 _4660 { get; set; }

        [JsonProperty("61-75")]
        public _6175 _6175 { get; set; }

        [JsonProperty("76-90")]
        public _7690 _7690 { get; set; }

        [JsonProperty("91-105")]
        public _91105 _91105 { get; set; }

        [JsonProperty("106-120")]
        public _106120 _106120 { get; set; }
    }
}