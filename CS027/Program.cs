// See https://aka.ms/new-console-template for more information

/*//Queue
Queue<string> cachoso = new Queue<string> ();
cachoso.Enqueue ("Ho so 1");
cachoso.Enqueue("Ho so 2");
cachoso.Enqueue("Ho so 3");

foreach (var hs in cachoso)
{
    Console.WriteLine(hs);
}

var hoso = cachoso.Dequeue ();
Console.WriteLine($"Xu ly ho so: {hoso} - {cachoso.Count}");
 hoso = cachoso.Dequeue();
Console.WriteLine($"Xu ly ho so: {hoso} - {cachoso.Count}");
 hoso = cachoso.Dequeue();
Console.WriteLine($"Xu ly ho so: {hoso} - {cachoso.Count}");
*/

/*//Stack
Stack<string> hangghoa = new Stack<string>();
hangghoa.Push("mat hang 1");
hangghoa.Push("mat hang 2");
hangghoa.Push("mat hang 3");
hangghoa.Push("mat hang 4");

var mathang = hangghoa.Pop();
Console.WriteLine($"Boc do: {mathang}");
mathang = hangghoa.Pop();
Console.WriteLine($"Boc do: {mathang}");
mathang = hangghoa.Pop();
Console.WriteLine($"Boc do: {mathang}");
*/

/*//LinkedList

LinkedList<string> cacbaihoc = new LinkedList<string> ();
var bh1 = cacbaihoc.AddFirst ("Bai hoc 1");
var bh3 = cacbaihoc.AddLast ("Bai hoc 3");
LinkedListNode<string> bh2 = cacbaihoc.AddAfter(bh1,"Bai hoc 2");
cacbaihoc.AddLast("Bai hoc 4");
cacbaihoc.AddLast("Bai hoc 5");

*//*foreach(var data in cacbaihoc)
{
    Console.WriteLine(data);
}*//*

var node = bh2;
Console.WriteLine(node.Value);

node = node.Next;
Console.WriteLine(node.Value);

node = node.Previous;
Console.WriteLine(node.Value);
node = node.Previous;
Console.WriteLine(node.Value);
node = node.Previous;
if (node != null)
Console.WriteLine(node.Value);
Console.WriteLine();


var node1 = cacbaihoc.Last;
while(node1 != null){
    Console.WriteLine(node1.Value);
    node1 = node1.Previous;
}*/


/*//Dictionary

Dictionary<string, int> sodem = new Dictionary<string, int>()
{
    ["one"] = 1,
    ["two"] = 2,
};
//them hoac cap nhat
sodem["three"] = 3;
sodem.Add("four", 4);

var keys = sodem.Keys;
foreach (var k in keys)
{
    var value = sodem[k];
    Console.WriteLine($"{k} - {value}");
}
Console.WriteLine();

foreach (KeyValuePair<string,int> item in sodem)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}*/


//HashSet

HashSet<int> set1 = new HashSet<int>(){1,2,3,4,5,6,7 };
HashSet<int> set2 = new HashSet<int>(){8,9,1,2,3,10 };
set1.Add(11);
set1.Remove(7);

/*set1.UnionWith(set2);
foreach (int i in set1)
{
    Console.WriteLine(i);
}*/

Console.WriteLine();
set1.IntersectWith(set2);
foreach (int i in set1)
{
    Console.WriteLine(i);
}