using System;
using System.Text;

namespace Granicus.Communications.Helpers
{
    public static class StringExtensions
    {
        public static string ToBase64(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }
    }
}
