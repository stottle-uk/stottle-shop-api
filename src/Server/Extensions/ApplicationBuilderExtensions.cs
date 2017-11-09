using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using stottle_shop_api.Categories.Data;
using stottle_shop_api.Categories.Repositories;
using stottle_shop_api.Filters.Data;
using stottle_shop_api.Filters.Repositories;
using stottle_shop_api.Products.Data;
using stottle_shop_api.Products.Repositories;

namespace stottle_shop_api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTestData(this IApplicationBuilder builder)
        {
            var productsRepo = builder.ApplicationServices.GetRequiredService<IWriteProducts>();
            productsRepo.InsertAsync(TestProductData.GetProducts(2000));

            var filterRepo = builder.ApplicationServices.GetRequiredService<IWriteFilters>();
            filterRepo.InsertAsync(TestFilterData.GetFilter(4));

            var categoryRepo = builder.ApplicationServices.GetRequiredService<IWriteCategories>();
            categoryRepo.InsertAsync(TestCategoryData.GetCategories());
            return builder;
        }
    }
}