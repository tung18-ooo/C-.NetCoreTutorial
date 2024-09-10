using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS043_EF4.Models
{
    public class ArticleTag
    {
        [Key]
        public int  ArticleTagId { get; set; }
        public int TagId { get; set; } //fk

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        public int ArticleId {  get; set; } //fk
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }


    }
}
