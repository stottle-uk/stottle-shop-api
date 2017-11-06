using System.Collections.Generic;

namespace stottle_shop_api.Filters
{
    public interface IFilterItem
    {
        string DisplayName { get; set; }
        string Code { get; set; }
    }
}

