using System.Text;

namespace UtilityLibraries
{
    public static class StringStripper
    {
        public static string StripPunctuation(string s)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }
            string trimmed = string.Concat(sb.ToString().Where(c => !char.IsWhiteSpace(c)));
            return trimmed;
        }
    }
}