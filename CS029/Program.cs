// See https://aka.ms/new-console-template for more information

/*Console.WriteLine("-----------");

DoSmth(5, "fd", ConsoleColor.Cyan);
Console.WriteLine("helooooo");
*/

//Task

//Thay the bang 2 phuong thuc Task o duoi
/*//Task t1 = new Task(Action); () => { };
Task t1 = new Task(
    () =>
    {
        DoSmth(4, "BRO", ConsoleColor.Blue);
    }
    );
//Task t2 = new Task(Action<Object>, Object); // (Object obj) => { }
Task t2 = new Task(
    (object obj) =>
{
    string tacvu = (string)obj;
    DoSmth(4, tacvu, ConsoleColor.Yellow);
},"HLE");
t1.Start();
t2.Start();*/

/*Task t1 = Task1();
Task t2 = Task2();

//asynchronous
DoSmth(4, "T1 Vo dich", ConsoleColor.Red);
DoSmth(1, "GenG", ConsoleColor.Yellow);
DoSmth(2, "DK", ConsoleColor.Cyan);

*//*t1.Wait();
t2.Wait();*//*
//Task.WaitAll(t1, t2);


await t1;
await t2;
Console.WriteLine("Press any key");*/

//Task<T>

//Task<string> t3 = new Task<string>(Func<string>); // () => {return string;}
/*Task<string> t3 = new Task<string>(() =>
{
    DoSmth(3, "T3", ConsoleColor.Green);
    return "Return From T3";
});


//Task<string> t3 = new Task<string>(Func<object,string>, string); // (object obj) => {return string;}
Task<string> t4 = new Task<string>((object obj) =>
{
    string t = (string)obj;
    DoSmth(5, "T4", ConsoleColor.White);
    return "Return From T4";
}, "T4");
t3.Start();
t4.Start();
*/

/*
Task<string> t3 = Task3();
Task<string> t4 = Task4();
DoSmth(4, "T5", ConsoleColor.Cyan);
*//*var kq3 = t3.Result;
var kq4 = t4.Result;*/


/*await t3;
await t4;*//*
var kq3 = await t3;
var kq4 = await t4;



Console.WriteLine(kq3);
Console.WriteLine(kq4);

Console.WriteLine("Press");
Console.ReadKey();*/



var task = GetWeb("https://www.youtube.com/");
DoSmth(2, "T1", ConsoleColor.Cyan);
var content = await task;

Console.WriteLine(content);
Console.ReadKey();


static void DoSmth(int seconds, string mgs, ConsoleColor color)
{

    string a = "adad";
    lock (Console.Out)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{mgs} ... Start");
        Console.ResetColor();
    }

    for (int i = 0; i <= seconds; i++)
    {
        lock (Console.Out)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs} {i}");
            Console.ResetColor();
        }

        Thread.Sleep(1000); //1s
    }
    lock (Console.Out)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"{mgs} ... End");
        Console.ResetColor();
    }

}



//asynchronous (multi thread)
/*static Task Task1()
{
    Task t1 = new Task(() =>
    {
        DoSmth(3, "BRO", ConsoleColor.Blue);
    });
    t1.Start();
    t1.Wait();
    Console.WriteLine("BRO da hoan thanh");
    return t1;
}

static Task Task2()
{
    Task t2 = new Task(
    (object obj) =>
    {
        string tacvu = (string)obj;
        DoSmth(5, tacvu, ConsoleColor.Yellow);
    }, "HLE");
    t2.Start();
    t2.Wait();
    Console.WriteLine("HLE hoan thanh");
    return t2;
}*/
/*
static Task<string> Task3()
{
    Task<string> _t3 = new Task<string>(
        () =>
        {
            DoSmth(3, "T3", ConsoleColor.Green);
            return "Return From T3";
        });
    _t3.Start();
    return _t3;
}

static Task<string> Task4()
{
    Task<string> _t4 = new Task<string>(
        (object obj) =>
        {
            string t = (string)obj;
            DoSmth(5, "T4", ConsoleColor.White);
            return "Return From T4";
        }, "T4");
    _t4.Start();
    return _t4;
}*/


//async / await
static async Task Task1()
{
    Task t1 = new Task(() =>
    {
        DoSmth(3, "BRO", ConsoleColor.Blue);
    });
    t1.Start();
    await t1;
    Console.WriteLine("BRO da hoan thanh");
}

static async Task Task2()
{
    Task t2 = new Task(
    (object obj) =>
    {
        string tacvu = (string)obj;
        DoSmth(5, tacvu, ConsoleColor.Yellow);
    }, "HLE");
    t2.Start();
    await t2;
    Console.WriteLine("HLE hoan thanh");
}

static async Task<string> Task3()
{
    Task<string> _t3 = new Task<string>(
        () =>
    {
        DoSmth(3, "T3", ConsoleColor.Green);
        return "Return From T3";
    });
    _t3.Start();
    await _t3;
    var kq = await _t3;
    Console.WriteLine("T3 hoan thanh");
    return kq;
}

static async Task<string> Task4()
{
    Task<string> _t4 = new Task<string>(
        (object obj) =>
    {
        string t = (string)obj;
        DoSmth(5, "T4", ConsoleColor.White);
        return "Return From T4";
    }, "T4");
    _t4.Start();    
    string kq = await _t4;
    Console.WriteLine("T4 hoan thanh");
    return kq;
}

static async Task<string> GetWeb(string url)
{
    HttpClient client = new HttpClient();
    Console.WriteLine("Bat dau tai");
    HttpResponseMessage kq =  await client.GetAsync(url);
    Console.WriteLine("Bat dau doc noi dung");
    string content = await kq.Content.ReadAsStringAsync();
    Console.WriteLine("Hoan thanh");

    return content;
}
