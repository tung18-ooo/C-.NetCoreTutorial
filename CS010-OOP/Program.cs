// See https://aka.ms/new-console-template for more information
using CS010_OOP;

class Student: IDisposable
{
    public string name;
    public Student(string name)
    {
        this.name = name;
        Console.WriteLine("Khoi tao: " + name);
    }
    ~Student()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Huy " + name);
        Console.ResetColor();
    }

    public void Dispose()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Huy (boi dispose)" + name);
        Console.ResetColor();
    }

}
public class Program
{
    public static void Test()
    {
       using Student sv = new Student("Ten");
        Console.WriteLine("1");
        Console.WriteLine("2");
        Console.WriteLine("3");

    }
    private static void Main(string[] args)
    {
        Weapon sungluc; //null
        sungluc = new Weapon();

        sungluc.name = "Sung luc";
        sungluc.setupDamage(5);

        //set
        sungluc.Damage = 6;
        //get
        Console.WriteLine(sungluc.Damage);

        sungluc.Noisanxuat = "VietNam";
        Console.WriteLine(sungluc.Noisanxuat);


        Weapon awp = new Weapon("Sung may", 15);
        sungluc.Attack();
        awp.Attack();


        /*Student student;
        for(int i = 0; i<= 30000;i++)
        {
            student = new Student("Student " + i);
            student = null;
        }

        GC.Collect();
        */

        using(Student s = new Student("Ten sinh vien"))
        {

        }

        Test();
    }
}