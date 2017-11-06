using System.Collections.Generic;

namespace stottle_shop_api.Categories
{
    public interface ICategory
    {
        string DisplayName { get; set; }
        string Code { get; set; }
        IEnumerable<ICategory> ChildCategories { get; set; }
    }
}

