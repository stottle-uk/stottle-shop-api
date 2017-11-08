using stottle_shop_api.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Products.Repositories
{
    public interface IWriteProducts
    {
        Task InsertAsync(IEnumerable<Product> products);
    }
}
