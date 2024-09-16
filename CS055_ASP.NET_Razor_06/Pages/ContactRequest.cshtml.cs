using CS055_ASP.NET_Razor_06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CS055_ASP.NET_Razor_06.Pages
{
    public class ContactRequestModel : PageModel
    {
        [BindProperty]
        public UserContact userContact { get; set; } = new UserContact();
        /*
         * //[BindProperty(SupportsGet = true)] //ho tro Get
        [BindProperty]
        [Display(Name = "Id của bạn")]
        [Range(1,100,ErrorMessage ="Nhap sai")]
        public int UserId { get; set; }
        [BindProperty]
        [Display(Name = "Ten nguoi dung")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Tên người dùng phải từ 6 đến 20 ký tự")]
        public string UserName { get; set; }
        [BindProperty]
        [Display(Name = "Email của bạn")]
        [EmailAddress(ErrorMessage = "Email sai dinh dang")]
        public string Email { get; set; }
        */
        public double Tong(double a, double b)
        {
            return a + b;
        } 

        private readonly ILogger<ContactRequestModel> _logger;
        public ContactRequestModel(ILogger<ContactRequestModel> logger)
        {
            _logger = logger;
            _logger.LogInformation("Init contact...");
        }
        public void OnGet()
        {
            Console.WriteLine(this.userContact.Email);
        }
    }
}
