using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS041_EF2.Models
{
    public class CategoryDetail
    {
        public int CategoryDetailId { get; set; }
        public int UserId { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
        public int CountProduct { get; set; }
        public Category category { get; set; }
    }
}
