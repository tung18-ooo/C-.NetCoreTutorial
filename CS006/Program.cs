// See https://aka.ms/new-console-template for more information
int a;
Console.WriteLine("Nhap gia tri");
/**/
lai:
a = Convert.ToInt32(Console.ReadLine());

switch (a)
{
    case 0:
        Console.WriteLine("Gia tri bang 0");
        break;
    case 1:
        Console.WriteLine("Gia tri bang 1");
        break;
    case 2:
        Console.WriteLine("Gia tri bang 2");
        break;
    case 3:
        Console.WriteLine("Gia tri bang 3");
        break;
    case 4:
        Console.WriteLine("Gia tri bang 4");
        break;
    default: 
        Console.WriteLine("Hay thu so khac");
        goto lai; //chuyen huong thuc hien den 'lai'
        break;
}

switch (a)
{
    case 1:
    case 3:
        Console.WriteLine("a la so le");
        break;
    case 0:
    case 2:
    case 4:
        Console.WriteLine("a la so chan");
        break;
    default:
        goto lai;
        Console.WriteLine("Nhap so khac");
        break;
}

float x,y;
Console.WriteLine("Nhap x:");
x = float.Parse(Console.ReadLine());
Console.WriteLine("Nhap y:");
y = float.Parse(Console.ReadLine());

Console.WriteLine("Chon lenh");
Console.WriteLine("1) Tinh tong");
Console.WriteLine("2) Tinh hieu");
Console.WriteLine("3) Tinh tich");
Console.WriteLine("4) Tinh thuong");

/**/
L1:
char c = Console.ReadKey().KeyChar;
Console.WriteLine();
switch (c)
{
    case '1':
        Console.WriteLine($"Tong la {x+y}");
        break;
    case '2':
        Console.WriteLine($"Hieu la la {x - y}");
        break;
    case '3':
        Console.WriteLine($"Tich la {x * y}");
        break;
    case '4':
        Console.WriteLine($"Thuong la {x / y}");
        break;
    default:
        Console.WriteLine($"Nhap so khac");
        goto L1; //chuyen huong thuc hien den 'l1'
        break;
}