// See https://aka.ms/new-console-template for more information


static int Tong(int a, int b) => a + b;
static void Sum(int a, int b, ShowLog log)
{
    int kq = a + b;
    log?.Invoke($"Sum: {kq}");
}
static int Hieu(int a, int b) => a - b;
static void Sub(int a, int b, ShowLog log)
{
    int kq = a - b;
    log?.Invoke($"Sub: {kq}");
}

static void Info(string s)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(s);
    Console.ResetColor();
}

static void Warning(string s)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(s);
    Console.ResetColor();
}

ShowLog log = null;
log = Info;
log("Hello");
log.Invoke("Xin chao");

ShowLog log2 = null;
log2 = Info;
if (log2 != null)
{
    /*log2("Hello from log2");
    log2.Invoke("Xin chao log2");*/
    log2?.Invoke("Hello from log2");
}

log2 = Warning;
log2?.Invoke("Hello from log2");

ShowLog log3 = null;
Console.WriteLine();
log3 += Info;
log3 += Warning;
log3?.Invoke("Hello");

Console.WriteLine();

//Action, Func : delegate, generic
Action action; // ~ delegate void Kieu(khong co tham so);
Action<string, int> action1; // ~ delegate void Kieu(string a, int b);


Action<string> action2; //~delegate void Kieu(string a);

action2 = Warning; //or Info

action2?.Invoke("Hello");

//Kieu1 f1;
Func<int> f1; //~ delegate int Kieu1();
Func<string, double, string> f2; // ~ delegate string Kieu1(string a, double b); 
//Func<tham so, tham so, kieu tra ve>   

Console.WriteLine();
Func<int, int, int> tinhtoan;
int a = 10;
int b = 5;

tinhtoan = Tong;
Console.WriteLine($"Tong la {tinhtoan(a,b)}");
tinhtoan = Hieu;
Console.WriteLine($"Hieu la {tinhtoan(a,b)}");

Console.WriteLine();
Sum(a, b, Info);
Sub(a, b, Warning);
public delegate void ShowLog(string message);

delegate int Kieu1();

