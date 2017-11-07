using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using stottle_shop_api.Products.Repositories;

namespace stottle_shop_api.Products
{
    public static class ProductsModule
    {
        public static void AddProductsModule(this IServiceCollection services, string connectionString, string databaseName)
        {
            services.AddTransient<IMongoDatabase>(ctx => new MongoClient(connectionString).GetDatabase(databaseName));
            services.AddTransient<IReadProducts, MongoRepository>();
        }
    }
}
