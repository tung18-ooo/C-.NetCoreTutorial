// See https://aka.ms/new-console-template for more information


// Dependency Injection (DI)

/*
//Denpendency: phu thuoc

//class A la Dependency cua class B

var b = new ClassB();
b.ActionB();

class ClassA
{
    public void ActionA() => Console.WriteLine("Action in ClassA");
}
class ClassB
{

    public void ActionB()
    {
        Console.WriteLine("Action in ClassB");
        var a = new ClassA();
        a.ActionA();
    }

}
*/




// Dependency Injection library
// DI Container : ServiceCollection
// - Ho tro dang ky cac dich vu (lop)
// ServiceProvider -> Get Service | 

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var service = new ServiceCollection();
//Dang ky cac dich vu
// IClassC, ClassC, ClassC1

// Singleton
service.AddSingleton<IClassC, ClassC1>(); // dich vu IClassC la doi tuong cua ClassC, la doi tuong duy nhat

var provider = service.BuildServiceProvider();
//var classc = provider.GetService<IClassC>();
for (int i = 0; i < 5; i++)
{
    IClassC c = provider.GetService<IClassC>();
    Console.WriteLine(c.GetHashCode());
}

Console.WriteLine("--------------------------------------------------");
// Transient

service.AddTransient<IClassC, ClassC1>();
var provider1 = service.BuildServiceProvider();
//var classc = provider.GetService<IClassC>();
for (int i = 0; i < 5; i++)
{
    IClassC c = provider1.GetService<IClassC>();
    Console.WriteLine(c.GetHashCode());
}


Console.WriteLine("--------------------------------------------------");


// Scoped
service.AddScoped<IClassC, ClassC1>();
var provider2 = service.BuildServiceProvider();
//var classc = provider.GetService<IClassC>();
for (int i = 0; i < 5; i++)
{
    IClassC c = provider2.GetService<IClassC>();
    Console.WriteLine(c.GetHashCode());
}
using (var scope = provider2.CreateScope())
{
    var pro = scope.ServiceProvider;
    for (int i = 0; i < 5; i++)
    {
        IClassC c = pro.GetService<IClassC>();
        Console.WriteLine(c.GetHashCode());
    }
}

Console.WriteLine("--------------------------------------------------");


//ClassA
//IClassC, ClassC, ClassC1
//IClassB, ClassB, ClassB1, ClassB2

service.AddSingleton<ClassA, ClassA>();
/*service.AddSingleton<IClassB, ClassB2>(provider =>
{
    var b2 = new ClassB2(
        provider.GetService<IClassC>(),
        "Thuc hien trong B2");
    return b2;
});*/
service.AddSingleton(CreateB2);
service.AddSingleton<IClassC, ClassC1>();




var provider3 = service.BuildServiceProvider(); 
ClassA a = provider3.GetService<ClassA>();
a.ActionA();    


//or
static IClassB CreateB2(IServiceProvider provider)
{
    var b2 = new ClassB2(
        provider.GetService<IClassC>(),
        "Thuc hien trong b2"
        );
    return b2;
}
Console.WriteLine("--------------------------------------------------");


var services = new ServiceCollection();
services.AddSingleton<MyService>();

services.Configure<MyServiceOptions>((MyServiceOptions options) =>
{
    options.data1 = "Xin chao cac ban";
    options.data2 = 2024;
});

var pro1 =services.BuildServiceProvider();
var myservice = pro1.GetService<MyService>();
myservice.PrintData();



IConfigurationRoot configurationRoot;

ConfigurationBuilder configbuilder = new ConfigurationBuilder();
configbuilder.SetBasePath(Directory.GetCurrentDirectory());
configbuilder.AddJsonFile("cauhinh.json");

configurationRoot = configbuilder.Build();
var key1 = configurationRoot.GetSection("section1").GetSection("key1").Value;
var data1 = configurationRoot.GetSection("MyServiceOptions").GetSection("data1").Value;
Console.WriteLine(key1);
Console.WriteLine(data1);


