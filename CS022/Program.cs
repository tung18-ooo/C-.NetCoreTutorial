// See https://aka.ms/new-console-template for more information
//publisher -> class - phat su kien
//subsriber -> class - nhan su kien

Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine();
    Console.WriteLine("Exit");
};

UserInput user = new UserInput();
user.nhapSo += x => 
{
    Console.WriteLine($"Ban vua nhap so: {x}");
};
user.suKienNhapSo += (sender, e) =>
{
    Dulieunhap dulieunhap = (Dulieunhap)e;
    Console.WriteLine($"Ban vua nhap so: {dulieunhap.data}");
};
TinhCan tinhcan = new TinhCan();
tinhcan.Sub(user);
TinhBinhPhuong binhphuong = new TinhBinhPhuong();
binhphuong.Pow(user);



Console.WriteLine();

//event

TinhCan tinhcan1 = new TinhCan();
tinhcan1.Sub1(user);
TinhBinhPhuong binhphuong1 = new TinhBinhPhuong();
binhphuong1.Pow1(user);

user.Input();

public delegate void SuKienNhapSo(int x);

//publisher
class Dulieunhap : EventArgs
{
    public int data { get; set; }
    public Dulieunhap(int x) => data = x;
}
class UserInput
{
    public event SuKienNhapSo nhapSo;
    public event EventHandler suKienNhapSo; // ~ delegate void KIEU(object? sender, EvenArgs args)
    public void Input()
    {
        do
        {
            Console.WriteLine("Nhap so nguyen:");
            string s = Console.ReadLine();
            int i = int.Parse(s);
            //phat su kien
            nhapSo?.Invoke(i);
            Console.WriteLine();
            suKienNhapSo?.Invoke(this, new Dulieunhap(i));


        } while (true);
    }
}

class TinhCan
{
    public void Sub(UserInput input)
    {
        input.nhapSo += Can;
    }
    public void Can(int i)
    {
        Console.WriteLine($"Can bac 2 cua {i} la {Math.Sqrt(i)}");
    }
    public void Sub1(UserInput input)
    {
        input.suKienNhapSo += Can1;
    }
    public void Can1(object sender, EventArgs e)
    {
        Dulieunhap dulieu = (Dulieunhap)e;
        int i = dulieu.data;
        Console.WriteLine($"Event Can bac 2 cua {i} la {Math.Sqrt(i)}");
    }
}

class TinhBinhPhuong
{
    public void Pow(UserInput input)
    {
        input.nhapSo += BinhPhuong;
    }
    public void BinhPhuong(int i)
    {
        Console.WriteLine($"Binh phuong cua {i} la {Math.Pow(i, 2)}");
    }

    public void Pow1(UserInput input)
    {
        input.suKienNhapSo += BinhPhuong1;
    }
    public void BinhPhuong1(object sender, EventArgs e)
    {
        Dulieunhap dulieu = (Dulieunhap)e;
        int i = dulieu.data;
        Console.WriteLine($"Event Binh phuong cua {i} la {Math.Pow(i,2)}");
    }
}