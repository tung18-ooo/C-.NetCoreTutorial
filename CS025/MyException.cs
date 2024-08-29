using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS025
{
    public class MyException : Exception
    {
        public MyException() : base("Ten phai khac rong")
        {
        }
    }
    public class AgeException:Exception {
        public int age {  get; set; }
        public AgeException(int _age) : base("Tuoi khong phu hop")
        {
            age = _age;
        }
        public void Detail()
        {
            Console.WriteLine($"Tuoi = {age}, khong nam trong khoang 18 - 100");
        }
    }
}
