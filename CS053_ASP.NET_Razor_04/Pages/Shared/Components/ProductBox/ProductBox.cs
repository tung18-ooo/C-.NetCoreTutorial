using CS053_ASP.NET_Razor_04.Models;
using CS053_ASP.NET_Razor_04.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS053_ASP.NET_Razor_04.Pages.Shared.Components.ProductBox
{
    //[ViewComponent]
    //or
    //public class ProductBoxViewComponent
    //or
    public class ProductBox : ViewComponent
    {
        // Invoke(object m)
        // InvokeAsync()

        /*
         * [ViewComponent]
         * dat ten class co hau to ViewComponent
         * ke thua ViewComponent
        */
        /*public string Invoke()
        {
            return "Noi dung cua ProductBox";
        }*/
        /*public IViewComponentResult Invoke()
        {
            //return View(); // /ProductBox/Default.cshtml
            //return View("Default1");
            return View<string>("Noi dung");
        }*/
        ProductListService productService;
        public ProductBox(ProductListService _products)
        {
            productService = _products;
        }
        public IViewComponentResult Invoke(bool sapxeptang = true)
        {
           /* var products = new List<Product>() {
                new Product(){ Name = "SP1",Description="Mo ta sp1",Price = 110},
                new Product(){ Name = "SP2",Description="Mo ta sp2",Price = 120},
            };*/

            List<Product> _products = null;

            if (sapxeptang)
            {
                _products = productService.products.OrderBy(p =>  p.Price).ToList();
            }
            else
            {
                _products = productService.products.OrderByDescending(p => p.Price).ToList();
            }

            return View<List<Product>>(_products);
        }
    }
}
