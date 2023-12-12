using ChuQuangHuy_211204440.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChuQuangHuy_211204440.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewShopContext _dbContext;
        private int pageSize = 3;

        public HomeController(ILogger<HomeController> logger, NewShopContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // Home
        public IActionResult Index(int pageIndex = 1)
        {
            var query = (IQueryable<Product>)_dbContext.Products;

            var products = query
				.Skip(0)
                .Take(6)
                .OrderByDescending(p => p.CategoryId)
                .ToList();

            ViewBag.PageIndex = pageIndex;
            ViewBag.PageNumber = (int)Math.Ceiling(query.Count() / (float)pageSize);

            return View(products);
        }

        public IActionResult ListProduct(int categoryId = 0, int pageIndex = 0)
        {
            var query = (IQueryable<Product>)_dbContext.Products;
            if (categoryId != 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            if (pageIndex != 0)
            {
                query = query.Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
            }
            var products = query.ToList();
            return PartialView(products);
        }

        // Create page
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

        public IActionResult DeleteProduct(string productId)
        {
            Product? product = _dbContext.Products.Find(productId);

            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductConfirmed(string id)
        {
            var qComment = (IQueryable<Comment>)_dbContext.Comments;
            var qOrderDetail = (IQueryable<OrderDetail>)_dbContext.OrderDetails;

            var comments = qComment.Where(p => p.ProductId == id).ToList();
            var orderDetails = qOrderDetail.Where(p => p.ProductId == id).ToList();
            
            if (comments.Count() == 0 && orderDetails.Count() == 0)
            {
                var product = await _dbContext.Products.FindAsync(id);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                }

                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            } else
            {
                ViewBag.Message = "Không thể xóa vì tồn tại OderDetail và Commnet của sản phẩm này.";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}