using System.Linq;
using System.Net.Http;
using MongoDB.Driver;
using stottle_shop_api.Categories.Models;
using tests.Context;

namespace tests.Extensions
{
    public static class CategoryTestingFixtureExtensions
    {
        public static CategoryTestingFixture Given_the_categories_collection_is_empty(this CategoryTestingFixture fixture)
        {
            var filter = Builders<Category>.Filter
                .Where(p => p.DisplayName != "");

            fixture.CategoryCollection.DeleteMany(filter);
            return fixture;
        }

        public static CategoryTestingFixture Given_the_categories_collection_has_categories(this CategoryTestingFixture fixture, int maxCategories)
        {
            var categories = Enumerable
                .Range(0, 8)
                .Select(count => new Category
                {
                    Id = count.ToString(),
                    Code = $"cat{count}",
                    DisplayName = $"Cat {count}",
                    IsActive = true,
                    ChildCategories = Enumerable.Range(0, 5).Select(childCount => new Category
                    {
                        Code = $"cat{childCount}",
                        DisplayName = $"Child {childCount}",
                        IsActive = true,
                        Filters = Enumerable.Range(0, 3).Select(filCount => $"fil{filCount}"),
                    })
                });

            fixture.CategoryCollection.InsertMany(categories);
            return fixture;
        }

        public static HttpResponseMessage When_categories_endpoint_called(this CategoryTestingFixture fixture)
        {
            return fixture.HttpClient.GetAsync($"/api/category").Result;
        }
    }
}