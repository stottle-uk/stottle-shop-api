using System.Collections.Generic;
using stottle_shop_api.Filters;

namespace stottle_shop_api.Categories.Models
{
    public interface ICategory
    {
        string DisplayName { get; set; }
        string Code { get; set; }
        IEnumerable<Category> ChildCategories { get; set; }
        IEnumerable<string> Filters { get; set; }
    }
}

