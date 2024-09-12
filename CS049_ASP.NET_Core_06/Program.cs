using CS049_ASP.NET_Core_06.MailUtils;
using Microsoft.Extensions.Hosting;

IConfiguration _configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();

builder.Services.Configure<MailUtils>(
    builder.Configuration.GetSection("MailSettings")
);
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<SendMailService>();

//var mailsettings = _configuration.GetSection("MailSettings");


var app = builder.Build();

/*
 * Mail Server - Smtp
 * SmtpClient
 * 
 * Server: Mail Transpoter (CentOS / Qmail, SendMail)

*/
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/TestSendMail", async context =>
    {

        var mess = await MailUtils.SendMail("tungqwe1802@gmail.com", "tungqwe1802@gmail.com", "test", "testingggg");
        await context.Response.WriteAsync(mess);
    });





    endpoints.MapGet("/TestGmail", async context =>
    {

        var mess = await MailUtils.SendGmail("tungqwe1802@gmail.com", "tungqwe1802@gmail.com", "test", "testingggg");
        await context.Response.WriteAsync(mess);
    });

    endpoints.MapGet("/TestSendMailService", async context =>
    {
        var sendMailService = context.RequestServices.GetService<SendMailService>();
        var mailContent = new MailContent();

        mailContent.To = "tungqwe1802@gmail.com";
        mailContent.Subject = "test email";
        mailContent.Body = "<h1>Test</h1><i>Testing</i>";

        var kq = await sendMailService.SendMail(mailContent);
        await context.Response.WriteAsync(kq);
    });
});
app.MapGet("/", () => "Hello World!");

app.Run();
