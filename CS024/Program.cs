// See https://aka.ms/new-console-template for more information
CountNumber.Info();
Console.WriteLine(CountNumber.number);
CountNumber c1 = new CountNumber();
CountNumber c2 = new CountNumber();

c1.Count();
c1.Count();
CountNumber.Info();

Student s = new Student("Tung");
Console.WriteLine(s.name);


Vector v1 = new Vector(2,4);
v1.Info();
Vector v2 = new Vector(1,1);
v2.Info();

var v3 = v1 + v2;
var v4 = v1 + 10;
v3.Info();
v4.Info();

Vector v = new Vector(2,3);

v[0] = 5;
v[1] = 6;
v.Info();

v["toadox"] = 10;
v["toadoy"] = 11;
v.Info();
class CountNumber
{
    public static int number = 0;
    public static void Info()
    {
        Console.WriteLine($"So lan truy cap {number}");
    }
    public void Count()
    {
        CountNumber.number++;
    }
}


class Student
{
    public readonly string name; //chi doc
    public Student(string _name)
    {
        this.name = _name;
    }
}

class Vector
{
    double x, y;
    public Vector(double _x, double _y)
    {
        x = _x;
        y = _y;
    }
    public void Info()
    {
        Console.WriteLine($"x = {x}, y = {y}");
    }

    // vector <- vector + vector
    public static Vector operator+(Vector v1, Vector v2)
    {
        //return new Vector(v1.x + v2.x, v1.y + v2.y);

        double x = v1.x + v2.x;
        double y = v1.y + v2.y;
        Vector v = new Vector(x,y);
        return v;
    }
    public static Vector operator +(Vector v1, double value)
    {
        //return new Vector(v1.x + v2.x, v1.y + v2.y);

        double x = v1.x + value;
        double y = v1.y + value;
        Vector v = new Vector(x, y);
        return v;
    }

    //indexer [chi so]
    public double this[int i]
    {
        set
        {
            switch (i)
            {
                case 0:
                    x = value; break;
                case 1:
                    y = value; break;
                default:
                    throw new Exception("Chi so sai");
            }
        }
        get 
        {
            switch (i)
            {
                case 0:
                    return x;
                case 1:
                    return y;
                default:
                    throw new Exception("Chi so sai");
            }
        }
    }

    public double this[string s]
    {
        set
        {
            switch (s)
            {
                case "toadox":
                    x = value; break;
                case "toadoy":
                    y = value; break;
                default:
                    throw new Exception("Chi so sai");
            }
        }
        get
        {
            switch (s)
            {
                case "toadox":
                    return x;
                case "toadoy":
                    return y;
                default:
                    throw new Exception("Chi so sai");
            }
        }
    }
}