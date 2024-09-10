using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS043_EF4.Models
{
    public class Tag
    {
        //[Key]
        //[StringLength(20)]
        //public int TagId { set; get; }
        [Column(TypeName = "ntext")]
        public string Content { set; get; }
        [Key]
        public int TagId { get; set; }
    }
}
