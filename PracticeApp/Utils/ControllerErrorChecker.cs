namespace PracticeApp.Utils
{
    public static class ControllerErrorChecker
    {
        public static bool CheckDbAndId(int? id, object contextModel)
        {
            return id == null || contextModel == null;
        }

        public static bool CheckDbAndId(string id, object contextModel)
        {
            return string.IsNullOrEmpty(id) || contextModel == null;
        }

        public static bool CheckDbAndId(object contextModel)
        {
            return contextModel == null;
        }
    }
}