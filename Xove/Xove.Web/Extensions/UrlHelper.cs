using System;
using System.Reflection;
using System.Text;

namespace Xove.Web.Extensions
{
    public static class UrlHelper
    {
        public static string ToUrl(this Object instance)
        {
            var urlBuilder = new StringBuilder();
            var properties = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            for (int i = 0; i < properties.Length; i++)
            {
                var value = properties[i].GetValue(instance, null);
                if (value != null)
                {
                    urlBuilder.AppendFormat("{0}={1}&", properties[i].Name.ToLower(), value);
                }
            }
            if (urlBuilder.Length > 1)
            {
                urlBuilder.Remove(urlBuilder.Length - 1, 1);
            }
            return urlBuilder.ToString();
        }
    }
}
