using Newtonsoft.Json;
using stottle_shop_api.Filters.Models;
using System.Net;
using tests.Extensions;
using tests.TestingFixtures;
using Xunit;

namespace tests.Server
{
    public class Filters : IClassFixture<FiltersTestingFixture>
    {
        private readonly FiltersTestingFixture _fixture;

        public Filters(FiltersTestingFixture fixture)
        {
            _fixture = fixture
                .Given_the_filters_collection_is_empty();
        }
        
        [Fact]
        public void Should_return_204_when_filters_are_not_found()
        {
            var httpResponse = _fixture
                .When_filters_endpoint_called();

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
        }

        [Fact]
        public void Should_return_filters_by_id()
        {
            var httpResponse = _fixture
                .Given_the_filters_collection_has_filters(4)
                .When_filters_endpoint_called();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

            var responseString = httpResponse.Content.ReadAsStringAsync().Result;

            var filters = JsonConvert.DeserializeObject<Filter[]>(responseString);

            Assert.Equal(3, filters.Length);
        }

    }

}