// See https://aka.ms/new-console-template for more information


// LINQ (Lenguage Integrated Query): Ngon ngu truy van tich hop
//SQl
//Nguon du lieu: INumerable, INumerable<T> () (Array, List, Stack, Queue, ... )
//               XML, SQL


/*Product p = new Product(1, "san pham 1", 1000, new string[] { "Xanh", "Do" }, 2);
Console.WriteLine(p.ToString());*/


using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

var brands = new List<Brand>()
{
    new Brand{ID = 1, Name ="Cong ty AAA"},
    new Brand{ID = 2, Name ="Cong ty BBB"},
    new Brand{ID = 3, Name ="Cong ty CCC"},
};
var products = new List<Product>()
{
    new Product(1,"Ban tra",400,new string[]{"Xam","Xanh"},2),
    new Product(2,"Tranh treo",400,new string[]{"Vang","Xanh"},1),
    new Product(3,"Den trum",500,new string[]{"Trang"},3),
    new Product(4,"Ban hoc",200,new string[]{"Trang","Xanh"},4),
    new Product(5,"Tui da",300,new string[]{"Do","Den","Vang"},2),
    new Product(6,"Giuong ngu",500,new string[]{"Trang"},2),
    new Product(7,"Tu ao",600,new string[]{"Trang"},3),
    new Product(8,"Noi com",500,new string[]{"Trang"},4),

};

//Lay san pham gia 400
var query = from p in products where p.Price == 400 select p;
foreach (var product in query)
{
    Console.WriteLine(product);
}


Console.WriteLine("---------------------------------------------");


//Select
var select = products.Select(
    p =>
    {
        //return p.Name + " (" + p.Price + ")";
        return new
        {
            Ten = p.Name,
            Gia = p.Price,
        };
    }
    );
foreach (var item in select)
{
    Console.WriteLine(item);
}


Console.WriteLine("---------------------------------------------");

//Where
var where = products.Where(
    p =>
    {
        //return p.Name.Contains("tr");
        return p.Brand == 2 && p.Price >= 300 && p.Price <= 400;
    }
    );
foreach (var item in where)
{
    Console.WriteLine(item);
}
Console.WriteLine("---------------------------------------------");



//SelectMany
var selectmany = products.SelectMany(
    p =>
    {
        return p.Colors;
    }
    );
foreach (var item in selectmany)
{
    Console.WriteLine(item);
}
Console.WriteLine("---------------------------------------------");


//Min, Max, Sum, Average
int[] numbers = { 1, 2, 4, 6, 4, 3, 8, 6, 5, 9 };

Console.WriteLine($"Max: {numbers.Max()}");

Console.WriteLine($"Min: {numbers.Min()}");

Console.WriteLine($"Sum: {numbers.Sum()}"); //tong

Console.WriteLine($"Average: {numbers.Average()}"); //trung binh cong

Console.WriteLine($"Average: {numbers.Where(n => n % 2 == 0).Max()}"); //so chan lon nhat
Console.WriteLine($"Average: {numbers.Where(n => n % 2 != 0).Sum()}"); //tong cac so le


//Gia san pham nho nhat
Console.WriteLine($"Gia san pham nho nhat: {products.Min(p => p.Price)}");

Console.WriteLine("---------------------------------------------");


//Join

var join = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
{
    /*return new
    {
        Ten = p.Name,
        ThuongHieu = b.Name,
    };*/

    return $"{p.Name,10} {b.Name,13}";
});
foreach (var item in join)
{
    Console.WriteLine(item);
}
Console.WriteLine("---------------------------------------------");



// GroupJoin
var grj = brands.GroupJoin(products, b => b.ID, p => p.Brand, (brand, pros) =>
{
    return new
    {
        Thuonghieu = brand.Name,
        Cacsanpham = pros,
    };
});
foreach (var item in grj)
{
    Console.WriteLine(item.Thuonghieu);
    foreach (var p in item.Cacsanpham)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine();
}
Console.WriteLine("---------------------------------------------");


//Take
//lay 4 san pham dau tien
products.Take(4).ToList().ForEach(p => Console.WriteLine(p));
Console.WriteLine("---------------------------------------------");


//Skip
products.Skip(2).ToList().ForEach(p => Console.WriteLine(p));
Console.WriteLine("---------------------------------------------");


// OrderBy (tang dan)
//gia tang dan
products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));
Console.WriteLine("---------------------------------------------");


//OrderByDescending (giam dan)
//Brand giam dan
products.OrderByDescending(p => p.Brand).ToList().ForEach(p => Console.WriteLine(p));
Console.WriteLine("---------------------------------------------");


//Reverse (dao nguoc)
numbers.Order().Reverse().ToList().ForEach(p => Console.WriteLine(p));
Console.WriteLine("---------------------------------------------");


//GroupBy
var groupby = products.GroupBy(p => p.Price);
foreach (var item in groupby)
{
    Console.WriteLine(item.Key);
    foreach (var p in item)
    {
        Console.WriteLine(p);
    }
}
Console.WriteLine("---------------------------------------------");


//Distinct (rieng biet)
products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(p => Console.WriteLine(p));
Console.WriteLine("---------------------------------------------");


//Single
var single = products.Single(p => p.Price == 600); //price trung nhau or khong ton tai -> error
Console.WriteLine(single);

//SingleOrDefault
var singleordefault = products.SingleOrDefault(p => p.Price == 100); //price trung nhau --> error
if (singleordefault != null)
{
    Console.WriteLine(singleordefault);
}
Console.WriteLine("---------------------------------------------");


//Any (bool)
var any = products.Any(p => p.Price == 600);
Console.WriteLine(any);
Console.WriteLine("---------------------------------------------");


