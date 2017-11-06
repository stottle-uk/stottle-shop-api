using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Categories;
using stottle_shop_api.Filters;
using stottle_shop_api.Models.Products;

namespace stottle_shop_api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // GET api/values/5
        [HttpGet]
        public IActionResult Get(ProductFilterCriteria productFilter)
        {
            if (productFilter.SearchTerm == "No products")
            {
                return NoContent();
            }

            var filters = productFilter.Filters ?? "1,2";

            var products = Enumerable
                .Range(0, 24)
                .Select(count => new Product
                {
                    Id = count.ToString(),
                    DisplayName = $"Product {productFilter.SearchTerm} {count}",
                    Price = count * 2.99,
                    Order = new Random().Next(),
                    ImageLinks = Enumerable.Range(0, 2).Select(imgCount => imgCount).ToDictionary(key => key, val => $"img{val}"),
                    Category = new Category
                    {
                        Code = productFilter.Category,
                        DisplayName = $"Cat Name {productFilter.Category}"
                    },
                    Filters = filters.Split(',').Select(filterId => new FilterItem
                    {
                        Code = filterId,
                        DisplayName = $"filter {filterId}"
                    })
                });
            return Ok(products);
        }
    }
}
