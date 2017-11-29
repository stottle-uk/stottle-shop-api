using System.Collections.Generic;

namespace stottle_shop_api.Shop.Models
{
    public class CategorySetsDTO
    {
        public IEnumerable<CategorySetDTO> FilterSets { get; set; }
    }

    public class CategorySetDTO
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public IEnumerable<CategorySetItemDTO> Items { get; set; }
        public IEnumerable<string> Filters { get; set; }

    }

    public class CategorySetItemDTO
    {
        public string DisplayName { get; set; }
        public string Code { get; set; }
        public IEnumerable<string> Filters { get; set; }

    }
}
