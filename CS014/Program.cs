// See https://aka.ms/new-console-template for more information
    
//Tinh ke thua
/*
 A, B
B ke thua A
A - lop co so
B - lop ke thua

class B : A
{
    
}
Animal //lop cha
    - Legs
    - Weight
    - ShowLegs()
Cat : Animal // Cat ke thua Animal

 */

Cat cat = new Cat("smth");
cat.ShowLegs();
cat.Eat();

cat.ShowInfo();

B b;
C c;
D d;

b = new C();
//c = new B(); //error

d = new D();
c = d; //true
//d = c; //error


//sealed: lop bi niem phong
sealed class A { }


class B { }
class C : B { }
class D : C { }

//B -> C -> D
//1 bien tu lop co so co the gan' cac gia tri duoc tao ra tu lop ke thua
//1 bien tu lop ke thua kh the gan cac gia tri dc tao ra tu lop co so

class Animal
{
    public Animal() 
    {
        Console.WriteLine("Khoi tao Animal");
    }
    public Animal(string a)
    {
        Console.WriteLine($"Khoi tai Animal 1 - {a}");
    }
    public int Legs { get; set; }
    public int Weight { get; set; }
    public void ShowLegs()
    {
        Console.WriteLine($"Legs: {Legs}");
    }
}
class Cat : Animal
{
    public Cat(string a) : base(a)
    {
        this.Legs = 4;
        this.Food = "Mouse";
        Console.WriteLine("Khoi tao lop Cat");

    }
    public string Food;
    public void Eat()
    {
        Console.WriteLine(Food);
    }
    public new void ShowLegs()
    {
        Console.WriteLine($"Loai meo co {Legs} chan");
    }

    public void ShowInfo()
    {
        base.ShowLegs(); //goi showlegs o Animal
        ShowLegs(); //goi showlegs o Cat
    }
}
