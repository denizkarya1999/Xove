using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace Xove.Web.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static bool TryGetQueryString<T>(this NavigationManager navManager, string key, out T value)
        {
            var uri = navManager.ToAbsoluteUri(navManager.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue(key, out var valueFromQueryString))
            {
                if (typeof(T) == typeof(int) && int.TryParse(valueFromQueryString, out var valueAsInt))
                {
                    value = (T)(object)valueAsInt;
                    return true;
                }

                if (typeof(T) == typeof(string))
                {
                    value = (T)(object)valueFromQueryString.ToString();
                    return true;
                }

                if (typeof(T) == typeof(decimal) && decimal.TryParse(valueFromQueryString, out var valueAsDecimal))
                {
                    value = (T)(object)valueAsDecimal;
                    return true;
                }

                if (typeof(T) == typeof(Guid) && Guid.TryParse(valueFromQueryString, out var valueAsGuid))
                {
                    value = (T)(object)valueAsGuid;
                    return true;
                }

                if (typeof(T) == typeof(Nullable<DateTime>))
                {
                    DateTime valueAsDateTime;
                    if (DateTime.TryParse(valueFromQueryString, out valueAsDateTime))
                    {
                        value = (T)(object)valueAsDateTime;
                    }
                    else
                    {
                        value = (T)(object)null;
                    }

                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
