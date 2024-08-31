// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Net.Security;
using Utils;


//dotnet add package packageName --version xxx //add
//dotnet remove package Newtonsoft.Json        //remove
//dotnet restore


//tham chieu tu cs031 den utils
//dotnet add "D:\C#\repos\dotnetTutorial\CS031\CS031.csproj" reference "C:\Users\Admin\Desktop\Utils\Utils.csproj"

double a = 5464352184531878453;
var kq = ConvertMoneyToText.NumberToText(a);
Console.WriteLine(kq);
ConvertMoneyToText.Hello();
/*Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(2008, 12, 28);
product.Sizes = new string[] { "Small" };

string json = JsonConvert.SerializeObject(product);
Console.WriteLine(json);
// {
//   "Name": "Apple",
//   "Expiry": "2008-12-28T00:00:00",
//   "Sizes": [
//     "Small"
//   ]
// }


public class Product
{
    public string Name { get; set; }
    public DateTime Expiry { get; set; }
    public string[] Sizes { get; set; }
}
*/



/*string json = @"{
'Name': 'Bad Boys',
'ReleaseDate': '1995-4-7T00:00:00',
'Genres': [
'Action',
'Comedy'
]
}";

Movie m = JsonConvert.DeserializeObject<Movie>(json);
Console.WriteLine(m.Name);
Console.WriteLine(m.ReleaseDate.ToLongDateString());

public class Movie
{
    public string Name { get; set; }
    public DateTime ReleaseDate {  get; set; }
    public string[] Genres { get; set; }
}
*/

