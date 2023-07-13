using Newtonsoft.Json;

namespace SoccerStatsData.RequestModels.PredictionRequestFiles
{
    public class LeagueForm
    {
        [JsonProperty("form")]
        public string? Form { get; set; }

        [JsonProperty("fixtures")]
        public FixturesForm Fixtures { get; set; }

        [JsonProperty("goals")]
        public FixturesFormGoals Goals { get; set; }

        [JsonProperty("biggest")]
        public Biggest Biggest { get; set; }

        [JsonProperty("clean_sheet")]
        public CleanSheetStats CleanSheet { get; set; }

        [JsonProperty("failed_to_score")]
        public CleanSheetStats FailedToScore { get; set; }

        [JsonProperty("lineups")]
        public List<Lineup> LineUps { get; set; }

        [JsonProperty("cards")]
        public Cards Cards { get; set; }

        [JsonProperty("penalty")]
        public Penalty Penalty { get; set; }
    }

    public class FixturesForm
    {
        [JsonProperty("played")]
        public FixturesFormData Played { get; set; }

        [JsonProperty("wins")]
        public FixturesFormData Wins { get; set; }

        [JsonProperty("draws")]
        public FixturesFormData Draws { get; set; }

        [JsonProperty("loses")]
        public FixturesFormData Loses { get; set; }
    }

    public class FixturesFormData
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class FixturesFormGoals
    {
        [JsonProperty("for")]
        public FixturesFormGoalsData For { get; set; }

        [JsonProperty("against")]
        public FixturesFormGoalsData Against { get; set; }
    }

    public class FixturesFormGoalsData
    {
        [JsonProperty("total")]
        public GoalsForm Total { get; set; }

        [JsonProperty("average")]
        public GoalsFormAverage Average { get; set; }
    }

    public class GoalsForm
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class GoalsFormAverage
    {
        [JsonProperty("home")]
        public string? Home { get; set; }

        [JsonProperty("away")]
        public string? Away { get; set; }

        [JsonProperty("total")]
        public string? Total { get; set; }
    }

    public class Minute
    {
        [JsonProperty("0-15")]
        public MinuteRange FirstHalfFirst { get; set; }

        [JsonProperty("16-30")]
        public MinuteRange FirstHalfSecond { get; set; }

        [JsonProperty("31-45")]
        public MinuteRange FirstHalfThird { get; set; }

        [JsonProperty("46-60")]
        public MinuteRange SecondHalfFirst { get; set; }

        [JsonProperty("61-75")]
        public MinuteRange SecondHalfSecond { get; set; }

        [JsonProperty("76-90")]
        public MinuteRange SecondHalfThird { get; set; }

        [JsonProperty("91-105")]
        public MinuteRange StoppageTime { get; set; }
    }

    public class MinuteRange
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
    }

    public class CleanSheetStats
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class Lineup
    {
        [JsonProperty("formation")]
        public string Formation { get; set; }

        [JsonProperty("played")]
        public int? Played { get; set; }
    }

    public class Cards
    {
        [JsonProperty("yellow")]
        public CardColour Yellow { get; set; }

        [JsonProperty("red")]
        public CardColour Red { get; set; }
    }

    public class CardColour
    {
        [JsonProperty("0-15")]
        public MinuteRange FirtHalfFirst { get; set; }

        [JsonProperty("16-30")]
        public MinuteRange FirstHalfSecond { get; set; }

        [JsonProperty("31-45")]
        public MinuteRange FirstHalfThird { get; set; }

        [JsonProperty("46-60")]
        public MinuteRange SecondHalfFirst { get; set; }

        [JsonProperty("61-75")]
        public MinuteRange SecondHalfSecond { get; set; }

        [JsonProperty("76-90")]
        public MinuteRange SecondHalfThird { get; set; }

        [JsonProperty("91-105")]
        public MinuteRange StoppageTime { get; set; }
    }

    public class Penalty
    {
        [JsonProperty("scored")]
        public PenConversionRate Scored { get; set; }

        [JsonProperty("missed")]
        public PenConversionRate Missed { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }

    public class PenConversionRate
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("percentage")]
        public string Percentage { get; set; }
    }
}