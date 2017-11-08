using MongoDB.Driver;
using stottle_shop_api.Categories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Categories.Repositories
{
    public class MongoRepository : IReadCategories
    {
        private readonly IMongoCollection<Category> _collection;

        public MongoRepository(IMongoDatabase db)
        {
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
