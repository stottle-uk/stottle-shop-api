using Microsoft.Extensions.DependencyInjection;
using stottle_shop_api.Filters.Repositories;

namespace stottle_shop_api.Categories
{
    public static class ProductsModule
    {
        public static void AddFiltersModule(this IServiceCollection services)
        {
            services.AddTransient<IReadFilters, MongoRepository>();
        }
    }
}
