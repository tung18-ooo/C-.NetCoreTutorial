using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS015
{
    public partial class Product
    {
        public ManualFactory manualFactory {  get; set; }
        public class ManualFactory
        {
            public string name { get; set; }
            public string addr { get; set; }
        }
        public string Description {  get; set; }
    }
}
