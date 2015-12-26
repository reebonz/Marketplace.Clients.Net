using System.Linq;
using System.Web;

namespace Reebonz.Marketplace.Clients.Net.Helpers
{
    public static class ExtensionMethods
    {
        public static string ToQueryString(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}