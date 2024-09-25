Scaffolding has generated all the files and added the required dependencies.

However the Application's Startup code may require additional changes for things to work end to end.
Add the following code to the Configure method in your Application's Startup class if not already done:

        app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllerRoute(
            name : "areas",
            pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
        });



dotnet asp-codegenerator controller -name Contact -namespace CS068_ASPNET_MVC_01.Areas.Contact.Controllers -m CS068_ASPNET_MVC_01.Models.Contacts.Contact -udl -dc CS068_ASPNET_MVC_01.Models.AppDbContext -outDir Areas/Contact/Controllers/
