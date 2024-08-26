using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS010_OOP
{
    public class Weapon
    {
        //DU LIEU
        public string name = "Ten vu khi"; //default is private


        int damage = 0;
        //phuong thuc khoi tao
        public Weapon()
        {
            damage = 1;
        }

        public Weapon(string name, int _damage)
        {
            damage = _damage;
            this.name = name;
        }

        public Weapon(string abc)
        {
            Console.WriteLine(abc);
        }

        //Phuong thuc
        public void setupDamage(int damage)
        {
            this.damage = damage;
            //this - ref
            Weapon ac;
            ac = this;
        }

        public void Attack()
        {
            Console.Write(this.name + ": \t");
            for (int i = 0; i < damage; i++)
            {
                Console.Write(" * ");
            }
            Console.WriteLine();
        }

        //Thuoc tinh (get,set)
        public int Damage
        {
            //cau lenh
            set 
            {
                damage = value;
            }
            //truy cap
            get
            {
                return 100;
            }
        }

        public string Noisanxuat { set; get; }

    }
}
