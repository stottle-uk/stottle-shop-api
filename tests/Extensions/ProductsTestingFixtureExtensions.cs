using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MongoDB.Driver;
using stottle_shop_api.Categories;
using stottle_shop_api.Filters;
using stottle_shop_api.Products.Models;
using tests.Context;

namespace tests.Extensions
{
    public static class ProductsTestingFixtureExtensions
    {
        public static ProductsTestingFixture Given_the_products_collection_is_empty(this ProductsTestingFixture fixture)
        {
            var filter = Builders<Product>.Filter
                .Where(p => p.DisplayName != "");

            fixture.ProductsCollection.DeleteMany(filter);
            return fixture;
        }

        public static ProductsTestingFixture Given_the_products_collection_has_products(this ProductsTestingFixture fixture)
        {
            var products = Enumerable
                .Range(0, 1000)
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
                });

            fixture.ProductsCollection.InsertMany(products);
            return fixture;
        }

        public static HttpResponseMessage When_products_endpoint_called_with_search_criteria(this ProductsTestingFixture fixture, int criteriaSet)
        {
            var criteriaAsQueryString = criteriaSet
                .GetProductFilterCriteria()
                .ToQueryString();

            return fixture.HttpClient.GetAsync($"/api/products/?{criteriaAsQueryString}").Result;
        }

        private static ProductFilterCriteria GetProductFilterCriteria(this int criteriaSet)
        {
            var sets = new Dictionary<int, ProductFilterCriteria>();

            sets.Add(1, new ProductFilterCriteria
            {
                Category = "",
                Filters = "",
                SearchTerm = "this term will not find any products"
            });

            sets.Add(2, new ProductFilterCriteria
            {
                Category = "",
                Filters = "",
                SearchTerm = "product 1"
            });

            sets.Add(3, new ProductFilterCriteria
            {
                Category = "123",
                Filters = "",
                SearchTerm = ""
            });

            sets.Add(4, new ProductFilterCriteria
            {
                Category = "",
                Filters = "1231,1232",
                SearchTerm = ""
            });

            sets.Add(5, new ProductFilterCriteria
            {
                Category = "321",
                Filters = "1231,1232",
                SearchTerm = ""
            });

            sets.Add(6, new ProductFilterCriteria
            {
                Category = "321",
                Filters = "1231,1232",
                SearchTerm = "product 1"
            });

            sets.Add(7, new ProductFilterCriteria
            {
                Category = "",
                Filters = "",
                SearchTerm = ""
            });

            return sets.First(s => s.Key == criteriaSet).Value;
        }

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