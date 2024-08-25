// See https://aka.ms/new-console-template for more information
int a;
Console.WriteLine("Nhap a: ");
a = Convert.ToInt32(Console.ReadLine());

//a % 2 == 0
if (a % 2 == 0)
{
    Console.WriteLine($"So {a} la so chan");
}
else
{
    Console.WriteLine($"So {a} la so le");
}

double diem;
Console.WriteLine("Nhap diem: ");
diem = double.Parse(Console.ReadLine());

if (diem <= 5)
{
    Console.WriteLine("Yeu");
}
else if (diem <= 6.5)
{
    Console.WriteLine("Trung binh");
}
else if (diem <= 8)
{
    Console.WriteLine("Kha");
}
else if (diem <= 10)
{
    Console.WriteLine("Gioi");
}
else
{
    Console.WriteLine("Diem khong hop le");
}

double x, y;
Console.WriteLine("So x:");
x = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("So y:");
y = Convert.ToDouble(Console.ReadLine());

double max;
if (x > y)
{
    max = x;
}
else
{
    max = y;
}
Console.WriteLine($"So lon nhat la {max}");

//or

double maximum = (x > y) ? x : y;
Console.WriteLine($"So lon nhat la {maximum}");


float m = 2, n = 3.5f, q = 4.4f;
float max1;
if (m > n)
{
    max1 = m;
    if (m > q)
    {
        max1 = m;
    }
    else 
    { 
        max1 = q;
    }
}
else
{
    max1 = n;
    if(n>q)
    {
        max1 = n;
    }
    else
    {
        max1 = q;
    }
}
Console.WriteLine($"So lon nhat la {max1}");
//or

float maximum1 = (m>n)?(m>q)?m:q:(n>q)?n:q;
Console.WriteLine($"So lon nhat la {maximum1}");



