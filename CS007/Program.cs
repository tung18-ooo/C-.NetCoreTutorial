// See https://aka.ms/new-console-template for more information

int i;

for (/*int*/ i =  0; i < 10; i++)
{
    Console.WriteLine(i);
    Console.WriteLine("Helloo");
}


for (i = 0, Console.WriteLine("Khoi tao"); i < 10; i++,Console.WriteLine("Cap nhat i"))
{
    Console.WriteLine(i);
}

i = 1;
for(; i <= 10;)
{
    Console.WriteLine($"3 x {i} = {3*i}");
    i++;
}

//while
i = 0;
while(i <= 10)
{
    Console.WriteLine($"3 x {i} = {3 * i}");
    i++;
}

i = 11;
do
{
    Console.WriteLine($"3 x {i} = {3 * i}");
    i++;
} while (i <= 10);

//break; continue;
i = 0;
while(i < 1000)
{
    Console.WriteLine(i);
    i++;
    if(i == 20)
        break;
}

for (i = 10; i <= 20; i++)
{
    if(i %2 != 0)
    continue;
    Console.WriteLine(i);
}