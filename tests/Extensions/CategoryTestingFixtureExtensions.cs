using Data.TestData;
using MongoDB.Driver;
using stottle_shop_api.Categories.Models;
using System.Net.Http;
using tests.TestingFixtures;

namespace tests.Extensions
{
    public static class CategoryTestingFixtureExtensions
    {
        public static CategoryTestingFixture Given_the_categories_collection_is_empty(this CategoryTestingFixture fixture)
        {
            var filter = Builders<Category>.Filter
                .Where(p => p.DisplayName != "");

            fixture.Collection.DeleteMany(filter);
            return fixture;
        }

        public static CategoryTestingFixture Given_the_categories_collection_has_categories(this CategoryTestingFixture fixture, int maxCategories)
        {
            var categories = TestCategoryData.GetCategories();

            fixture.Collection.InsertMany(categories);
            return fixture;
        }

        public static HttpResponseMessage When_categories_endpoint_called(this CategoryTestingFixture fixture)
        {
            return fixture.HttpClient.GetAsync($"/api/category").Result;
        }
    }
}