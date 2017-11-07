using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using stottle_shop_api.Products.Extensions;
using stottle_shop_api.Products.Models;

namespace stottle_shop_api.Products.Repositories
{
    public class MongoRepository : IReadProducts
    {
        private readonly IMongoCollection<Product> _collection;

        public MongoRepository()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("stottle-products");

            _collection = db.GetCollection<Product>("products");
        }

        public async Task<IEnumerable<Product>> ReadAsync(ProductFilterCriteria searchCriteria)
        {
            var filter = searchCriteria.CreateFilter()
        ;
            return await _collection
                .Find(filter)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
