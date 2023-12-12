using ChuQuangHuy_211204440.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChuQuangHuy_211204440.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private NewShopContext _dbContext;
        private List<Category> _categories;

        public CategoryViewComponent(NewShopContext dbContext)
        {
            _dbContext = dbContext;
            _categories = dbContext.Categories.ToList();
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderCategory", _categories);
        }
    }
}
