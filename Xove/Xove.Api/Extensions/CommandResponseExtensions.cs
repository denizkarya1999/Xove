using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using Xove.Shared;

namespace Xove.Api.Extensions
{
    public static class CommandResponseExtensions
    {
        public static T Success<T>(this T result, string message = null) where T : CommandResponse
        {
            result.IsSuccessful = true;
            if (message != null)
            {
                result.Message = message;
            }
            return result;
        }

        public static T Failed<T>(this T result, string message = null) where T : CommandResponse
        {
            result.IsSuccessful = false;
            if (message != null)
            {
                result.Message = message;
            }
            return result;
        }

        public static T Errors<T>(this T result, ModelStateDictionary modelState) where T : CommandResponse
        {
            result.IsSuccessful = false;
            result.Errors = modelState.ToDictionary();
            return result;
        }
    }
}
