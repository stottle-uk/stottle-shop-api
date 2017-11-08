using stottle_shop_api.Filters.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stottle_shop_api.Filters.Repositories
{
    public interface IReadFilters
    {
        Task<IEnumerable<Filter>> ReadAsync(IEnumerable<string> filterIds);
    }
}

