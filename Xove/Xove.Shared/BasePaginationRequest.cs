using System.Collections.Generic;

namespace Xove.Shared
{
    public abstract class BasePaginationRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortDirection { get; set; }

        private static readonly Dictionary<string, string> _sortDirections = new Dictionary<string, string> {
            { "Ascending","ASC"},
            { "Descending","DESC"},
            { "None", "ASC"}
        };

        public string GetSortClause(Dictionary<string, string> sortDictionary, string defaultSortBy = null, string defaultSortDirection = "asc")
        {
            var sortFields = (sortDictionary[SortBy ?? defaultSortBy]).Split(',');

            var result = " ORDER BY ";

            for (int i = 0; i < sortFields.Length; i++)
            {
                result = $"{result} {sortFields[i]} {_sortDirections[SortDirection ?? defaultSortDirection]} {(i + 1 < sortFields.Length ? ", " : "")} ";
            }

            return result;
        }

        public abstract bool IsEmpty();
    }
}
