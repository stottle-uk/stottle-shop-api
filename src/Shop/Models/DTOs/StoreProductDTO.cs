using System.Collections.Generic;

namespace stottle_shop_api.Shop.Models
{
    public class StoreProductDTO
    {
        public string Name { get; set; }
        public IEnumerable<StoreProductsDTO> Products { get; set; }
    }

    public class StoreProductsDTO
    {
        public string Gtin { get; set; }
        public int Pvid { get; set; }
        public string Name { get; set; }
        public string SubscriberCode { get; set; }
        public IEnumerable<double> Prices { get; set; }
        public double OldPrice { get; set; }
        public IEnumerable<int> Ratings { get; set; }
        public bool IsPromotion { get; set; }
        public string PromotionalText { get; set; }
        public int Weight { get; set; }
        public IEnumerable<string> RelatedGTINs { get; set; }
    }
    
}
