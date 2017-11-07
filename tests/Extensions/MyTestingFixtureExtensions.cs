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
    public static class MyTestingFixtureExtensions
    {
        public static MyTestingFixture Given_the_products_collection_is_empty(this MyTestingFixture fixture)
        {
            var filter = Builders<Product>.Filter
                .Where(p => p.DisplayName != "");

            fixture.ProductsCollection.DeleteMany(filter);
            return fixture;
        }

        public static MyTestingFixture Given_the_products_collection_has_products(this MyTestingFixture fixture)
        {
            var products = Enumerable
                .Range(0, 1000)
                .Select(count => new Product
                {
                    Id = count.ToString(),
                    DisplayName = $"Product {count}",
                    Price = count * 2.99,
                    Order = new Random().Next(),
                    ImageLinks = Enumerable.Range(0, 2).Select(imgCount => imgCount).ToDictionary(key => key.ToString(), val => $"img{val}"),
                    Category = count.GetCategory(),
                    Filters = count.GetFilters().ToList()
                });

            fixture.ProductsCollection.InsertMany(products);
            return fixture;
        }

        public static HttpResponseMessage When_products_endpoint_called_with_search_criteria(this MyTestingFixture fixture, int criteriaSet)
        {
            var criteriaAsQueryString = criteriaSet
                .GetProductFilterCriteria()
                .ToQueryString();

            return fixture.HttpClient.GetAsync($"/api/products/?{criteriaAsQueryString}").Result;
        }

        private static ProductFilterCriteria GetProductFilterCriteria(this int criteriaSet)
        {
            if (criteriaSet == 1)
            {
                return new ProductFilterCriteria
                {
                    Category = "",
                    Filters = "",
                    SearchTerm = "this term will not find any products"
                };
            }

            if (criteriaSet == 2)
            {
                return new ProductFilterCriteria
                {
                    Category = "",
                    Filters = "",
                    SearchTerm = "product"
                };
            }

            return new ProductFilterCriteria
            {
                Category = "123",
                Filters = "",
                SearchTerm = ""
            };

        }

        private static Category GetCategory(this int count)
        {
            var catCode = count % 2 == 1 ? "123" : "321";
            return new Category
            {
                DisplayName = $"Category {catCode}",
                Code = catCode
            };
        }

        private static IEnumerable<FilterItem> GetFilters(this int count)
        {
            return Enumerable
                .Range(0, 5)
                .Select(filCount => new FilterItem
                {
                    Code = $"{filCount}",
                    DisplayName = $"filter {filCount}"
                });
        }

    }
}