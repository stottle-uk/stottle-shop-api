using System.Collections.Generic;

namespace stottle_shop_api.Shop.Models
{
    public class StoreProductFiltersDTO
    {
        public IEnumerable<StoreProductFilterDTO> StoreProductFilters { get; set; }
    }

    public class StoreProductFilterDTO
    {
        public string StoreItemName { get; set; }
        public string Gtin { get; set; }
        public string FilterSetName { get; set; }
        public string Code { get; set; }
    }
}
