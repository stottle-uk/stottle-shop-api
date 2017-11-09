using stottle_shop_api.Filters.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace stottle_shop_api.Filters.Data
{
    public static class TestFilterData
    {
        public static IEnumerable<Filter> GetFilter(int maxFilters) =>
            Enumerable
                .Range(0, maxFilters)
                .Select(count => new Filter
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = $"filter{count}",
                    DisplayName = $"Filter {count}",
                    IsActive = true,
                    Items = count.GetFilters()
                });


        private static IEnumerable<FilterItem> GetFilters(this int count)
        {
            var filterCode = count % 4 == 1 ? "fil0" : "fil1";

            return Enumerable
                .Range(0, 10)
                .Select(filCount => new FilterItem
                {
                    Code = $"{filterCode}{filCount}",
                    DisplayName = $"filter {filCount}"
                });
        }
    }
}
