namespace SoccerStatsNew.Services
{
    public interface IDbService
    {
        T? GetObjectFromJson<T>(string key);
    }
}