using System.Collections.Generic;

namespace stottle_shop_api.Categories
{
    public class Category : ICategory
    {
        public string DisplaName { get; set; }
        public string Code { get; set; } 
        public IEnumerable<ICategory> ChildCategories { get; set; }
        public string CreatedData { get; set; }
    }
}