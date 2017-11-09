using MongoDB.Driver;
using stottle_shop_api.Products.Models;

namespace tests.TestingFixtures
{
    public class ProductsTestingFixture : TestingFixtureBase
    {
        private readonly string _collectionName = "products";
        public IMongoCollection<Product> Collection { get; private set; }

        public ProductsTestingFixture()
        {
            Database.DropCollection(_collectionName);
            Collection = Database.GetCollection<Product>(_collectionName);
        }

        public override void Dispose()
        {
            Database.DropCollection(_collectionName);
            Server.Dispose();
        }
    }
}