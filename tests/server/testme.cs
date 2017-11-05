using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using stottle_shop_api;
using Xunit;

namespace tests.server
{
    public class testme
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public testme()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void TestName()
        {
            // Act
            var response = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("value",
                responseString);
        }

    }
}