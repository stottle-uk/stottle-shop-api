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
            SetupDatabase();
            SetupHttpClient();
            SetupTokenClient();
        }

        private void SetupDatabase()
        {
            var connectionString = GetOrSetEnvVar("MONGO_CONNECTION_STRING", "mongodb://localhost:27017/stottle-shop");
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            Database = client.GetDatabase(mongoUrl.DatabaseName);
        }

        private void SetupHttpClient()
        {
            var webhost = new WebHostBuilder()
                .UseStartup<Startup>();

            Server = new TestServer(webhost);
            HttpClient = Server.CreateClient();
        }

        private void SetupTokenClient()
        {
            GetOrSetEnvVar("IDENTITY_SERVER_AUDIENCE", "http://localhost:5000/resources");
            GetOrSetEnvVar("IDENTITY_SERVER_REQUIREHTTPSMETADATA", "false");
            var identityServerUri = GetOrSetEnvVar("IDENTITY_SERVER_AUTHORITY", "http://localhost:5000");
            var disco = DiscoveryClient.GetAsync(identityServerUri).Result;
            TokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
        }

        private string GetOrSetEnvVar(string key, string defaultValue)
        {
            var envVar = Environment.GetEnvironmentVariable(key);
            if (envVar == null)
            {
                Environment.SetEnvironmentVariable(key, defaultValue);
                return Environment.GetEnvironmentVariable(key);
            }
            return envVar;
        }

        public abstract void Dispose();
    }
}