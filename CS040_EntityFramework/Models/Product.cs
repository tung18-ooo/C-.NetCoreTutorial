using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS040_EntityFramework.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required] //not null
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string Provider {  get; set; }
        public void PrintInfo() => Console.WriteLine($"{Id} - {ProductName} - {Provider}");
    }
}
