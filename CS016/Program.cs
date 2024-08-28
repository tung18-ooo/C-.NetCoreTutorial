// See https://aka.ms/new-console-template for more information

//generic
static void Swap<T>(ref T x, ref T y)
{
    T t = x;
    x = y;
    y = t;
}

string a = "eerer";
string b = "ytyyty";

float c = 5.4f;
float d = 23f;

Console.WriteLine($"a = {a}, b = {b}");
Swap(ref a,ref b);
Console.WriteLine($"a = {a}, b = {b}");
Console.WriteLine();
Console.WriteLine($"c = {c}, d = {d}");
Swap<float>(ref c, ref d);
Console.WriteLine($"c = {c}, d= {d}");
Console.WriteLine();

Product<int> sp1 = new Product<int>();
sp1.setID(1);
sp1.PrintInf();

Product<string> sp2 = new Product<string>();
sp2.setID("SP02");
sp2.PrintInf();

List<int> list1 = new List<int>();
List<string> list2 = new List<string>();

//vao sau ra trc
Stack<int> stack = new Stack<int>();

//vao trc ra trc
Queue<int> q = new Queue<int>();

class Product<A>
{
    A ID;
    public void setID(A _id)
    {
        this.ID = _id;
    }
    public void PrintInf()
    {
        Console.WriteLine($"ID = {this.ID}");
    }
}
