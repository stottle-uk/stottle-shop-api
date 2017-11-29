using System.Collections.Generic;

namespace stottle_shop_api.Shop.Models
{
    public class StoreItemDTO
    {
        public string Name { get; set; }
        public StoreItemOptionsDTO Options { get; set; }
    }

    public class StoreItemOptionsDTO
    {
        public string DefaultCategorySetName { get; set; } = "Brandbank";
        public string DefaultCurrency { get; set; } = "£";
        public bool DisplayBanners { get; set; } = false;
        public bool DisplayLandingPage { get; set; } = false;
        public bool DisplayLogoutButton { get; set; } = true;
        public bool DisplayOldPrice { get; set; } = false;
        public bool DisplayPromotionalText { get; set; } = false;
        public bool DisplayReviews { get; set; } = false;
    }

}
