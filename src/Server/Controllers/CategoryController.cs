using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stottle_shop_api.Categories.Repositories;

namespace stottle_shop_api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IReadCategories _categoryReader;

        public CategoryController(IReadCategories categoryReader)
        {
            _categoryReader = categoryReader ?? throw new System.ArgumentNullException(nameof(categoryReader));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryReader.ReadAsync();
            if (!categories.Any()) 
            {
                return NoContent();
            }
            return Ok(categories);
        }
    }
}
