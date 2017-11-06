using System.Collections.Generic;
using stottle_shop_api.Filters;

namespace stottle_shop_api.Categories
{
    public class Category : ICategory
    {
        public string DisplayName { get; set; }
        public string Code { get; set; } 
        public IEnumerable<ICategory> ChildCategories { get; set; }
        public IEnumerable<string> Filters { get; set; }
    }
}