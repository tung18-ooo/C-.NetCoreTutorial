using CS023;


//extension method: phuong thuc mo rong


int[] arr = { 1, 3, 4, 6, 8, 6 };
int max = arr.Max();
Console.WriteLine(max);

string s = "Haloooooo";
s.Print(ConsoleColor.Green);
s.Print(ConsoleColor.Red);

"Xin".Print(ConsoleColor.Green);
"Xin".Print(ConsoleColor.Magenta);
"Xin".Print(ConsoleColor.Yellow);
"Xin".Print(ConsoleColor.Cyan);


double x = 2.5;
Console.WriteLine(x.BinhPhuong());
Console.WriteLine(x.Canbac2());
Console.WriteLine(x.Sin());
Console.WriteLine(x.Cos());
static class Expand
{
public static void Print(this string s, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(s);
}

}
