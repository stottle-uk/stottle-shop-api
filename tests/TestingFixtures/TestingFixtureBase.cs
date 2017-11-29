using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MongoDB.Driver;
using stottle_shop_api;
using System;
using System.Net.Http;
using IdentityModel.Client;

namespace tests.TestingFixtures
{
    public abstract class TestingFixtureBase : IDisposable
    {
        public TestServer Server { get; private set; }
        public HttpClient HttpClient { get; private set; }
        public IMongoDatabase Database { get; private set; }
        public TokenClient TokenClient { get; private set; }

        public TestingFixtureBase()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING") ?? GetAndSetEnv();
            SetupDatabase(connectionString);
            SetupHttpClient();
            SetupTokenClient();
        }

        private string GetAndSetEnv()
        {
            var connectionString = "mongodb://localhost:27017/stottle-shop";
            Environment.SetEnvironmentVariable("MONGO_CONNECTION_STRING", connectionString);
            return connectionString;
        }

        private void SetupDatabase(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            Database = client.GetDatabase(mongoUrl.DatabaseName);
        }

        private void SetupHttpClient()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            HttpClient = Server.CreateClient();
        }

        private void SetupTokenClient()
        {
            var disco = DiscoveryClient.GetAsync("http://localhost:63084").Result;
            TokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
        }

        public abstract void Dispose();
    }
}