using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using stottle_shop_api.Filters.Models;

namespace stottle_shop_api.Filters.Repositories
{
    public class MongoRepository : IReadFilters
    {
        private readonly IMongoCollection<Filter> _collection;

        public MongoRepository()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("stottle-products");

            _collection = db.GetCollection<Filter>("filters");
        }

        public async Task<IEnumerable<Filter>> ReadAsync(IEnumerable<string> filterIds)
        {
            var filter = Builders<Filter>.Filter.Eq(p => p.IsActive, true)
                & Builders<Filter>.Filter.Where(p => filterIds.Contains(p.Code));

            return await _collection
                .Find(filter)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
