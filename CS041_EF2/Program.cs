using CS041_EF2.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;


DropDatabaes();
CreateDatabaes();


//InsertData();

using var dbcontext = new ShopContext();
/*var product = (from p in dbcontext.products where p.Id == 3 select p).FirstOrDefault();

var e = dbcontext.Entry(product);
e.Reference(p => p.Category).Load();

product.PrintInfo();
if (product .Category != null) {
    Console.WriteLine($"{product.Category.Name} - {product.Category.Description}");
}
else
{
    Console.WriteLine("category == null");
}*/

/*var category = (from c in dbcontext.categories where c.CategoryId == 2 select c).FirstOrDefault();
Console.WriteLine($"{category.CategoryId} - {category.Name}");

*//* co' virtual thi khong can dung
var e = dbcontext.Entry(category);
e.Collection(c => c.Products).Load();*//*

if(category.Products != null)
{
    Console.WriteLine($"So san pham: {category.Products.Count()}");
    category.Products.ForEach(p => p.PrintInfo());
}
else
{
    Console.WriteLine("Product == null");
}*/



/*
// with LazyLoadingPoxies
var p = dbcontext.products.Find(4);
p.PrintInfo();*/

/*var products = from p in dbcontext.products
               where p.Price >= 500
               select p;*/
/*var products = from p in dbcontext.products
               where p.Name.Contains("i")
               orderby p.Price
               select p;*/
//products.ToList().ForEach(p => p.PrintInfo());


/*var products = from p in dbcontext.products
         join c in dbcontext.categories on p.CateId equals c.CategoryId
         select new
         {
             ten = p.Name,
             danhmuc = c.Name,
             gia = p.Price
         };
products.ToList().ForEach(p => Console.WriteLine(p));*/


static void CreateDatabaes()
{
    using var dbcontext = new ShopContext();
    string dbname = dbcontext.Database.GetDbConnection().Database;
    Console.WriteLine(dbname);

    var kq = dbcontext.Database.EnsureCreated();
    if (kq)
    {
        Console.WriteLine($"tao {dbname} thanh cong");
    }
    else
    {
        Console.WriteLine($"tao {dbname} khong thanh cong");
    }

}

static void DropDatabaes()
{
    using var dbcontext = new ShopContext();
    string dbname = dbcontext.Database.GetDbConnection().Database;
    Console.WriteLine(dbname);

    var kq = dbcontext.Database.EnsureDeleted();
    if (kq)
    {
        Console.WriteLine($"xoa {dbname} thanh cong");
    }
    else
    {
        Console.WriteLine($"xoa{dbname} khong thanh cong");
    }

}

static void InsertData()
{
    using var dbcontext = new ShopContext();
    Category c1 = new Category()
    {
        Name = "Dien thoai",
        Description = "Cac loai dien thoai"
    };
    Category c2 = new Category()
    {
        Name = "Do uong",
        Description = "Cac loai do uong"
    };
    dbcontext.categories.Add(c1);
    dbcontext.categories.Add(c2);

  /*  var c1 = (from c in dbcontext.categories where c.CategoryId == 1 select c).FirstOrDefault();
    var c2 = (from c in dbcontext.categories where c.CategoryId == 2 select c).FirstOrDefault();*/

    dbcontext.Add(new Product() { Name = "Iphone 8", Price = 1200, CateId = 1 });
    dbcontext.Add(new Product() { Name = "Iphone 11", Price = 2200, Category = c1 });
    dbcontext.Add(new Product() { Name = "Cocacola", Price = 100, CateId = 2 });
    dbcontext.Add(new Product() { Name = "Samsung Galaxy Z Flip 5", Price = 4000, Category = c1 });
    dbcontext.Add(new Product() { Name = "Bac siu", Price = 120, Category = c2 });

    dbcontext.SaveChanges();
}