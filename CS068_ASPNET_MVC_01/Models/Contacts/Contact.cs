using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS068_ASPNET_MVC_01.Models.Contacts
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name ="Họ tên")]
        public string FullName { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [EmailAddress(ErrorMessage ="Phải là địa chỉ email")]
        [Display(Name = "Địa chỉ email")]
        public string Email { get; set; }
        public DateTime? DateSent { get; set; }
        [Display(Name = "Nội dung")]
        public string? Message { get; set; }
        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        [Phone(ErrorMessage ="Phải là số điện thoại")]
        public string Phone { get; set; }
        

    }
}
