using System;
using System.Collections.Generic;
using stottle_shop_api.Categories;
using stottle_shop_api.Filters;

namespace stottle_shop_api.Products.Models
{
    public class ProductFilterCriteria
    {
        public string Category { get; set; }
        public string Filters { get; set; }
        public string SearchTerm { get; set; }
        public int Limit { get; set; }
        public int Skip { get; set; }
    }
}
