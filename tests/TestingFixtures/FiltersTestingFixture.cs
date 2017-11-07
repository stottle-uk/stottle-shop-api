using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Driver;
using stottle_shop_api;
using stottle_shop_api.Filters.Models;

namespace tests.TestingFixtures
{
    public class FiltersTestingFixture : IDisposable
    {
        private readonly MongoClient _mongoClient;
        private readonly TestServer _server;
        public IMongoCollection<Filter> FiltersCollection { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public FiltersTestingFixture()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            SetupHttpClient();

            _mongoClient = new MongoClient("mongodb://192.168.1.72:27017");
            SetupFiltersCollection();
        }

        private void SetupFiltersCollection()
        {
            var db = _mongoClient.GetDatabase("stottle-shop");
            db.DropCollection("filters");
            FiltersCollection = db.GetCollection<Filter>("filters");
        }

        private void SetupHttpClient()
        {
            HttpClient = _server.CreateClient();
        }

        public void Dispose()
        {
            // _mongoClient.DropDatabase("stottle-products");
            _server.Dispose();
        }
    }
}