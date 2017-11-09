using stottle_shop_api.Categories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Categories.Repositories
{
    public interface IWriteCategories
    {
        Task InsertAsync(IEnumerable<Category> categories);
    }
}

