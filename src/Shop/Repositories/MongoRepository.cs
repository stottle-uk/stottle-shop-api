using MongoDB.Driver;
using stottle_shop_api.Shop.Models;
using System.Threading.Tasks;

namespace stottle_shop_api.Shop.Repositories
{
    public class MongoRepository : IReadShops, IWriteShops
    {
        private readonly IMongoCollection<Store> _collection;

        public MongoRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<Store>("shop");
        }

        public async Task InsertAsync(Store store)
        {
            await _collection.InsertOneAsync(store);
        }

        public async Task<Store> ReadAsync(string id)
        {            
            var filter = Builders<Store>.Filter.Eq(p => p.Id, id);

            return await _collection
                .Find(filter)
                .SingleAsync()
                .ConfigureAwait(false);
        }
    }
}
