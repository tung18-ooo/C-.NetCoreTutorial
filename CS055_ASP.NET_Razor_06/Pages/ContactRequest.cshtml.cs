using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS055_ASP.NET_Razor_06.Pages
{
    public class ContactRequestModel : PageModel
    {
        public string UserId { get; set; } = "ID User ...";
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
        }
    }
}
