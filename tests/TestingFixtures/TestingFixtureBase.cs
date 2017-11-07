using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Driver;
using stottle_shop_api;

namespace tests.TestingFixtures
{
    public abstract class TestingFixtureBase<T> : IDisposable
    {
        private readonly TestServer _server;
        public IMongoCollection<T> Collection { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public TestingFixtureBase(string collectionName)
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            SetupHttpClient();
            SetupCollection(collectionName);
        }

        private void SetupCollection(string collectionName)
        {
            var mongoUrl = new MongoUrl("mongodb://192.168.1.72:27017/stottle-shop");
            var client = new MongoClient(mongoUrl);
            var db = client.GetDatabase(mongoUrl.DatabaseName);
            db.DropCollection(collectionName);
            Collection = db.GetCollection<T>(collectionName);
        }

        private void SetupHttpClient()
        {
            HttpClient = _server.CreateClient();
        }

        public void Dispose()
        {
            _server.Dispose();
        }
    }
}