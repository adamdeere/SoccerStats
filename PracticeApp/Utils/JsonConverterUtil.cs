using Newtonsoft.Json;

namespace PracticeApp.Utils
{
    public static class JsonConverterUtil
    {
        public static string ConvertObjectToJson(object jsonObject) 
        {
            return JsonConvert.SerializeObject(jsonObject);
        }

        public static T? GetObjectFromJson<T>(string key)
        {
            return key == null ? default : JsonConvert.DeserializeObject<T>(key);
        }
    }
}