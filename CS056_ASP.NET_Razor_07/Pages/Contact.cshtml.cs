using CS056_ASP.NET_Razor_07.Models;
using CS056_ASP.NET_Razor_07.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CS056_ASP.NET_Razor_07.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ContactModel> _logger;

        public ContactModel(IWebHostEnvironment environment, ILogger<ContactModel> logger)
        {
            _environment = environment;
            _logger = logger;

        }

        [BindProperty(SupportsGet = true)]
        public CustomerInfo customerInfo { get; set; } = new CustomerInfo();

        //submit 1 file upload
        [BindProperty]
        [DataType(DataType.Upload)]
        [CheckFileExtensions(Extensions ="jpg,png,gif")]
        //[Required(ErrorMessage = "Chọn file upload")]
        [Display(Name = "File Upload")]
        public IFormFile? FileUpload { get; set; }

        //submit nhieu file upload
        [Display(Name = "File Uploads")]
        public IFormFile[] FileUploads { get; set; }

        public void OnGet()
        {
        }
        public string thongbao { get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                
                
                if(FileUpload != null)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "uploads", FileUpload.FileName);
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    FileUpload.CopyTo(filestream);
                    thongbao += "Du lieu phu hop - File đã được ghi đè thành công.";
                }

                foreach(var f in FileUploads)
                {
                    var filepath = Path.Combine(_environment.WebRootPath, "uploads", f.FileName);
                    using var filestream = new FileStream(filepath, FileMode.Create);
                    f.CopyTo(filestream);
                    thongbao += "Du lieu phu hop - File đã được ghi đè thành công.";
                }
            }
            else
            {
                thongbao = "Du lieu gui den khong phu hop";
            }
        }
    }
}
