using System.Collections.Generic;

namespace stottle_shop_api.Filters.Models
{
    public interface IFilterItem
    {
        string DisplayName { get; set; }
        string Code { get; set; }
    }
}

