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

            var products = Enumerable
                .Range(0, 24)
                .Select(count => new Product
                {
                    Id = count.ToString(),
                    DisplayName = $"Product {productFilter.SearchTerm} {count}",
                    Price = count * 2.99,
                    Order = new Random().Next(),
                    ImageLinks = Enumerable.Range(0, 2).Select(imgCount => imgCount).ToDictionary(key => key, val => $"img{val}"),
                    Categories = new Category
                    {
                        Code = productFilter.Category,
                        DisplaName = $"Cat Name {productFilter.Category}"
                    },
                    Filters = productFilter.Filters.Split(',').Select(filterId => new FilterItem
                    {
                        Code = filterId,
                        DisplaName = $"filter {filterId}"
                    })
                });
            return Ok(products);
        }
    }
}
