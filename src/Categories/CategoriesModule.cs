using Microsoft.Extensions.DependencyInjection;
using stottle_shop_api.Categories.Repositories;

namespace stottle_shop_api.Categories
{
    public static class ProductsModule
    {
        public static void AddCategoriesModule(this IServiceCollection services)
        {
            services.AddTransient<IReadCategories, MongoRepository>();
        }
    }
}
