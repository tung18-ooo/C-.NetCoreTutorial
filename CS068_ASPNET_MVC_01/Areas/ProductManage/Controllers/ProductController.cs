using CS068_ASPNET_MVC_01.Controllers;
using CS068_ASPNET_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS068_ASPNET_MVC_01.Areas.ProductManage.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public ActionResult Index()
        {
            // /Areas/AreaName/Views/NameController/Action.cshtml

            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);  // /Areas/ProductManage/Views/Product/Index.cshtml
        }
    }
}
