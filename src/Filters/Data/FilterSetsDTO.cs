using System.Collections.Generic;

namespace stottle_shop_api.Filters.Data
{
    public class FilterSetsDTO
    {
        public IEnumerable<FilterSetDTO> FilterSets { get; set; }
    }

    public class FilterSetDTO
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public IEnumerable<FilterSetItemDTO> Items { get; set; }
    }

    public class FilterSetItemDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsHiddenOnLoad { get; set; }
    }
}
