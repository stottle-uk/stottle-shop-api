using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using stottle_shop_api.Shop.Repositories;

namespace stottle_shop_api.Shop
{
    public static class ShopModule
    {
        public static void AddShopModule(this IServiceCollection services, string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            services.AddTransient(ctx => new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName));
            services.AddTransient<IReadShops, MongoRepository>();
            services.AddTransient<IWriteShops, MongoRepository>();
        }
    }
}
