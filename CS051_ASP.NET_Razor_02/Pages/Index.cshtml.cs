using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS051_ASP.NET_Razor_02.Pages
{
    public class IndexModel : PageModel
    {
        public string A {  get; set; } 

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.A = "OnGet qweqe"; 
        }
    }
}
