using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Categories;

namespace stottle_shop_api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (id == "notfound")
            {
                return NotFound();
            }
            var categories = Enumerable
                .Range(0, 8)
                .Select(count => new Category
                {
                    Code = $"cat{count}",
                    DisplayName = $"Cat {count}",
                    ChildCategories = Enumerable.Range(0, 5).Select(childCount => new Category
                    {
                        Code = $"cat{childCount}",
                        DisplayName = $"Child {childCount}",
                    })
                });

            return Ok(categories);
        }
    }
}
