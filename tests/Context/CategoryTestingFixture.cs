using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Driver;
using stottle_shop_api;
using stottle_shop_api.Categories.Models;

namespace tests.Context
{
    public class CategoryTestingFixture : IDisposable
    {
        private readonly MongoClient _mongoClient;
        private readonly TestServer _server;
        public IMongoCollection<Category> CategoryCollection { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public CategoryTestingFixture()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            SetupHttpClient();

            _mongoClient = new MongoClient();
            SetupProductsCollection();
        }

        private void SetupProductsCollection()
        {
            var db = _mongoClient.GetDatabase("stottle-products");
            db.DropCollection("categories");
            CategoryCollection = db.GetCollection<Category>("categories");
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