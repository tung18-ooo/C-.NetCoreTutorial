// See https://aka.ms/new-console-template for more information

using CS025;

int a = 5;
int b = 2;


//Exception
try
{
    var c = a / b;        // phat sinh doi tuong lop Exception, ke thua Exception
    Console.WriteLine(c);
    int[] i = { 1, 2 };
    var x = i[5];
}
catch (DivideByZeroException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.StackTrace);
    Console.WriteLine(e.GetType().Name);
    Console.WriteLine("Khong duoc chia cho 0");
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Chi so mang khong phu hop");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Ket thuc");

string path = $"D:\\C#\\repos\\dotnetTutorial\\CS025\\1.txt";
//string path = null;
try
{
    string s = File.ReadAllText(path);
    Console.WriteLine(s);
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("File khong ton tai");
}
catch (ArgumentNullException e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine("Duong dan file phai khac null");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Console.WriteLine(e.GetType().Name);
}


try
{
Register("Tung", 11);
}
catch(MyException e){
    Console.WriteLine(e.Message);
}
catch(AgeException e)
{
    Console.WriteLine(e.Message);
    e.Detail();
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}


static void Register(string name, int age)
{
    if (string.IsNullOrEmpty(name))
    {
        /*Exception ex = new Exception("Name is not null");
        throw ex;*/

        throw new MyException();
    }
    if(age<18 || age > 100)
    {
        throw new AgeException(age);
        //throw new Exception("Tuoi phai >= 18 va <= 100"); 
    }
    Console.WriteLine($"Xin chao {name} {age}");
}