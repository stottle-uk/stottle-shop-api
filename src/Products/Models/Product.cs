using System.Collections.Generic;
using stottle_shop_api.Categories.Models;
using stottle_shop_api.Filters;

namespace stottle_shop_api.Products.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, string> ImageLinks { get; set; }
        public Category Category { get; set; }
        public List<FilterItem> Filters { get; set; }
    }
}
