using System;
using System.Collections.Generic;
using stottle_shop_api.Categories;
using stottle_shop_api.Filters;

namespace stottle_shop_api.Models.Products
{
    public class Product
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
        public double Price { get; set; }
        public IDictionary<int, string> ImageLinks { get; set; }
        public Category Category { get; set; }
        public IEnumerable<FilterItem> Filters { get; set; }
    }
}
