using CS055_ASP.NET_Razor_06.Models;
using CS055_ASP.NET_Razor_06.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS055_ASP.NET_Razor_06.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly ILogger<ProductPageModel> _logger;
        public readonly ProductService productService;
        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService _productService)
        {
            _logger = logger;
            productService = _productService;
        }

        //Handler : OnGet, OnPost, ... HttpRequest
        //tra ve void,

        /*public void OnGet()
        {
            if (Request.RouteValues["id"] != null)
            {
                int id = int.Parse(Request.RouteValues["id"].ToString());
                ViewData["Title"] = $"San pham (ID = {id})";
            }
            else
            {
                ViewData["Title"] = "Danh sach san pham";

            }
        }*/

        public Product product { get; set; }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                ViewData["Title"] = $"San pham (ID = {id.Value})";
                product = productService.Find(id.Value);
            }
            else
            {
                ViewData["Title"] = "Danh sach san pham";

            }
        }


        //product/{id:int?}?handler=lastproduct
        public void OnGetLastProduct() {
            ViewData["Title"] = $"San pham cuoi";
            product = productService.GetAllProducts().LastOrDefault();
        }

        public IActionResult OnGetRemoveAll()
        {
            productService.GetAllProducts().Clear();
            return RedirectToPage("ProductPage");
        }

        public IActionResult OnGetLoad()
        {
            productService.LoadProducts();
            return RedirectToPage("ProductPage");
        }

        public IActionResult OnPostDelete(int? id)
        {
            if (id != null)
            {
                product = productService.Find(id.Value);
                if(product != null)
                {
                    productService.GetAllProducts().Remove(product);
                }
            }
            return RedirectToPage("ProductPage",new{id = string.Empty });
        }
    }
}
