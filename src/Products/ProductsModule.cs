using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using stottle_shop_api.Products.Repositories;

namespace stottle_shop_api.Products
{
    public static class ProductsModule
    {
        public static void AddProductsModule(this IServiceCollection services, string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            services.AddTransient(ctx => new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName));
            services.AddTransient<IReadProducts, MongoRepository>();
            services.AddTransient<IWriteProducts, MongoRepository>();
        }
    }
}
