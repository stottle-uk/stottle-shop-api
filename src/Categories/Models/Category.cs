using System.Collections.Generic;

namespace stottle_shop_api.Categories.Models
{
    public class Category : ICategory
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Code { get; set; } 
        public bool IsActive { get; set; }
        public IEnumerable<Category> ChildCategories { get; set; }
        public IEnumerable<string> Filters { get; set; }
    }
}