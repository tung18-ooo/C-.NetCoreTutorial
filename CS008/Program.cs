// See https://aka.ms/new-console-template for more information
string[] ds;
ds = new string[3];
ds[0] = "Nguyen Van A";
ds[1] = "Nguyen Van B";
ds[2] = "Nguyen Van C";

Console.WriteLine(ds[0]);
Console.WriteLine(ds[1]);
Console.WriteLine(ds[2]);
Console.WriteLine();
for (int i = 0; i < 3; i++)
{
    Console.WriteLine(ds[i]);
}
Console.WriteLine();

int[] mangsonguyen;
string[] mang1 = {"Dien thoai","May tinh"};
double[] mang2 = {0.1, 2, 3.3};

mangsonguyen = new int[3] {1,2,3};


int[] numbers = { 1, 4, 7, 4, 3, 7, 34, 7 };
int sophantu = numbers.Length;
Console.WriteLine("For");
for (int i = 0;i < sophantu; i++)
{
    Console.WriteLine(numbers[i]);
}
Console.WriteLine();
Console.WriteLine("For nguoc");
for (int i = sophantu -1; i >= 0; i--)
{
    Console.WriteLine(numbers[i]);
}
Console.WriteLine();
Console.WriteLine("foreach");
foreach (var ab in numbers)
{
    Console.WriteLine(ab);
}

Console.WriteLine();
Console.WriteLine($"So phan tu: {numbers.Length}");
Console.WriteLine($"Chieu: {numbers.Rank}");
Console.WriteLine($"Min: {numbers.Min()}");
Console.WriteLine($"Max: {numbers.Max()}");
Console.WriteLine($"Sum: {numbers.Sum()}");

Array.Sort(numbers);
Console.WriteLine("Tang dan");
foreach(var item in numbers)
{
    Console.WriteLine(item);
}

Console.WriteLine();

Array.Reverse(numbers);
Console.WriteLine("Giam dan");
foreach (var item in numbers)
{
    Console.WriteLine(item);
}
Console.WriteLine();

//mang 2 chieu
/*
    hang 0 1 2
 cot
  0      2 3 4.5
  1      1 9 8   
 */
double[,] arrnum = new double[2, 3] { { 2, 3, 4.5 }, { 1, 9, 8 } };
//type[,] name = new type[row,column] {{value,value,...};{value,value,...}}
Console.WriteLine("matrix");
int row = 2;
int column = 3;
for(int i = 0; i < row; i++)
{
    for(int j = 0; j < column; j++)
    {
        Console.Write(arrnum[i,j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}