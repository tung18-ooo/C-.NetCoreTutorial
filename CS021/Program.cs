// See https://aka.ms/new-console-template for more information

/*
 Lambda - Anonymous function
1)
(tham_so) = bieu_thuc;

2)
(tham_so) => {
    cac-bieu-thuc;
    return bieu_thuc_tra-ve;
}

 */

Action<string> thongbao;
thongbao = (string s) => Console.WriteLine(s);  // ~delegate void KIEU(string s) = Action<string>

for (int i = 0; i < 5; i++)
{
    thongbao?.Invoke("Hello");
}

Action thongbao1;
thongbao1 = () => Console.WriteLine("Helloo");
thongbao1?.Invoke();

Action<string, string> welcome = (string msg, string name) => Console.WriteLine(msg + " " + name);
welcome?.Invoke("Hallo", "HoangTung");

Action<string, string> wlc = (msg, name) => Console.WriteLine(msg + " " + name);
wlc?.Invoke("Hallo", "Tung");


Action<string, string> wc = (msg, name) =>
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(msg + " " + name);
    Console.ResetColor();
};

wc?.Invoke("Hallo", "Tung");

Func<int, int, int> tinhtoan;
tinhtoan = (int a, int b) =>
{
    int kq = a + b;
    return kq;
};
Console.WriteLine(tinhtoan.Invoke(5, 6));


int[] arr = { 2, 4, 8, 11, 52, 3, 16, 38, 22, 89 };
var kq = arr.Select((int x) =>
{
    return Math.Sqrt(x);
});
foreach (var rs in kq)
{
    Console.WriteLine(rs);
}

Console.WriteLine();

arr.ToList().ForEach(
        (x) =>
        {
            if (x % 2 != 0)
            {
                Console.WriteLine(x);

            }
        });

Console.WriteLine();

var kq1 = arr.Where(x => x % 4 == 0);
foreach (var item in kq1)
{
    Console.WriteLine(item);
}
Console.WriteLine();

var kq2 = arr.Where(
    (x) =>
    {
        return x >= 10 && x <= 40;
    });
foreach (var item in kq2)
{
    Console.WriteLine(item);
}
/*(int a, int b) =>
{
    int kq = a + b;
    return kq;
}*/