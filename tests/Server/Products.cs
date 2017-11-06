using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using stottle_shop_api;
using stottle_shop_api.Categories;
using stottle_shop_api.Filters;
using stottle_shop_api.Models.Products;
using tests.Extensions;
using Xunit;

namespace tests.Server
{
    public class Products
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public Products()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void Should_return_products_using_search_criteria()
        {
            var criteria = new ProductFilterCriteria
            {
                Category = "CatId",
                Filters = "1,2,3",
                SearchTerm = "A term"
            }.ToQueryString();

            var response = await _client.GetAsync($"/api/products/?{criteria}");
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<Product[]>(responseString);

            Assert.Equal(products.Length, 24);
        }

        [Fact]
        public async void Should_return_204_when_no_products_are_found_by_search_criteria()
        {
            var criteria = new ProductFilterCriteria
            {
                Category = "CatId",
                Filters = "1,2,3",
                SearchTerm = "No products"
            }.ToQueryString();

            var response = await _client.GetAsync($"/api/products/?{criteria}");
            Assert.Equal(response.StatusCode, HttpStatusCode.NoContent);
        }
    }



}