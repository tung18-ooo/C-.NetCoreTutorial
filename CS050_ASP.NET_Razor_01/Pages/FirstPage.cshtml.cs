
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _ASP.NET_Razor_01.Pages
{
    public class FirstPageModel : PageModel
    {
        public string title { get; set; } = "Day la trang cua htufn_1811";


        public void OnGet()
        {
            Console.WriteLine("Truy van Get");
            ViewData["mydata"] = "HoangTung 2024";
        }

        //GET, Url?handle=Xyz
        public void OnGetXyz()
        {
            Console.WriteLine("Truy van GetXyz");
            ViewData["mydata"] = "HoangTung 2021";

        }
        public string Welcome(string name)
        {
            return $"Welcome {name} to my Web";

        }
    }
}
