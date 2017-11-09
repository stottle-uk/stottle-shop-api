using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Driver;
using stottle_shop_api;
using System;
using System.Net.Http;

namespace tests.TestingFixtures
{
    public abstract class TestingFixtureBase : IDisposable
    {
        public TestServer Server { get; private set; }
        public HttpClient HttpClient { get; private set; }
        public IMongoDatabase Database { get; private set; }

        public TestingFixtureBase()
        {
            SetupHttpClient();
            SetupDatabase();
        }

        private void SetupDatabase()
        {
            var mongoUrl = new MongoUrl("mongodb://localhost:27017/stottle-shop");
            var client = new MongoClient(mongoUrl);
            Database = client.GetDatabase(mongoUrl.DatabaseName);
        }

        private void SetupHttpClient()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            HttpClient = Server.CreateClient();
        }

        public abstract void Dispose();
    }
}