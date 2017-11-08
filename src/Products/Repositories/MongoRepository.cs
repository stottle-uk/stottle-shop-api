using MongoDB.Driver;
using stottle_shop_api.Products.Extensions;
using stottle_shop_api.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Products.Repositories
{
    public class MongoRepository : IReadProducts, IWriteProducts
    {
        private readonly IMongoCollection<Product> _collection;

        public MongoRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<Product>("products");
        }

        public async Task InsertAsync(IEnumerable<Product> products)
        {
            await _collection.InsertManyAsync(products);
        }

        public async Task<IEnumerable<Product>> ReadAsync(ProductFilterCriteria searchCriteria)
        {
            var filter = searchCriteria.CreateFilter();
            
            return await _collection
                .Find(filter)
                .Limit(searchCriteria.Limit)
                .Skip(searchCriteria.Skip)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
