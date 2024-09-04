namespace CS033_ASP.NETCore_Dependency
{
    public class ProductServices
    {
        public class Product
        {
            public string ID { get; set; } //ma san pham
            public string Name { get; set; } //ten san pham
            public double Price { get; set; } //gia san pham

        }
        public class ProductService
        {
            List<Product>products = new List<Product>();
            public ProductService()
            {
                Console.WriteLine("Khoi tao productService");
                products.AddRange(new Product[] {
                    new Product() { ID = "product01", Name = "Iphone 8", Price = 1000},
                    new Product() { ID = "product02", Name = "Iphone 11 Pro", Price = 2900},
                    new Product() { ID = "product03", Name = "Iphone 11", Price = 3000},
                    new Product() { ID = "product04", Name = "Iphone 12", Price = 4000},
                    new Product() { ID = "product05", Name = "Iphone 13", Price = 5000},
                });
            }
            public Product FindProduct(string productid)
            {
                var qr = from p in products where p.ID == productid select p;
                return qr.FirstOrDefault();
            }
        }
    }
}
