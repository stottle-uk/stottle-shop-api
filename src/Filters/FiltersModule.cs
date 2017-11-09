using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using stottle_shop_api.Filters.Repositories;

namespace stottle_shop_api.Filters
{
    public static class FiltersModule
    {
        public static void AddFiltersModule(this IServiceCollection services, string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            services.AddTransient(ctx => new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName));            
            services.AddTransient<IReadFilters, MongoRepository>();
        }
    }
}
