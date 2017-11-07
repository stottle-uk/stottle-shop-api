using System.Collections.Generic;

namespace stottle_shop_api.Filters.Models
{
    public interface IFilter
    {
        string DisplayName { get; set; }
        string Code { get; set; }
        bool IsActive { get; set; }
        IEnumerable<FilterItem> Items { get; set; }
    }
}

