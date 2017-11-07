using System.Collections.Generic;
using System.Threading.Tasks;
using stottle_shop_api.Products.Models;

namespace stottle_shop_api.Products.Repositories
{
    public interface IReadProducts
    {
        Task<IEnumerable<Product>> ReadAsync(ProductFilterCriteria searchCriteria);
    }
}

