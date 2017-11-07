using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Products.Models;
using stottle_shop_api.Products.Repositories;

namespace stottle_shop_api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IReadProducts _productReader;

        public ProductsController(IReadProducts productReader)
        {
            _productReader = productReader;
        }

        [HttpGet]
        public async Task<IActionResult> Get(ProductFilterCriteria productFilter)
        {
            var countLimited = productFilter.Limit > 1000 || productFilter.Limit == 0 ? 1000: productFilter.Limit;
            productFilter.Limit = countLimited;

            var products = await _productReader.ReadAsync(productFilter).ConfigureAwait(false);
            if (!products.Any()) 
            {
                return NoContent();
            }
            return Ok(products);
        }
    }
}
