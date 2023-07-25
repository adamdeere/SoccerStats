using System.Text;

namespace UtilityLibraries
{
    public static class StringHelper
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

        public static string StringReverese(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                char[] chars = s.ToCharArray();
                Array.Reverse(chars);

                StringBuilder sb = new();
                foreach (char c in chars)
                {
                    sb.Append(c);
                }
                return sb.ToString();
            }
            return string.Empty;
        }

        public static char[] ToCharArray(string s) 
        {
            if (!string.IsNullOrEmpty(s))
            {
                char[] chars = s.ToCharArray();
                Array.Reverse(chars);

                return chars;
            }
           return Array.Empty<char>();  
        }
    }
   
}