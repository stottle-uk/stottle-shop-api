using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using stottle_shop_api.Categories.Repositories;

namespace stottle_shop_api.Categories
{
    public static class CategoriesModule
    {
        public static void AddCategoriesModule(this IServiceCollection services, string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            services.AddTransient(ctx => new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName));
            services.AddTransient<IReadCategories, MongoRepository>();
            services.AddTransient<IWriteCategories, MongoRepository>();
        }
    }
}
