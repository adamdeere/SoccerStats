namespace PracticeApp.Utils
{
    public static class ControllerErrorChecker
    {
        public static bool CheckDbAndIntId(int? id, object contextModel)
        {
            return id == null || contextModel == null;
        }

        public static bool CheckDbAndStringId(string id, object contextModel)
        {
            return string.IsNullOrEmpty(id) || contextModel == null;
        }

        public static bool CheckDb(object contextModel)
        {
            return contextModel == null;
        }
    }
}