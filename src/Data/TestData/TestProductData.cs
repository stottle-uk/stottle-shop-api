using stottle_shop_api.Categories.Models;
using stottle_shop_api.Filters.Models;
using stottle_shop_api.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace stottle_shop_api.Data.TestData
{
    public static class TestProductData
    {
        public static IEnumerable<Product> GetProducts(int maxProducts) => Enumerable
                .Range(0, maxProducts)
                .Select(count => new Product
                {
                    Id = count.ToString(),
                    DisplayName = $"Product {count}",
                    Price = count * 2.99,
                    Order = new Random().Next(),
                    IsActive = true,
                    ImageLinks = Enumerable.Range(0, 2).Select(imgCount => imgCount).ToDictionary(key => key.ToString(), val => $"img{val}"),
                    Category = count.GetCategory(),
                    Filters = count.GetFilters().ToList()
                })
                .OrderBy(p => p.Id);

        private static Category GetCategory(this int count)
        {
            var catCode = count % 3 == 1 ? "123" : "321";
            return new Category
            {
                DisplayName = $"Category {catCode}",
                Code = catCode
            };
        }

        private static IEnumerable<FilterItem> GetFilters(this int count)
        {
            var filterCode = count % 4 == 1 ? "123" : "321";

            return Enumerable
                .Range(0, 5)
                .Select(filCount => new FilterItem
                {
                    Code = $"{filterCode}{filCount}",
                    DisplayName = $"filter {filCount}"
                });
        }
    }
}
