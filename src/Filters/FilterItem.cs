using System;
using System.Collections.Generic;

namespace stottle_shop_api.Filters
{
    public class FilterItem : IFilterItem
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }
    }
}
