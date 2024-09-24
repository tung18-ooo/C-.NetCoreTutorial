using CS068_ASPNET_MVC_01.Models;

namespace CS068_ASPNET_MVC_01.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService() {
            this.AddRange(new ProductModel[]
            {
            new ProductModel() {Id = 1, Name ="Iphone X",Price = 1000},
            new ProductModel() {Id = 2, Name ="Sony X3",Price = 800},
            new ProductModel() {Id = 3, Name ="Nokia Lumia 520",Price = 300},
            new ProductModel() {Id = 4, Name ="Samsung A10",Price = 600},
            });
        }
    }
}
