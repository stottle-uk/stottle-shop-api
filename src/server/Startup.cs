using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stottle_shop_api.Categories;
using stottle_shop_api.Extensions;
using stottle_shop_api.Filters;
using stottle_shop_api.Products;
using stottle_shop_api.Shop;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

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
            var connectionString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");

            services.AddMvc();

            services
                .AddCors()
                .AddAuthentication(GetAuthenicationOptions)
                .AddJwtBearer(GetJwtBearerOptions);

            services.AddShopModule(connectionString);
            services.AddProductsModule(connectionString);
            services.AddCategoriesModule(connectionString);
            services.AddFiltersModule(connectionString);
        }

        private static void GetAuthenicationOptions(AuthenticationOptions options)
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }

        private static void GetJwtBearerOptions(JwtBearerOptions options)
        {
            options.Authority = Environment.GetEnvironmentVariable("IDENTITY_SERVER_AUTHORITY");
            options.Audience = Environment.GetEnvironmentVariable("IDENTITY_SERVER_AUDIENCE");
            options.RequireHttpsMetadata = bool.Parse(Environment.GetEnvironmentVariable("IDENTITY_SERVER_REQUIREHTTPSMETADATA"));
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

            // if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("USE_TEST_DATA")))
            // {
            //     app.UseTestData();
            // };

            app
                .UseAuthentication()
                .UseMvcWithDefaultRoute();
        }
    }
}

        /* 
        1. create an identity server 4 which is used just for testing (in a container) - https://github.com/IdentityServer/IdentityServer4.Samples/tree/release/Docker - https://github.com/mtranter/IdentityServer4.Mock - https://github.com/emedbo/identityserver-test-template
            a. use config whoch changes depending on environment with address of authentication server (mocked or real) 
        2. get a new token for each test using the credentials of a user with certain claims
        3. Decorate each controller with a customer authorize attribute that doesn't check the bearer token for tests
         */
