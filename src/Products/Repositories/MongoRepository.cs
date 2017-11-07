using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
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
            var filters = new List<FilterDefinition<Product>>();

            if (!string.IsNullOrWhiteSpace(searchCriteria.SearchTerm))
            {
                var filter = Builders<Product>.Filter.Where(p => p.DisplayName.ToLowerInvariant()
                    .Contains(searchCriteria.SearchTerm.ToLowerInvariant()));
                filters.Add(filter);
            }

            if (!string.IsNullOrWhiteSpace(searchCriteria.Category))
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Category.Code, searchCriteria.Category);
                filters.Add(filter);
            }

            var filterCombined = Builders<Product>.Filter.And(filters);

            return await _collection
                .Find(filterCombined)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
