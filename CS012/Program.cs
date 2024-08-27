// See https://aka.ms/new-console-template for more information
Product sp1;
sp1.name = "Iphone";
sp1.price = 111110;
Product sp2 = new Product("Ipad", 313211);

sp2 = sp1;
sp2.name = "Iphone X";

Console.WriteLine(sp1.getInfo());
Console.WriteLine(sp2.getInfo());
Console.WriteLine(sp2.Info);


//kieu liet ke enum
/*
 0 - Kem
 1 - Trung binh
 2 - Kha
 3 - Gioi
 */
int hocluc = 1;
switch (hocluc)
{
    case 0:
        Console.WriteLine("Hoc luc kem");
        break;
    case 1:
        Console.WriteLine("Hoc luc trung binh");
        break;
    case 2:
        Console.WriteLine("Hoc luc kha");
        break;
    case 3:
        Console.WriteLine("Hoc luc gioi");
        break;
    default:
        Console.WriteLine("khong biet");
        break;
}

Console.ForegroundColor = ConsoleColor.Green;
HOCLUC hocluc1 = HOCLUC.Kha;
int so = (int)hocluc1;
Console.WriteLine(so);

hocluc1 = (HOCLUC)(8);
Console.WriteLine(hocluc1);
switch (hocluc1)
{
    case HOCLUC.Kem:
        Console.WriteLine("Hoc luc kem");
        break;
    case HOCLUC.TrungBinh:
        Console.WriteLine("Hoc luc trung binh");
        break;
    case HOCLUC.Kha:
        Console.WriteLine("Hoc luc kha");
        break;
    case HOCLUC.Gioi:
        Console.WriteLine("Hoc luc gioi");
        break;
    default:
        Console.WriteLine("khong biet");
        break;
}


enum HOCLUC { Kem = 2, TrungBinh = 4, Kha = 6, Gioi = 8 }

//struct
struct Product
{
    //du lieu
    public string name;
    public double price;
    //phuong thuc
    public string Info
    {
        get
        {
            return $"{name}, {price}";
        }
    }
    public string getInfo()
    {
        return $"Ten san pham: {name}, gia: {price} VND";
    }
    //constructor
    public Product(string _name, double _price)
    {
        name = _name;
        this.price = _price;
    }
}


