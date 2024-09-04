using CS033_ASP.NETCore_Dependency.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static CS033_ASP.NETCore_Dependency.ProductServices;

namespace CS033_ASP.NETCore_Dependency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }


        public IActionResult ProductInfo(string productid)
        {
            //Console.WriteLine(productid);
            var product = _productService.FindProduct(productid);
            return View(product);
        }

        public IActionResult Index()
        {
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
