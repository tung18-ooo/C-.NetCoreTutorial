using CS068_ASPNET_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS068_ASPNET_MVC_01.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;


        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
