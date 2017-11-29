using System.Collections.Generic;

namespace stottle_shop_api.Shop.Models
{
    public class StoreProductCategoriesDTO
    {
        public IEnumerable<StoreProductCategoryDTO> StoreProductCategories { get; set; }
    }

    public class StoreProductCategoryDTO
    {
        public string StoreItemName { get; set; }
        public string Gtin { get; set; }
        public string CategorySetName { get; set; }
        public string Code { get; set; }
    }
}
