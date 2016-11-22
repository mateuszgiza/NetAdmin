namespace NetAdmin.Helpers.Extensions
{
    public static class StringExtensions
    {
        public static bool HasText(this string text)
        {
            return text != null && !string.IsNullOrEmpty(text);
        }
    }
}