// See https://aka.ms/new-console-template for more information
/*List<int> ds1 = new List<int>() { 7,8,9};

ds1.Add(1);
ds1.Add(2);
ds1.AddRange(new int[] { 3, 4, 5 });
Console.WriteLine(ds1.Count);
Console.WriteLine(ds1[2]);
Console.WriteLine(ds1[ds1.Count - 1]);

ds1.Insert(0, 100); //them phan tu ... vao vi tri ...
Console.WriteLine(ds1[0]);

foreach (int i in ds1)
{
    Console.WriteLine(i);
}
 
ds1.RemoveAt(1); //xoa phan tu tai vi tri ...
ds1.Remove(1); //xoa phan tu co gia tri ...

foreach (int i in ds1)
{
    Console.WriteLine(i);
}
*/


/*List<int> ds1 = new List<int> { 7, 8, 6, 5, 8, 4, 5, 0 };
var n = ds1.Find(e =>
{
    return e % 2 == 0;
});
Console.WriteLine(n);

Console.WriteLine();
var rs = ds1.FindAll(e =>
{
    return e % 2 == 0;
});
foreach (var r in rs)
{
    Console.WriteLine(r);
}
*/

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Iphone X",
        Price = 10000,
        Origin = "China",
        Id = 1,
    },
    new Product()
    {
        Name = "Iphone 13 ProMax",
        Price = 23000,
        Origin = "Korea",
        Id = 2,
    },
    new Product()
    {
        Name = "Iphone 11",
        Price = 21000,
        Origin = "Japan",
        Id = 3,
    },
    
    new Product()
    {
        Name = "Iphone 15 Pro",
        Price = 33000,
        Origin = "China",
        Id = 4,
    }
};

/*var p = products.Find(p =>
{
    return p.Origin == "China";
});
if (p != null)
{
    Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
}
Console.WriteLine();

//price < 22000
var p1 = products.FindAll(e =>
{
    return e.Origin.StartsWith("C");
});
foreach (var i in p1)
{
    Console.WriteLine($"{i.Name} - {i.Price} - {i.Origin}");
}*/

/*//sap xep

products.Sort((e1, e2) =>
{
    if (e1.Price == e2.Price)
    {
        return 0;
    }
    if (e1.Price < e2.Price)
    {
        return 1;
    }
    return -1;
}
);
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
}

Console.WriteLine("----------------");
products.Sort((e1, e2) =>
{
    if (e1.Price == e2.Price)
    {
        return 0;
    }
    if (e1.Price < e2.Price)
    {
        return -1;
    }
    return 1;
}
);
foreach (var p in products)
{
    Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
}*/


//SortedList
SortedList<string, Product > product = new SortedList<string, Product>();
product["sanpham1"] = new Product() { Name = "Samsung Galaxy A54", Price = 16000, Origin = "Krorea" };
product["sanpham2"] = new Product() { Name = "Samsung Galaxy S23 Ultra", Price = 24000, Origin = "Krorea" };
product.Add("sanpham3", new Product() { Name = "Samsung Galaxy S22 Ultra", Price = 20000, Origin = "Krorea" });

var p = product["sanpham2"];
Console.WriteLine(p.Name);
Console.WriteLine();

var keys = product.Keys;
var values = product.Values;
foreach(var k in keys)
{
    var pr = product[k];
    Console.WriteLine(pr.Name);
}
Console.WriteLine();


foreach (KeyValuePair<string, Product> item in product)
{
    var key = item.Key;
    var value = item.Value;
    Console.WriteLine($"{key} - {value.Name}");

}
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Id { get; set; }
    public string Origin { get; set; }

}