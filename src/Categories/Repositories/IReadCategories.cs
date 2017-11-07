using System.Collections.Generic;
using System.Threading.Tasks;
using stottle_shop_api.Categories.Models;

namespace stottle_shop_api.Categories.Repositories
{
    public interface IReadCategories
    {
        Task<IEnumerable<Category>> ReadAsync();
    }
}

