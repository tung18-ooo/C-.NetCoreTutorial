// See https://aka.ms/new-console-template for more information

//hang so
Console.WriteLine($"So Pi: {Math.PI}, E: {Math.E}");
//max min
Console.WriteLine($"{Math.Max(5,6)}");
Console.WriteLine($"{Math.Min(5,6)}");
double a = 0.1, b = 0.111, c = -2.34;
Console.WriteLine($"{Math.Max(Math.Max(a, b),c)}");

//abs: tri tuyet doi, Sign: = 0 neu a = 0, = -1 neu a < 0, = 1 neu a > 0
Console.WriteLine($"Tri tuyet doi: {Math.Abs(-23)}");

//luong giac
//Sin,cos,tan, Asin, acos, atan
Console.WriteLine($"Sin: {Math.Sin(Math.PI/4)}"); //rad
double deg = 60;
//Pi == 180
//do = (pi * x) / 180
double rad =  Math.PI * deg / 180;
Console.WriteLine($"Sin: {Math.Sin(rad)}");

for (int i = 0; i <= 90; i++)
{
    double radian = Math.PI * i / 180;

    Console.WriteLine($"Sin {i} (deg): {Math.Sin(radian)}");

}

//sqrt: luy thua
//Sqrt(a), Pow(a,b), Log(a), Log10(a)
Console.WriteLine($"Can bac 2: {Math.Sqrt(4)}");
Console.WriteLine($"Luy thua: {Math.Pow(2,3)}"); // 2^3
Console.WriteLine($"Log: {Math.Log(5)}");

//round: lam tron
Console.WriteLine($"Lam tron (round) 5.4: {Math.Round(5.4)}");
Console.WriteLine($"Lam tron (round) 5.6: {Math.Round(5.6)}");

//Ceiling: lam tron len
Console.WriteLine($"Ceiling 5.1: {Math.Ceiling(5.1)}");
//Floor: lam tron xuong
Console.WriteLine($"Floor 5.9: {Math.Floor(5.9)}");

//Truncate: cat di phan thap phan
Console.WriteLine($"Truncate 5.5: {Math.Truncate(5.5)}");
