using System;
using System.Collections.Generic;

namespace stottle_shop_api.Filters
{
    public class Filter : IFilter
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public IEnumerable<FilterItem> Items { get; set; }
    }
}
