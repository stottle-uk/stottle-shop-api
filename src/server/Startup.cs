using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stottle_shop_api.Categories;
using stottle_shop_api.Products;

namespace stottle_shop_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "mongodb://192.168.1.72:27017/stottle-shop";

            services.AddMvc();
            services.AddCors();
            services.AddProductsModule(connectionString);
            services.AddCategoriesModule(connectionString);
            services.AddFiltersModule(connectionString);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseCors(builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                        );
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