var sectionMyServiceOptions = configurationRoot.GetSection("MyServiceOptions");
var services1 = new ServiceCollection();
services1.AddSingleton<MyService>();
services1.Configure<MyServiceOptions>(sectionMyServiceOptions);
var proOption = services1.BuildServiceProvider();
var myServiceOption = proOption.GetService<MyService>();
myServiceOption.PrintData();


//Inversion of Control (IoC) / Dependency Inversion

/*ClassC objC = new ClassC();
ClassB objB = new ClassB(objC);
ClassA objA = new ClassA(objB);

objA.ActionA(); 

class ClassC
{
    public void ActionC() => Console.WriteLine("Action in ClassC");
}

class ClassB
{
    // ClassB phu thuoc vao ClassC
    ClassC c_dependency;

    public ClassB(ClassC classc) => c_dependency = classc;
    public void ActionB()
    {
        Console.WriteLine("Action in ClassB");
        c_dependency.ActionC();
    }
}

class ClassA
{
    // ClassA phu thuoc vao ClassB
    ClassB b_dependency;

    public ClassA(ClassB classb) => b_dependency = classb;
    public void ActionA()
    {
        Console.WriteLine("Action in ClassA");
        b_dependency.ActionB();
    }
}*/


//ClassC objectC = new ClassC();
//IClassB objectB = new ClassB(objectC);
//ClassA objectA = new ClassA(objectB);

//objectA.ActionA();
//Console.WriteLine("------------------------------------");

//IClassC objC = new ClassC1();
//IClassB objB = new ClassB1(objC);
//ClassA objA = new ClassA(objB);

//objA.ActionA();


interface IClassB
{
    public void ActionB();
}

interface IClassC
{
    public void ActionC();
}

class ClassC : IClassC
{
    public void ActionC() => Console.WriteLine("Action in ClassC");
}

class ClassB : IClassB
{
    IClassC c_dependency;
    public ClassB(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("ClassB is created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in ClassB");
        c_dependency.ActionC();
    }
}
class ClassA
{
    IClassB b_dependency;
    public ClassA(IClassB classb)
    {
        b_dependency = classb;
        Console.WriteLine("ClassA is created");
    }
    public void ActionA()
    {
        Console.WriteLine("Action in ClassA");
        b_dependency.ActionB();
    }
}

//Inverted Dependency Graph

class ClassC1 : IClassC
{
    public ClassC1()
    {
        Console.WriteLine("ClassC1 is created");
    }
    public void ActionC()
    {
        Console.WriteLine("Action in C1");
    }
}

class ClassB1 : IClassB
{
    IClassC c_dependency;
    public ClassB1(IClassC classc)
    {
        c_dependency = classc;
        Console.WriteLine("ClassB1 is created");
    }
    public void ActionB()
    {
        Console.WriteLine("Action in B1");
        c_dependency.ActionC();
    }

}


/*
Horn horn = new Horn(7);
Car car = new Car(horn);
car.horn = horn;
car.Beep();
class Horn
{
    int level = 0;
    public Horn(int level)=> this.level = level;
    public void Beep() => Console.WriteLine("Beep Beep Beep ...");
}


class Car
{
    //Inject bang phuong thuc khoi tao
    public Horn horn { get; set; }
    public Car(Horn _horn)=> horn = _horn;
    public void Beep()
    {
        horn.Beep();
    }
}*/


class ClassB2 : IClassB
{
    IClassC c_dependency;
    string message;
    public ClassB2(IClassC classc, string msg)
    {
        c_dependency = classc;
        message = msg;
        Console.WriteLine("ClassB2 is created");
    }
    public void ActionB()
    {
        Console.WriteLine(message);
        c_dependency.ActionC();
    }
}

class MyService
{
    public string data1 { get; set; }
    public int data2 { get; set; }
    public MyService(IOptions<MyServiceOptions> options)
    {
        var _options = options.Value;
        data1 = _options.data1;
        data2 = _options.data2;
    }
    public void PrintData() => Console.WriteLine($"{data1} / {data2}");
}

class MyServiceOptions
{
    public string data1 { get; set; }
    public int data2 { get; set; }
    public void PrintData() => Console.WriteLine($"{data1} / {data2}");
}