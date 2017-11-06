using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using stottle_shop_api;
using stottle_shop_api.Categories;
using Xunit;

namespace tests.Server
{
    public class Categories
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public Categories()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void Should_return_category_by_id()
        {
            var response = await _client.GetAsync("/api/category/1");
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();

            var categories = JsonConvert.DeserializeObject<Category[]>(responseString);

            Assert.Equal(categories.Length, 8);
        }

        [Fact]
        public async void Should_return_404_when_category_is_not_found()
        {
            var response = await _client.GetAsync("/api/category/notfound");
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }
    }
}