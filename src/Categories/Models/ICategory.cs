using System.Collections.Generic;

namespace stottle_shop_api.Categories.Models
{
    public interface ICategory
    {
        string DisplayName { get; set; }
        string Code { get; set; }
        bool IsActive { get; set; }
        IEnumerable<Category> ChildCategories { get; set; }
        IEnumerable<string> Filters { get; set; }
    }
}

