using stottle_shop_api.Products.Models;

namespace tests.TestingFixtures
{
    public class ProductsTestingFixture : TestingFixtureBase<Product>
    {
        public ProductsTestingFixture() : base("products")
        {

        }
    }
}