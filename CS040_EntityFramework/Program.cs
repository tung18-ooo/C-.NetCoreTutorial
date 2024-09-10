// See https://aka.ms/new-console-template for more information
//-> entity -> database
//database : data1 -> DbContext
// --product
using CS040_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

//CreateDatabaes();
//DropDatabaes();

//InsertProduct();

//ReadProducts();

//RenameProduct(3, "rewr");
//DeleteProduct(6);

//logging
ReadProducts();

//Insert, Update, Delete   -> CRUD
static void CreateDatabaes()
{
    using var dbcontext = new ProductBdContext();
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
    using var dbcontext = new ProductBdContext();
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

static void InsertProduct()
{
    using var dbcontext = new ProductBdContext();
    /*
     - Model (product)
    - Add, AddSync
    - SaveChange
     
     */
    /*var p1 = new Product();
    p1.ProductName = "San pham 2";
    p1.Provider = "Cong ty 2";
    dbcontext.Add(p1);*/

    var products = new object[]
    {
        new Product(){ProductName = "san pham 3",Provider ="CTY 3" },
        new Product(){ProductName = "san pham 4",Provider ="CTY 4" },
        new Product(){ProductName = "san pham 5",Provider ="CTY 5" },
        new Product(){ProductName = "san pham 6",Provider ="CTY 6" },
    };


    dbcontext.AddRange(products);


    //dbcontext.SaveChanges();
    int num_row = dbcontext.SaveChanges();
    Console.WriteLine($"da chen {num_row} du lieu");
}

static void ReadProducts()
{
    using var dbcontext = new ProductBdContext();
    //linq
    /*var products = dbcontext.products.ToList();
    products.ForEach(products => products.PrintInfo());*/

    /*var qr = from product in dbcontext.products
             where product.Id >= 3
             select product;
    qr.ToList().ForEach(product => { product.PrintInfo(); });*/

    /*var qr = from product in dbcontext.products
             where product.Provider.Contains("CTY") //provider co CTY
             orderby product.Id descending // lon -> be
             select product;
    qr.ToList().ForEach(product => { product.PrintInfo(); });*/

    Product pro = (from p in dbcontext.products
                  where p.Id == 4
                  select p).FirstOrDefault();
    if (pro!= null)
    {
        pro.PrintInfo();
    }
}

static void RenameProduct(int id,  string newName)
{
    using var dbcontext = new ProductBdContext();
    Product pro = (from p in dbcontext.products
                   where p.Id == id
                   select p).FirstOrDefault();
    if (pro != null)
    {
        // product -> DbContext
        EntityEntry<Product> entry = dbcontext.Entry(pro);
        entry.State = EntityState.Detached; //tach pro ra khoi DbContext

        pro.ProductName = newName;
        int num_row = dbcontext.SaveChanges();
        Console.WriteLine($"da cap nhat {num_row} du lieu");

    }
}

static void DeleteProduct(int id)
{
    using var dbcontext = new ProductBdContext();
    Product pro = (from p in dbcontext.products
                   where p.Id == id
                   select p).FirstOrDefault();
    if (pro != null)
    {
       dbcontext.Remove(pro);

        int num_row = dbcontext.SaveChanges();
        Console.WriteLine($"da xoa {num_row} du lieu");

    }
}