//All
var all = products.All(p => p.Price >= 200); //ktra tat ca gia tri >=200 khong?
Console.WriteLine(all);
Console.WriteLine("---------------------------------------------");


//Count
Console.WriteLine("Dem so sp:");
var count = products.Count();
Console.WriteLine(count);

Console.WriteLine("So sp gia >=500:");
var count1 = products.Count(p => p.Price >= 500);
Console.WriteLine(count1);
Console.WriteLine("---------------------------------------------");


//In ra ten sp, ten brand, co gia (300-400)
products.Where(p => p.Price >= 300 && p.Price <= 400).OrderByDescending(p => p.Price).Join(brands, p => p.Brand, b => b.ID, (sp, th) =>
{
    return new
    {
        TenSP = sp.Name,
        TenBr = th.Name,
        Gia = sp.Price,
    };
}).ToList().ForEach(item => { Console.WriteLine($"{item.TenSP,10} {item.TenBr,13} {item.Gia,5}"); });
Console.WriteLine("---------------------------------------------");


/*
 *1) Xac dinh nguon: from tenphantu in INumerables
 * ...where, orderby
 *2) Lay du lieu: select, group by
*/

var qr = from a in products
         select a.Name;

qr.ToList().ForEach(p => { Console.WriteLine(p); });
/* or
foreach(var item in qr)
{
    Console.WriteLine(item);
}
*/
Console.WriteLine("---------------------------------------------");



var qr1 = from p in products
          select new
          {
              Ten = p.Name,
              Gia = p.Price,
              smth = "Something",
          };
qr1.ToList().ForEach(p => { Console.WriteLine(p); });
Console.WriteLine("---------------------------------------------");


var qr2 = from p in products
          where p.Price == 400
          select new
          {
              Ten = p.Name,
              Gia = p.Price,
              smth = "Something",
          };
qr2.ToList().ForEach(p => { Console.WriteLine(p); });
Console.WriteLine("---------------------------------------------");

//gia <= 500 && Xanh
var qr3 = from p in products
          from color in p.Colors
          where p.Price <= 500 && color == "Xanh"
          select new
          {
              Ten = p.Name,
              Gia = p.Price,
              Mau = p.Colors,
          };
qr3.ToList().ForEach(p =>
{
Console.WriteLine($"{p.Ten,10} - {p.Gia,4} - {string.Join(',', p.Mau)}");
});
Console.WriteLine("---------------------------------------------");

//order by

var qr4 = from p in products
          from color in p.Colors
          where p.Price <= 500 && color == "Xanh"
          orderby p.Price //descending: giam dan
          select new
          {
              Ten = p.Name,
              Gia = p.Price,
              Mau = p.Colors,
          };
qr4.ToList().ForEach(p =>
{
    Console.WriteLine($"{p.Ten,10} - {p.Gia,4} - {string.Join(',', p.Mau)}");
});
Console.WriteLine("---------------------------------------------");


//nhom san pham theo gia

var qr5 = from p in products
          group p by p.Price;  
qr5.ToList().ForEach(gr =>
{
    Console.WriteLine(gr.Key);
    gr.ToList().ForEach(p => { Console.WriteLine(p); });
});
Console.WriteLine("---------------------------------------------");


var qr6 = from p in products
          group p by p.Price into gr  //into: luu vao 1 bien' tam.
          orderby gr.Key
          select gr;
qr6.ToList().ForEach(gr =>
{
    Console.WriteLine(gr.Key);
    gr.ToList().ForEach(p => { Console.WriteLine(p); });
});
Console.WriteLine("---------------------------------------------");


/* Doi tuong:
 * Gia
 * Cacsanpham
 * Soluong
*/
var qr7 = from p in products
          group p by p.Price into gr  //into: luu vao 1 bien' tam.
          orderby gr.Key
          let sl = "So luong: " + gr.Count()
          select new
          {
              Gia = gr.Key,
              Cacsanpham = gr.ToList(),
              Soluong = sl
          };
qr7.ToList().ForEach(i =>
{
    Console.WriteLine($"{i.Gia}");
    Console.WriteLine($"{ i.Soluong}");
    i.Cacsanpham.ForEach(p => Console.WriteLine(p));
});
Console.WriteLine("---------------------------------------------");


//Ket hop cac nguon du lieu
var qr8 = from p in products
          join b in brands on p.Brand equals b.ID
          select new
          {
              ten = p.Name,
              gia = p.Price,
              thuonghieu = b.Name
          };
qr8.ToList().ForEach(p => Console.WriteLine($"{p.ten,10} {p.gia,4} {p.thuonghieu, 15}"));
Console.WriteLine("---------------------------------------------");

//liet ke ca cac sp co trong product 
var qr9 = from pro in products
          join brand in brands on pro.Brand equals brand.ID into t
          from b in t.DefaultIfEmpty()
          select new
          {
              ten = pro.Name,
              gia = pro.Price,
              thuonghieu = (b != null) ? b.Name : "No Brand"
          };
qr9.ToList().ForEach(p => Console.WriteLine($"{p.ten,10} {p.gia,4} {p.thuonghieu,15}"));
Console.WriteLine("---------------------------------------------");





public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }      // ten
    public double Price { get; set; }     // gia
    public string[] Colors { get; set; }  // mau
    public int Brand { get; set; }        // Id nhan hieu, nhan
    public Product(int id, string name, double price, string[] colors, int brand)
    {
        ID = id;
        Name = name;
        Price = price;
        Colors = colors;
        Brand = brand;
    }

    //Lay chuoi thong tin san pham gom ID, Name, Price
    public override string ToString()
        => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

}

public class Brand
{
    public int ID { get; set; }
    public string Name { get; set; }
}


