// See https://aka.ms/new-console-template for more information
float a, b;

Console.WriteLine("Nhap a");
a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Nhap b");
b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("a + b = {0}", a+b);
Console.WriteLine("a - b = {0}", a-b);
Console.WriteLine("a * b = {0}", a*b);
Console.WriteLine("a / b = {0}", a/b);
Console.WriteLine("a % b = {0}", a%b);

float sum = 6 / 2 + 3 * 2;
Console.WriteLine(sum);

//gan
// += -= *= /= %=
int x = 10;
x += 2;
Console.WriteLine(x);

int x1 = 10;
x1 -= 2;
Console.WriteLine(x1);

int x2 = 10;
x2 *= 2;
Console.WriteLine(x2);

int x3 = 10;
x3 /= 2;
Console.WriteLine(x3);

int x4 = 10;
x4 %= 2;
Console.WriteLine(x4);

int x5 = 10;
x5++;
Console.WriteLine(x5);

int x6 = 10;
Console.WriteLine(x6);

int x7 = 10;
int z = 2 * x7++;
//z = 2 * 10
//-> 10++
Console.WriteLine(z); //z = 20
Console.WriteLine(x7); //=11

int x8 = 10;
int z1 = 2 * ++x8;
//x++
//-> z = 2 * x
Console.WriteLine(x8); //=11
Console.WriteLine(z1); //z = 22