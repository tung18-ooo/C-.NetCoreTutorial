using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS015
{
    public partial class Product
    //partial: chia nho cac file
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string GetInfo()
        {
            return $"{Name} / {Price} {Description}";
        }

        
    }
}
