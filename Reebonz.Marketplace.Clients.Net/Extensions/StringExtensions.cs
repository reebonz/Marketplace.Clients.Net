

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reebonz.Marketplace.Clients.Net.Extensions
{
    public static class StringExtensions
    {
        public static string FormatWith(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static string ToQueryString(this object obj)
        {
            var props = new List<string>();
            if (obj == null)
            {
                return string.Empty;
            }

            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(obj, null);
                if (value!=null)
                {
                    var encodedValue = HttpUtility.UrlEncode(value.ToString());
                    props.Add($"{propertyInfo.Name}={encodedValue}");
                }
            }

            return string.Join("&", props);
        }

        public static bool IsSameAs(this string source, string dest)
        {
            return source == dest || (source.IsNullOrEmpty() && dest.IsNullOrEmpty());
        }
    }
}
