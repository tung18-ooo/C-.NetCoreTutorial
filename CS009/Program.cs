using CS009;

internal class Program

{
    class Count()
    {
        public int c = 1;
    }
    static void dem(Count count)
    {
        count.c++;
    }
    private static void Main(string[] args)
    {
        int kq = tich(3, 4);
        Console.WriteLine(kq);

        static int tich(int a, int b)
        {
            int result = a * b;
            return result;
        }

        var resultTong = TinhToan.tong(123, 456);
        Console.WriteLine(resultTong);
        int x = 9;
        int y = 1;
        var sr = TinhToan.tong(x, y);
        Console.WriteLine(sr);

        float x1 = 9.2f;
        float y1 = 1.1f;
        var sr1 = TinhToan.tong(x1, y1);
        Console.WriteLine(sr1);

        static void name(string fname, string lname) //(string fname, string lname = "Tung")
        {
            string fullname = fname + " " + lname;
            Console.WriteLine($"Hello {fullname}");
        }


        name("Tung", "Hoang");
        name(lname: "Hoang", fname: "Tung");


        static void binhphuong(ref int x)
        {
            x = x * x;
            Console.WriteLine(x);
        }

        int a = 2;
        binhphuong(ref a);
        binhphuong(ref a);
        binhphuong(ref a);
        Console.WriteLine(a);

        static void binhphuong1(int x, out int kq)
        {
            kq = x * x;
        }

        int b = 2;
        binhphuong1(4, out b);
        Console.WriteLine(b);

       

        Count count = new Count();
        Console.WriteLine(count.c);

        dem(count);
        Console.WriteLine(count.c);
    }
   
}
