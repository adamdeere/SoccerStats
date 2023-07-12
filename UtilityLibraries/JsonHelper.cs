using Newtonsoft.Json;

namespace UtilityLibraries
{
    public static class JsonHelper
    {
        public static void ToJsonFile(string obj, string filePath)
        {
            using StreamWriter sw = new StreamWriter(filePath);
            if (!string.IsNullOrEmpty(obj))
            {
                sw.WriteLine(obj);
            }
        }

        public static T? GetObjectFromJson<T>(string key)
        {
            return key == null ? default : JsonConvert.DeserializeObject<T>(key);
        }

        public static string ConvertObjectToJson(object jsonObject)
        {
            return JsonConvert.SerializeObject(jsonObject);
        }

        public static void WriteObjectToJson(object jsonObject, string filePath)
        {
            using StreamWriter sw = new(filePath);

            sw.WriteLine(JsonConvert.SerializeObject(jsonObject));
        }

        public static T? GetObjectFromJsonFile<T>(string file)
        {
            using StreamReader sr = new(file);

            return string.IsNullOrEmpty(file) == false
                ? JsonConvert.DeserializeObject<T>(sr.ReadToEnd())
                : default;
        }
    }
}