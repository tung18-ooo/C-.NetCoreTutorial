// See https://aka.ms/new-console-template for more information
using CS015;
using static CS015.MyNameSpace;

Class1.XinChao();
ABC.Class1.XinChao();

Product product = new Product();
product.Name = "Ipad";
product.Price = 10000;
product.Description = "Day la Ipad";

product.manualFactory = new Product.ManualFactory();
product.manualFactory.name = "Apple";
Console.WriteLine(product.GetInfo());
Console.WriteLine(product.manualFactory.name);