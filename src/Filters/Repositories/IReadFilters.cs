using System.Collections.Generic;
using System.Threading.Tasks;
using stottle_shop_api.Filters.Models;

namespace stottle_shop_api.Filters.Repositories
{
    public interface IReadFilters
    {
        Task<IEnumerable<Filter>> ReadAsync(IEnumerable<string> filterIds);
    }
}

