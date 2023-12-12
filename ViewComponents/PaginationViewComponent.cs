using ChuQuangHuy_211204440.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChuQuangHuy_211204440.ViewComponents
{
	public class PaginationViewComponent : ViewComponent
	{
		private NewShopContext _dbContext;
		private List<Product> _products;

		public PaginationViewComponent(NewShopContext dbContext)
		{
			_dbContext = dbContext;
			_products = dbContext.Products.ToList();
		}


		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RenderPagination", _products);
		}
	}
}
