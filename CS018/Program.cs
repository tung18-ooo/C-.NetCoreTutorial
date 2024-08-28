// See https://aka.ms/new-console-template for more information



A a = new A();
/*if (a != null)
{
    a.Hello();
}*/
a?.Hello();

int? age = null;
age = 10;
if (age.HasValue)
{
    int _age = age.Value;
    Console.WriteLine(_age);
}

if (age != null)
{
    int _age = (int)age;
    Console.WriteLine(_age);
}

class A
{
    public void Hello()
    {
        Console.WriteLine("Hello");
    }
}