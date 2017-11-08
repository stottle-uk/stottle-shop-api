using stottle_shop_api.Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Products.Repositories
{
    public interface IReadProducts
    {
        Task<IEnumerable<Product>> ReadAsync(ProductFilterCriteria searchCriteria);
    }
}

