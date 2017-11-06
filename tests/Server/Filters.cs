using System;
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
using tests.Extensions;
using Xunit;

namespace tests.Server
{
    public class Filters
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public Filters()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void Should_return_filters_by_id()
        {
            var response = await _client.GetAsync($"/api/filters/1,2,3");

            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();

            var filters = JsonConvert.DeserializeObject<Filter[]>(responseString);

            Assert.Equal(filters.Length, 2);
        }

        [Fact]
        public async void Should_return_404_when_filters_are_not_found()
        {
            var response = await _client.GetAsync("/api/filters/notfound");
            Assert.Equal(response.StatusCode, HttpStatusCode.NotFound);
        }
    }

}