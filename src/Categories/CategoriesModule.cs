using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using stottle_shop_api.Categories.Repositories;

namespace stottle_shop_api.Categories
{
    public static class ProductsModule
    {
        public static void AddCategoriesModule(this IServiceCollection services, string connectionString, string databaseName)
        {
            services.AddTransient<IMongoDatabase>(ctx => new MongoClient(connectionString).GetDatabase(databaseName));
            services.AddTransient<IReadCategories, MongoRepository>();
        }
    }
}
