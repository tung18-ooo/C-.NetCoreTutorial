// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Channels;

/*
int a = 1;

Type t1 = typeof(int);
var t2 = typeof(string);
var t3 = typeof(Array);

var t = a.GetType();

Console.WriteLine(t.FullName);

int[] a1 = {1,2,3};
Type type = a1.GetType(); //typeof(Array)
Console.WriteLine(type.FullName);


//GetProperties: tra ve cac thuoc tinh
Console.WriteLine("------------- Cac thuoc tinh ---------------");
type.GetProperties().ToList().ForEach( (PropertyInfo o) =>
{
    Console.WriteLine(o.Name);
});




//lay cac truong du lieu
Console.WriteLine("------------- Cac truong du lieu ---------------");
type.GetFields().ToList().ForEach((FieldInfo o) =>
{
    Console.WriteLine(o.Name);
});


//lay ve cac phuong thuc
Console.WriteLine("------------- Cac phuong thuc ---------------");
type.GetMethods().ToList().ForEach((MethodInfo o) =>
{
    Console.WriteLine(o.Name);
});


//lay cac phuong thuc khoi tao
Console.WriteLine("------------- Cac phuong thuc khoi tao ---------------");
type.GetConstructors().ToList().ForEach((ConstructorInfo o) =>
{
    Console.WriteLine(o.Name);
});
*/

/*
User user = new User()
{
    Name = "HoangTung",
    Age = 23,
    PhoneNumber = "0389132128",
    Email = "tungqwe1802@gmail.com",
};

var properties = user.GetType().GetProperties();
foreach (PropertyInfo property in properties)
{
    string name = property.Name;
    var value = property.GetValue(user);
    Console.WriteLine($"{name} : {value}");
}

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
*/


/*
//thuoc tinh bo sung Attribute
User user = new User()
{
    Name = "HoangTung",
    Age = 23,
    PhoneNumber = "0389132128",
    Email = "tungqwe1802@gmail.com",
};
var properties = user.GetType().GetProperties();
foreach (PropertyInfo property in properties)
{
    foreach(var attr in property.GetCustomAttributes(false))
    {
        MotaAttribute mota = attr as MotaAttribute;
        if(mota != null)
        {
            var value = property.GetValue(user);
            var name = property.Name;
            Console.WriteLine($"({name}) - {mota.Thongtinchitiet}: {value}");
        }
    }
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] //Mota duoc su dung o dau (class, property, method,...)
class MotaAttribute : Attribute
{
    public string Thongtinchitiet { get; set; }
    public MotaAttribute(string _thongtinchitiet)
    {
        Thongtinchitiet = _thongtinchitiet;
    }
}

[Mota("Lop chua thong tin ve User tren he thong")]
class User
{
    [Mota("Ten nguoi dung")]
    public string Name { get; set; }
    [Mota("Tuoi")]
    public int Age { get; set; }
    [Mota("So dien thoai")]
    public string PhoneNumber { get; set; }
    [Mota("Dia chi Email")]
    public string Email { get; set; }
    [Obsolete("Phuong thuc can thay the bang ShowInfo()")]
    public void PrintInfo() => Console.WriteLine(Name);
}

*/


User user = new User()
{
    Name = "tu",
    Age = 23,
    PhoneNumber = "0389132128",
    Email = "tungqwe1802gmail.com",
};

var result = new List<ValidationResult>();
ValidationContext context = new ValidationContext(user);
bool kq = Validator.TryValidateObject(user, context, result, true);
if (kq == false)
{
    result.ToList().ForEach(er =>
    {
        Console.WriteLine(er.MemberNames.First());
        Console.WriteLine(er.ErrorMessage);
    });
}

class User
{
    [Required(ErrorMessage = "Name phai thiet lap")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Ten phai dai tu 3 -100 ky tu")]
    public string Name { get; set; }
    [Range(18,80, ErrorMessage ="Ten phai tu 18 - 80")]
    public int Age { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
    [EmailAddress(ErrorMessage = "Dia chi email sai cau truc")]
    public string Email { get; set; }
}