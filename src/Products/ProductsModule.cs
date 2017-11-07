using Microsoft.Extensions.DependencyInjection;
using stottle_shop_api.Products.Repositories;

namespace stottle_shop_api.Products
{
    public static class ProductsModule
    {
        public static void AddProductsModule(this IServiceCollection services)
        {
            services.AddTransient<IReadProducts, MongoRepository>();
        }
    }
}
