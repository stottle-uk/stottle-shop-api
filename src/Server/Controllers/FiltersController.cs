using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Filters;
using stottle_shop_api.Filters.Repositories;

namespace stottle_shop_api.Controllers
{
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        private readonly IReadFilters _filterReader;

        public FiltersController(IReadFilters filterReader)
        {
            _filterReader = filterReader ?? throw new System.ArgumentNullException(nameof(filterReader));
        }

        // GET api/values/5
        [HttpGet("{ids}")]
        public async Task<IActionResult> Get(string ids)
        {
            var filterIds = ids.Split(',');
            var filters = await _filterReader.ReadAsync(filterIds);
            if (!filters.Any())
            {
                return NoContent();
            }
            return Ok(filters);
        }
    }
}
