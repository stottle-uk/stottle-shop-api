using System.Collections.Generic;

namespace stottle_shop_api.Filters.Models
{
    public class Filter : IFilter
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<FilterItem> Items { get; set; }
    }
}
