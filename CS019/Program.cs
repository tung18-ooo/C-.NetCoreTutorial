// See https://aka.ms/new-console-template for more information

Iphone i = new Iphone();
i.Test();

Console.WriteLine();

Iphone1 i1 = new Iphone1();
i1.Test();


HinhChuNhat h = new HinhChuNhat(4, 5);
Console.WriteLine($"Dien tich: {h.TinhDienTich()}, Chu vi: {h.TinhChuVi()}");
Console.WriteLine();
HinhTron tr = new HinhTron(2);
Console.WriteLine($"Dien tich: {tr.TinhDienTich()}, Chu vi: {tr.TinhChuVi()}");


class Product
{
    protected double Price { get; set; }
    //virtual - phuong thuc ao
    public virtual void ProductInfo()
    {
        Console.WriteLine($"Gia san pham {Price}");
    }

    public void Test() => ProductInfo();
}


class Iphone : Product
{
    public Iphone() => Price = 500;
    //override - nap chong thuong thuc
    public override void ProductInfo()
    {
        Console.WriteLine("Dien thoai Iphone");
        base.ProductInfo();
    }
}

abstract class Product1
{
    protected double Price { get; set; }
    //virtual - phuong thuc ao
    public virtual void ProductInfo()
    {
        Console.WriteLine($"Gia san pham {Price}");
    }

    public void Test() => ProductInfo();
}
class Iphone1 : Product1
{
    public Iphone1() => Price = 500;
    //override - nap chong thuong thuc
    public override void ProductInfo()
    {
        Console.WriteLine("Dien thoai Iphone");
        Console.WriteLine($"Gia san pham {Price}");
    }
}

//interface
interface IHinhHoc
{
    public double TinhChuVi();
    public double TinhDienTich();
}

class HinhChuNhat : IHinhHoc
{
    public HinhChuNhat(double _a, double _b)
    {
        a = _a;
        b = _b;
    }
    public double a { get; set; }
    public double b { get; set; }

    public double TinhChuVi()
    {
        return 2 * (a + b);
    }

    public double TinhDienTich()
    {
        return a * b;
    }
}

class HinhTron : IHinhHoc
{
    public double r { get; set; }
    public HinhTron(double _r) => r= _r;

    public double TinhChuVi()
    {
        return 2 * r * Math.PI;
    }

    public double TinhDienTich()
    {
        return Math.PI * r * r;
    }
}