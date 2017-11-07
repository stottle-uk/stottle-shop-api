using System.Net;
using Newtonsoft.Json;
using stottle_shop_api.Products.Models;
using tests.Context;
using tests.Extensions;
using Xunit;

namespace tests.Server
{
    public class Products : IClassFixture<MyTestingFixture>
    {
        private readonly MyTestingFixture _fixture;

        public Products(MyTestingFixture fixture)
        {
            _fixture = fixture
                .Given_the_products_collection_is_empty()
                .Given_the_products_collection_has_products();
        }

        [Theory]
        [InlineData(1, 0, HttpStatusCode.NoContent)]
        [InlineData(2, 1000, HttpStatusCode.OK)]
        [InlineData(3, 500, HttpStatusCode.OK)]
        public void Should_return_products_using_search_criteria(int criteriaSet, int productCount, HttpStatusCode expectedHttpStatusCode)
        {
            var lastHttpResponse = _fixture.When_products_endpoint_called_with_search_criteria(criteriaSet);
            Assert.Equal(expectedHttpStatusCode, lastHttpResponse.StatusCode);

            var responseString = lastHttpResponse.Content.ReadAsStringAsync().Result;
            if (!string.IsNullOrWhiteSpace(responseString))
            {
                var deserialisedProducts = JsonConvert.DeserializeObject<Product[]>(responseString);
                Assert.Equal(productCount, deserialisedProducts.Length);
            }
        }
    }
}