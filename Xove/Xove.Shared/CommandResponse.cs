using System;
using System.Collections.Generic;

namespace Xove.Shared
{
    public class CommandResponse
    {
        public CommandResponse()
        {
        }

        public CommandResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public bool IsSuccessful { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
