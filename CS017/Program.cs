// See https://aka.ms/new-console-template for more information

//anonymous - kieu du lieu vo danh
// Object - thuoc tinh - ReadOnly
// new {thuoctinh = giatri, thuoctinh1 = giatri1} 

var sp1 = new
{
    Ten = "Iphone 8",
    Gia = 1000,
    NamSx = 2017
};

List<Student> students = new List<Student>()
{
    new Student(){Name = "Nam",Namsinh = 2001, Noisinh = "Ha Noi"},
    new Student(){Name = "Dan",Namsinh = 2002, Noisinh = "Nam Dinh"},
    new Student(){Name = "Tung",Namsinh = 2001, Noisinh = "Ninh Binh"},
    new Student(){Name = "Hien",Namsinh = 2002, Noisinh = "Hoa Binh"},
};
var kq = from student in students
         where student.Namsinh == 2001 
         select new 
         {
             Ten = student.Name, 
             NamSinh = student.Namsinh, 
             NoiSinh = student.Noisinh 
         };
foreach(var student in kq)
{
    Console.WriteLine(student.Ten + " " + student.NamSinh + " " + student.NoiSinh );
}
var kq1 = from student in students
         where student.Name.Contains("i")
         select new
         {
             Ten = student.Name,
             NamSinh = student.Namsinh,
             NoiSinh = student.Noisinh
         };
foreach (var student in kq1)
{
    Console.WriteLine(student.Ten + " " + student.NamSinh + " " + student.NoiSinh);
}


// Dynamic - kieu du lieu dong

static void PrintInfo(dynamic obj)
{
    obj.Name = "TUNGG";
    obj.Hello();
}

Student stu1 = new Student();
PrintInfo(stu1);

class Student
{
    public string Name { get; set; }
    public int Namsinh { get; set; }
    public string Noisinh { get; set; }
    public void Hello()
    {
        Console.WriteLine(Name);
    }
}
