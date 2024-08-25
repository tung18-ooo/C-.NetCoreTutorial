// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
    kieu_du_lieu Ten-bien;
ten_bien:
-a..z A..Z
- 0..9
- _
- khong bat dau bang so
 */
string studentName = "tung"; //chuoi
int studentAge1; //so nguyen
int _studentId;
char a; //1 ky tu
bool b; //true or false
sbyte c; //so nguyen, dung 8 bit bieu dien, (-128 den 127)
byte d; //so nguyen, 16 bit bieu dien, (0 den 255)
short f; //so nguyen, 16 bit, (0 den 65535)
long g; //so nguyen, 64 bit, (-9,223,372,036,854,775,808 den 9,223,372,036,854,775,807)
ulong h; //so nguyen, 64 bit, (0 den 18,446,744,073,709,551,615)
float i = 0.123456789f; //so thuc, 32 bit, 7 chu so
double k = 0.123456789; //so thuc, 364 bit, 15-16 decimal digits
decimal l=3.4444m; //so thuc, 128 bit

object o;
o = studentName;

double Pii = 3.14;
double hai_pi = 2 * Pii;
Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.White;
Console.WriteLine(hai_pi);
Console.ResetColor();
Console.WriteLine("Gia tri cua pi: ");
Console.ReadKey();
Console.WriteLine(Pii);
string hoten;
Console.Write("Nhap ho ten: ");
hoten = Console.ReadLine();
Console.WriteLine("Hello " + hoten);
Console.WriteLine($"Hello {hoten}");

float a1, b1;
string sinput;

Console.WriteLine("Hay nhap a:");
sinput = Console.ReadLine();
a1 = float.Parse(sinput);// 3,2

Console.WriteLine("Hay nhap b:");
sinput = Console.ReadLine();
b1 = float.Parse(sinput);

Console.WriteLine($"{a1} and {b1}");

const double Pi = 3.14;
Console.WriteLine(Pi);
