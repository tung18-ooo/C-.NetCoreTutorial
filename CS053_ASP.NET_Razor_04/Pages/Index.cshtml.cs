using CS053_ASP.NET_Razor_04.Pages.Shared.Components.MessagePage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS053_ASP.NET_Razor_04.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

      /*  public IActionResult OnGet()
        {
            //PageModel : Partial, ViewComponent
            //Controller : PartialView, ViewComponent

            //return Partial("_Message");
            return ViewComponent("ProductBox",false);
        }*/

        public IActionResult OnPost()
        {
            var username = this.Request.Form["username"];
            var mess = new MessagePage.Message();
            mess.title = "thong bao";
            mess.htmlcontent = $"cam on {username} da gui thong tin";
            mess.secondwait = 7;
            mess.urlredirect = Url.Page("Privacy");
            return ViewComponent("MessagePage",mess);
        }
    }
}
