using System;
using System.Collections.Generic;

namespace Xove.Shared
{
    public class PaginationResponse<T>
    {
        public PaginationResponse(List<T> data = default, int totalCount = 0)
        {
            Data = data;
            TotalCount = totalCount;
        }

        public List<T> Data { get; set; }

        public int TotalCount { get; set; }
    }
}
