using System.Runtime.CompilerServices;

namespace NetAdmin.Infrastructure
{
    public static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasText(this string text)
        {
            return text != null && !string.IsNullOrEmpty(text);
        }
    }
}