using Newtonsoft.Json;

namespace SoccerStatsNew.Utils
{
    public static class JsonConverterUtil
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T? GetObjectFromJson<T>(string key)
        {
            return key == null ? default : JsonConvert.DeserializeObject<T>(key);
        }
        public static T? GetObjectFromJsonFile<T>(string key)
        {
            using StreamReader sr = new(key);
            string line = sr.ReadToEnd();
            return key == null ? default : JsonConvert.DeserializeObject<T>(line);

        }
    }
}