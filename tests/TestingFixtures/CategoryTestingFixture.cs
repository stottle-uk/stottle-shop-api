using MongoDB.Driver;
using stottle_shop_api.Categories.Models;

namespace tests.TestingFixtures
{
    public class CategoryTestingFixture : TestingFixtureBase
    {
        private readonly string _collectionName = "categories";
        public IMongoCollection<Category> Collection { get; private set; }

        public CategoryTestingFixture()
        {
            Database.DropCollection(_collectionName);
            Collection = Database.GetCollection<Category>(_collectionName);
        }

        public override void Dispose()
        {
            Database.DropCollection(_collectionName);
            Server.Dispose();
        }
    }
}