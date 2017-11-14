using stottle_shop_api.Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Shop.Repositories
{
    public interface IWriteShops
    {
        Task InsertAsync(Store store);
    }
}

