using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using stottle_shop_api.Products.Models;

namespace stottle_shop_api.Products.Extensions
{
    public static class ProductFilterCriteriaExtensions
    {
        public static FilterDefinition<Product> CreateFilter(this ProductFilterCriteria searchCriteria)
        {
            var filters = new List<FilterDefinition<Product>>();

            var isActivefilter = Builders<Product>.Filter.Eq(p => p.IsActive, true);
            filters.Add(isActivefilter);

            if (!string.IsNullOrWhiteSpace(searchCriteria.SearchTerm))
            {
                var filter = Builders<Product>.Filter.Where(p => p.DisplayName.ToLowerInvariant()
                    .Contains(searchCriteria.SearchTerm.ToLowerInvariant()));
                filters.Add(filter);
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.Category))
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Category.Code, searchCriteria.Category);
                filters.Add(filter);
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.Filters))
            {
                var searchFilters = searchCriteria.Filters.Split(',');
                var filter = Builders<Product>.Filter.Where(p => p.Filters.Any(f => searchFilters.Contains(f.Code)));
                filters.Add(filter);
            }

            var filterCombined = Builders<Product>.Filter.And(filters);
            return filterCombined;
        }
    }
}
