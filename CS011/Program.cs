// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Text;

string loichao;// null
string name = "Tung";
loichao = "Hello";

string thongbao = loichao + " " + name;
thongbao += "!";
string hoc = "\\Hoc C# \"String\"";
// \t tab
// \n new line
// \r tro ve dau dong
// \r\n
Console.WriteLine(thongbao);
Console.WriteLine(hoc);

// @"" chuoi kky tu khong can xu ly
string test = @"khong can   /t xu 
ly  !
";
string quote = @"She said: ""Hello!""";
Console.WriteLine(test);
Console.WriteLine(quote);

int year = 2024;
Console.WriteLine($"This year is {year}, next year is {year + 1}");
int yearofbitrh = 2001;
string gender = "nam";
Console.WriteLine($@"
Ho ten: {name,10} 
Nam sinh: {yearofbitrh,10}
Gioi tinh: {gender,10}
");
Console.WriteLine(thongbao.Length);
Console.WriteLine(thongbao[4]);

Console.WriteLine();
for (int i = 0; i < thongbao.Length; i++)
{
    Console.WriteLine($"Chi so {i} la ky tu: {thongbao[i],2}");
}

foreach (var i in thongbao)
{
    Console.WriteLine(i);
}

string smth = "****  something like you    ";
Console.WriteLine(smth.Trim('*'));
//Console.WriteLine(info.TrimStart());
//Console.WriteLine(info.TrimEnd());

string smthg = "Something like you";
Console.WriteLine(smthg.ToUpper());
Console.WriteLine(smthg.ToLower());
Console.WriteLine(smthg.Replace("you", ("H")));
Console.WriteLine(smthg.Insert(0, "2024, "));
Console.WriteLine(smthg.Substring(10));
Console.WriteLine(smthg.Substring(10, 3));
Console.WriteLine(smthg.Remove(10));
Console.WriteLine(smthg.Remove(10, 4));

string[] chuoi = smthg.Split(' ');
foreach (var s in chuoi)
{
    Console.WriteLine(s);
}

string[] chuoi1 =
{
    "Everything",
    "will",
    "be",
    "daijoubu"
};
Console.WriteLine(string.Join(' ', chuoi1));


//StringBuilder
//loiich: tiet kiem bo nho

StringBuilder sb = new StringBuilder();
sb.Append("Something"); 
sb.Append(" "); 
sb.Append("like"); 
sb.Append(" ");
sb.Append("you");
sb.Replace("you", "H");

Console.WriteLine(sb);

