// See https://aka.ms/new-console-template for more information
using System.Text;

//DriveInfo drive = new DriveInfo("/");

/*//DriveIn
var drives = DriveInfo.GetDrives();
foreach(var drive in drives)
{

Console.WriteLine($"Dirve: {drive.Name}");
Console.WriteLine($"Dirve Type: {drive.DriveType}");
Console.WriteLine($"Label: {drive.VolumeLabel}");
Console.WriteLine($"Format: {drive.DriveFormat}");
Console.WriteLine($"Size: {drive.TotalSize}");
Console.WriteLine($"Free: {drive.TotalFreeSpace}");
Console.WriteLine("-----------------");
}*/

/*//Directory
using static System.Net.Mime.MediaTypeNames;

string path = $"D:\\C#\\repos\\dotnetTutorial\\CS028\\obj";
//Directory.CreateDirectory(path); //D:\C#\repos\dotnetTutorial\CS028\bin\Debug\net8.0
//Directory.Delete(path, true);

var files = Directory.GetFiles(path);

foreach (var file in files)
{
    Console.WriteLine(file);
}
Console.WriteLine("--------");
var directories = Directory.GetDirectories(path);

foreach (var directory in directories)
{
    Console.WriteLine(directory);
}
Console.WriteLine("--------");

if (Directory.Exists(path))
{
    Console.WriteLine($"{path} - ton tai");
}
else
{
    Console.WriteLine($"{path} - khong ton tai");
}

Console.WriteLine("-----------");

ListFileDirectory(path); //doc cac file, thu muc trong duong dan cho trc



static void ListFileDirectory(string path)
{
    string[] directories = Directory.GetDirectories(path);
    string[] files = Directory.GetFiles(path);
    foreach(var file in files)
    {
        Console.WriteLine(file);
    }
    foreach(var directory in directories)
    {
        Console.WriteLine(directory);
        ListFileDirectory(directory);// de quy
    }
}
*/



/*
//Path
Console.WriteLine(Path.DirectorySeparatorChar);
Console.WriteLine("-----------");

var pathh = Path.Combine("Dir1", "Dir2", "text.txt");
var path1 = Path.Combine("Dir1\\Dir2\\text.txt");
Console.WriteLine(Path.ChangeExtension(path1,"md"));
Console.WriteLine(Path.GetDirectoryName(path1));
Console.WriteLine(Path.GetExtension(path1));                
Console.WriteLine(Path.GetFileName(path1));
Console.WriteLine(Path.GetFullPath(path1));

var t = Path.GetRandomFileName();
Console.WriteLine(t);

var r = Path.GetTempFileName();
Console.WriteLine(r);
*/



//File



string filename = "test.txt";
string content = "Heloooo 1";
//string readfile = File.ReadAllText(filename);
//File.WriteAllText(filename, content);
//File.AppendAllText(filename, content);

//Console.WriteLine(readfile);

//File.Move("test.txt", "test1.txt"); //doi ten file

//File.Copy("test1.txt", "test2.txt");
//File.Delete("test2.txt");


/*var filestream = "data.dat";
using var stream = new FileStream(path: filestream, FileMode.OpenOrCreate);

//luu du lieu
byte[] buffer = { 1,2,3};
int offset = 0;
int count = 3;
stream.Write(buffer, offset, count);

//Doc du lieu
int sobyteduocdoc = stream.Read(buffer, offset, count);

//int, double -> bytes
int a = 1;
var byte_a = BitConverter.GetBytes(a);
//bytes -> int,double,...
BitConverter.ToInt32(byte_a, 0);
string s = "avvav";
var byte_s = Encoding.UTF8.GetBytes(s);
Encoding.UTF8.GetString(byte_s,0,10);*/


string path = "data.dat";
/*using var stream = new FileStream(path: path, FileMode.Create);
Product product = new Product()
{
    Id = 10,
    Price = 12345,
    Name = "San Pham 10",
};

product.Save(stream);*/

using var stream = new FileStream(path: path, FileMode.Open);
Product product = new Product();
product.Restore(stream);
Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public void Save(Stream stream)
    {
        //int -> 4 byte
        var bytes_id = BitConverter.GetBytes(Id);
        stream.Write(bytes_id, 0, 4);

        //double -> 8 bytes
        var bytes_price = BitConverter.GetBytes(Price);
        stream.Write(bytes_price, 0, 8);

        var bytes_name = Encoding.UTF8.GetBytes(Name);
        var bytes_length = BitConverter.GetBytes(bytes_name.Length);
        stream.Write(bytes_length, 0, 4);
        stream.Write(bytes_name, 0, bytes_name.Length);
    }
    public void Restore(Stream stream) {
    //int -> 4 bytes
    var bytes_id = new byte[4];
    stream.Read(bytes_id,0,4);
        Id = BitConverter.ToInt32(bytes_id, 0);

        //double -> 8 bytes
        var bytes_price = new byte[8];
        stream.Read(bytes_price, 0, 8);
        Price = BitConverter.ToDouble(bytes_price, 0);

        //name -> bytes
        var bytes_leng = new byte[4];
        stream.Read(bytes_leng, 0, 4);
        int leng = BitConverter.ToInt32(bytes_leng, 0);

        var bytes_name = new byte[leng];
        stream.Read(bytes_name,0,leng);
        Name = Encoding.UTF8.GetString(bytes_name,0,leng);
    }
}
