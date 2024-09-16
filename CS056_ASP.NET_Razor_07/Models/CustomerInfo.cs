using CS056_ASP.NET_Razor_07.Binders;
using CS056_ASP.NET_Razor_07.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CS056_ASP.NET_Razor_07.Models
{
    public class CustomerInfo
    {
        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng.")]
        [StringLength(50,MinimumLength =2, ErrorMessage = "Tên khách hàng phải từ {2} đến {1} ký tự")]
        [Display(Name ="Ten khach hang")]
        [ModelBinder(BinderType =typeof(UserNameBinding))]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dịa chỉ Email.")]
        [Display(Name = "Dia chi Email")]
        [EmailAddress(ErrorMessage = "Email sai định dạng")]
        public string Email { get; set; }

        [Range(1900, 2100, ErrorMessage = "Năm sinh phải nằm trong khoảng {1} đến {2}")]
        [Display(Name = "Năm sinh khách hàng")]
        [SoChan]
        public int? YearOfBirth { get; set; }
    }
}
