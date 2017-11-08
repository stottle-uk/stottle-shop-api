using stottle_shop_api.Categories.Models;
using System.Collections.Generic;
using System.Linq;

namespace stottle_shop_api.Data.TestData
{
    public static class TestCategoryData
    {
        public static IEnumerable<Category> GetCategories() => Enumerable
                .Range(0, 8)
                .Select(count => new Category
                {
                    Id = count.ToString(),
                    Code = $"cat{count}",
                    DisplayName = $"Cat {count}",
                    IsActive = true,
                    ChildCategories = Enumerable.Range(0, 5).Select(childCount => new Category
                    {
                        Code = $"cat{childCount}",
                        DisplayName = $"Child {childCount}",
                        IsActive = true,
                        Filters = Enumerable.Range(0, 3).Select(filCount => $"fil{filCount}"),
                    })
                });
    }
}
