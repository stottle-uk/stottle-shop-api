using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using stottle_shop_api.Categories.Models;

namespace stottle_shop_api.Categories.Repositories
{
    public class MongoRepository : IReadCategories
    {
        private readonly IMongoCollection<Category> _collection;

        public MongoRepository()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("stottle-products");

            _collection = db.GetCollection<Category>("categories");
        }

        public async Task<IEnumerable<Category>> ReadAsync()
        {
            return await _collection
                .Find(c => c.IsActive)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
