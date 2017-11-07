using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Categories;
using stottle_shop_api.Filters;
using stottle_shop_api.Products;
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

        // GET api/values/5
        [HttpGet]
        public async Task<IActionResult> Get(ProductFilterCriteria productFilter)
        {
            var products = await _productReader.ReadAsync(productFilter).ConfigureAwait(false);
            if (!products.Any()) 
            {
                return NoContent();
            }
            return Ok(products);
        }
    }
}
