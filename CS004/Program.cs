// See https://aka.ms/new-console-template for more information

bool isOnline;
int a,b;
Console.WriteLine("Nhap a: ");
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Nhap b: ");
b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"a == b ==> { a == b}");
Console.WriteLine($"a != b ==> { a != b}");
Console.WriteLine($"a > b ==> {a > b}");
Console.WriteLine($"a >= b ==> { a >= b}");
Console.WriteLine($"a < b ==> {a < b}");
Console.WriteLine($"a <= b ==> {a <= b}");

// && || !
bool kq;
bool x = true;
bool y = true;
//va &&
kq = x && y;
Console.WriteLine(kq);

//hoac
kq = x || y;
Console.WriteLine(kq);

//phu dinh !
kq = !x;
Console.WriteLine(kq);

kq = !(x || y);
Console.WriteLine(kq);

