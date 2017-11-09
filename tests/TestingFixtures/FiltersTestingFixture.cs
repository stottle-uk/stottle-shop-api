using MongoDB.Driver;
using stottle_shop_api.Filters.Models;

namespace tests.TestingFixtures
{
    public class FiltersTestingFixture : TestingFixtureBase
    {
        private readonly string _collectionName = "filters";
        public IMongoCollection<Filter> Collection { get; private set; }

        public FiltersTestingFixture()
        {
            Database.DropCollection(_collectionName);
            Collection = Database.GetCollection<Filter>(_collectionName);
        }

        public override void Dispose()
        {
            Database.DropCollection(_collectionName);
            Server.Dispose();
        }
    }
}