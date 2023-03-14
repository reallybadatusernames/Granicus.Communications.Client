using System;
using System.Text;

namespace Granicus.Infrastructure.Helpers
{
    public static class IntExtensions
    {
        public static string ToBase64(this int value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value.ToString()));
        }
    }
}
