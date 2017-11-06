using System.Collections.Generic;

namespace stottle_shop_api.Filters
{
    public interface IFilter
    {
        string DisplaName { get; set; }
        string Code { get; set; }
        IEnumerable<IFilterItem> Items { get; set; }
    }

    public interface IFilterItem
    {
        string DisplaName { get; set; }
        string Code { get; set; }
    }
}

