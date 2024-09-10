using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS041_EF2.Models
{
    [Table("Product")]
    public class Product
    {
        //[Key] == entity.HasKey(p => p.Id);  
        public int Id { get; set; }
        [Required] //not null
        [StringLength(50)]
        [Column("Tensanpham",TypeName ="ntext")]  // Column("Tensanpham")  ==  HasColumnName("title");
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        /*public int? CateId {  get; set; }
        //Foreign key
        [ForeignKey("CateId")]
        [Required]*/

        public int CateId { get; set; }

        //Reference Navigation (Foreign key -> (1 - nhieu)
        //Foreign key
        //[ForeignKey("CateId")]
        public virtual Category Category { get; set; } //Fk -> Pk



        /* public int? CateId2 { get; set; }
         //Reference Navigation (Foreign key -> (1 - nhieu)
         //Foreign key
         [ForeignKey("CateId2")]
         [InverseProperty("Products")]
         public virtual Category Category2 { get; set; } //Fk -> Pk*/

        public int? CateId2 { get; set; }
        //Reference Navigation (Foreign key -> (1 - nhieu)
        //Foreign key
        //[ForeignKey("CateId2")]
        //[InverseProperty("Products")]  ==  WithMany(p => p.Products)
        public virtual Category Category2 { get; set; }




        public void PrintInfo() => Console.WriteLine($"{Id} - {Name} - {Price} - {CateId}");
    }
}
