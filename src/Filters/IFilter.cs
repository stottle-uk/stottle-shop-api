using System.Collections.Generic;

namespace stottle_shop_api.Filters
{
    public interface IFilter
    {
        string DisplayName { get; set; }
        string Code { get; set; }
        IEnumerable<FilterItem> Items { get; set; }
    }
}

