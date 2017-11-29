using System.Collections.Generic;

namespace stottle_shop_api.Shop.Models
{
    public class CategorySetFiltersDTO
    {
        public IEnumerable<CategorySetFilterDTO> CategorySetFilters { get; set; }
    }

    public class CategorySetFilterDTO
    {
        public string CategorySetName { get; set; }
        public string CategoryCode { get; set; }
        public string FilterSetName { get; set; }
    }
}
