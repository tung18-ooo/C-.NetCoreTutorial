using CS053_ASP.NET_Razor_04.Models;

namespace CS053_ASP.NET_Razor_04.Services
{
    public class ProductListService
    {
        public List<Product> products { get; set; } = new List<Product>() {
                new Product(){ Name = "SP1",Description="Mo ta sp1",Price = 110},
                new Product(){ Name = "SP2",Description="Mo ta sp2",Price = 120},
                new Product(){ Name = "SP3",Description="Mo ta sp3",Price = 130},
                new Product(){ Name = "SP4",Description="Mo ta sp4",Price = 140},
            };
    }
}
