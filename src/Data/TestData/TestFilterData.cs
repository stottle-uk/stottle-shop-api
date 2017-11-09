using stottle_shop_api.Filters.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace stottle_shop_api.Data.TestData
{
    public static class TestFilterData
    {
        public static IEnumerable<Filter> GetFilter(int maxFilters)
        {
            var items = Enumerable.Range(0, 10).Select(count => new FilterItem
            {
                DisplayName = $"Item {count}",
                Code = $"fil{count}"
            });

            return Enumerable
                .Range(0, maxFilters)
                .Select(count => new Filter
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = $"filter{count}",
                    DisplayName = $"Filter {count}",
                    IsActive = true,
                    Items = items
                });
        }
    }
}
