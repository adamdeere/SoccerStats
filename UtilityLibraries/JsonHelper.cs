using Newtonsoft.Json;

namespace UtilityLibraries
{
    public static class JsonHelper
    {
        public static T? GetObjectFromJson<T>(string key)
        {
            return key == null ? default : JsonConvert.DeserializeObject<T>(key);
        }

        public static string ConvertObjectToJson(object jsonObject)
        {
            return JsonConvert.SerializeObject(jsonObject);
        }
    }
}