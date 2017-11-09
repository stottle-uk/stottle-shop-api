using MongoDB.Driver;
using stottle_shop_api.Filters.Data;
using stottle_shop_api.Filters.Models;
using System.Net.Http;
using tests.TestingFixtures;

namespace tests.Extensions
{
    public static class FiltersTestingFixtureExtensions
    {
        public static FiltersTestingFixture Given_the_filters_collection_is_empty(this FiltersTestingFixture fixture)
        {
            var filter = Builders<Filter>.Filter
                .Where(p => p.DisplayName != "");

            fixture.Collection.DeleteMany(filter);
            return fixture;
        }

        public static FiltersTestingFixture Given_the_filters_collection_has_filters(this FiltersTestingFixture fixture, int maxFilters)
        {
            var filters = TestFilterData.GetFilter(maxFilters);

            fixture.Collection.InsertMany(filters);
            return fixture;
        }

        public static HttpResponseMessage When_filters_endpoint_called(this FiltersTestingFixture fixture)
        {
            return fixture.HttpClient.GetAsync($"/api/filters/filter1,filter2,filter3").Result;
        }
    }
}