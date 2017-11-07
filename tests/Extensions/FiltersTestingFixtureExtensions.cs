using System.Linq;
using System.Net.Http;
using MongoDB.Driver;
using stottle_shop_api.Filters.Models;
using tests.TestingFixtures;

namespace tests.Extensions
{
    public static class FiltersTestingFixtureExtensions
    {
        public static FiltersTestingFixture Given_the_filters_collection_is_empty(this FiltersTestingFixture fixture)
        {
            var filter = Builders<Filter>.Filter
                .Where(p => p.DisplayName != "");

            fixture.FiltersCollection.DeleteMany(filter);
            return fixture;
        }

        public static FiltersTestingFixture Given_the_filters_collection_has_filters(this FiltersTestingFixture fixture, int maxFilters)
        {
            var items = Enumerable.Range(0, 10).Select(count => new FilterItem
            {
                DisplayName = $"Item {count}",
                Code = $"Item{count}"
            });

            var filters = Enumerable
                .Range(0, maxFilters)
                .Select(count => new Filter
                {
                    Id = count.ToString(),
                    Code = $"fil{count}",
                    DisplayName = $"Filter {count}",
                    IsActive = true,
                    Items = items
                });

            fixture.FiltersCollection.InsertMany(filters);
            return fixture;
        }

        public static HttpResponseMessage When_filters_endpoint_called(this FiltersTestingFixture fixture)
        {
            return fixture.HttpClient.GetAsync($"/api/filters/fil1,fil2,fil3").Result;
        }
    }
}