using CS055_ASP.NET_Razor_06.Models;

namespace CS055_ASP.NET_Razor_06.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        public void LoadProducts()
        {
            products.Clear();
            products.Add(new Product { Id = 1, Name = "Iphone X", Description = "Dien thoai Iphone X", Price = 1000 });
            products.Add(new Product { Id = 2, Name = "Iphone 11", Description = "Dien thoai Iphone 11", Price = 1200 });
            products.Add(new Product { Id = 3, Name = "Sansung Y", Description = "Dien thoai Samsung Y", Price = 500 });
            products.Add(new Product { Id = 4, Name = "Nokia Lumia 520", Description = "Dien thoai Nokia Lumia 520", Price = 700 });
        }

        public ProductService() { 
        LoadProducts();
        }

        public Product Find(int id) {
        var qr = from p in products
                 where p.Id == id select p;
            return qr.FirstOrDefault();
        }

        public List<Product> GetAllProducts()=> products;

        
    }
}
