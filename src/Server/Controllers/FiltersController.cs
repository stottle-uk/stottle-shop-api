using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Filters;

namespace stottle_shop_api.Controllers
{
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        // GET api/values/5
        [HttpGet("{ids}")]
        public IActionResult Get(string ids)
        {
            if (ids.Split(',').First() == "notfound")
            {
                return NotFound();
            }

            var items = Enumerable.Range(0, 10).Select(count => new FilterItem
            {
                DisplaName = $"Item {count}",
                Code = $"Item{count}"
            });

            var filter = Enumerable
                .Range(0, 2)
                .Select(count => new Filter
                {
                    Code = $"Filter{count}",
                    DisplayName = $"Filter {count}",
                    Items = items
                });

            return Ok(filter);
        }
    }
}
