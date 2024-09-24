    using CS068_ASPNET_MVC_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS068_ASPNET_MVC_01.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ProductService _productService;


        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment environment, ProductService productService)
        {
            _logger = logger;
            _environment = environment;
            _productService = productService;
        }
        public string Index()
        {
            //property
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            //pagemodel
            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData

            _logger.Log(LogLevel.Warning, "thong bao abc");
            _logger.LogError("thong bao abc");
            _logger.LogWarning("thong bao abc");
            _logger.LogDebug("thong bao abc");
            _logger.LogCritical("thong bao abc");

            _logger.LogInformation("Index action");  //nen su dung
            // or 
            //Console.WriteLine("Index action");

            return "Index cua First";
        }

        //action
        public void Nothing()
        {
            _logger.LogInformation("Nothing action");
            Response.Headers.Add("hi", "Xin chao cac ban");
        }

        public object Anything() => DateTime.Now;

        //IACtionResult

        public IActionResult Readme()
        {
            var content = @"
                Xichao cac ban
                ASP.NET Core MVC

                HoangTung
                ";
            return Content(content, "text/plain");
        }


        //file
         public IActionResult Bird() {
            string filepath = Path.Combine(_environment.ContentRootPath, "Files", "bird.jpg");
            var bytes = System.IO.File.ReadAllBytes(filepath);

            return File(bytes, "image/jpg");
        }

        //json
        public IActionResult IphonePrice()
        {
            return Json(new
            {
                productName = "Iphone 11",
                Price = 10000
            });
        }

        //LocalRedirect
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); //local ~ host
        }

        //Redirect
        public IActionResult Google()
        {
            var url = "https://www.google.com.vn/";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url); 
        }


        //View
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
                username = "Khach";
            //View  -> Razor Engine, doc .cshtml (template)
            //------------------------------------------
            // View(template) - template duong dan tuyet doi  toi .cshtml
            // View(template, model)
            //return View("/MyView/Hello.cshtml",username);

            //Hello2.cshtml -> View/First/Hello2.cshtml
            //return View("Hello2",username);

            //HelloView.cshtml -> View/First/HelloView.cshtml
            // /View/Controller/Action.cshtml
            //return View((object)username);

            return View("Hello3",username);

            //View
            //ViewModel

        }

        /*
        [AcceptVerbs]
        [Route]
        [HttpGet]
        [HttpPost]
        [HttpPut]
        [HttpDelete]
        [HttpHead]
        [HttpPatch]
        */



        [TempData]
        public string StatusMessage { get; set; }

        [AcceptVerbs("POST", "GET")]
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                //TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "San pham ban yeu cau khong co";
                return Redirect(Url.Action("Index", "Home"));
            }

            //View/First/ViewProduct.cshtml
            //MyView/First/ViewProduct.cshtml

            //Model
            //return View(product);


            //ViewData
            /*this.ViewData["product"] = product;
            ViewData["Title"] = product.Name;
            return View("ViewProduct2");*/

            
            //ViewBag
            ViewBag.product = product;
            return View("ViewProduct3");

            //return Content($"San pham ID = {id}");
        }

        /*
         * 
          Kiểu trả về                 | Phương thức
          ------------------------------------------------
          ContentResult               | Content()
          EmptyResult                 | new EmptyResult()   ~ void
          FileResult                  | File()
          ForbidResult                | Forbid()
          JsonResult                  | Json()
          LocalRedirectResult         | LocalRedirect()
          RedirectResult              | Redirect()
          RedirectToActionResult      | RedirectToAction()
          RedirectToPageResult        | RedirectToRoute()
          RedirectToRouteResult       | RedirectToPage()
          PartialViewResult           | PartialView()
          ViewComponentResult         | ViewComponent()
          StatusCodeResult            | StatusCode()
          ViewResult                  | View()
              */
    }
}
