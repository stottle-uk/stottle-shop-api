using Newtonsoft.Json;
using stottle_shop_api.Categories.Models;
using System.Net;
using tests.Extensions;
using tests.TestingFixtures;
using Xunit;

namespace tests.Server
{
    public class Categories : IClassFixture<CategoryTestingFixture>
    {
        private readonly CategoryTestingFixture _fixture;

        public Categories(CategoryTestingFixture fixture)
        {
            _fixture = fixture
                .Given_the_categories_collection_is_empty();
        }

        [Fact]
        public void Should_return_categories()
        {
            var httpResponse = _fixture
                .Given_the_categories_collection_has_categories(8)
                .When_categories_endpoint_called();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

            var responseString = httpResponse.Content.ReadAsStringAsync().Result;
            var categories = JsonConvert.DeserializeObject<Category[]>(responseString);

            Assert.Equal(8, categories.Length);
        }

        [Fact]
        public void Should_return_204_when_categories_are_not_found()
        {
            var httpResponse = _fixture
                .When_categories_endpoint_called();

            Assert.Equal(HttpStatusCode.NoContent, httpResponse.StatusCode);
        }
    }
}