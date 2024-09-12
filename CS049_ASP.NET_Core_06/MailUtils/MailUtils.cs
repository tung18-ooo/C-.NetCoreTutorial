using System.Net;
using System.Net.Mail;

namespace CS049_ASP.NET_Core_06.MailUtils
{
    public class MailUtils
    {
        //localhost
        public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("localhost");

            try
            {
                await smtpClient.SendMailAsync(message);
                return "gui mail thanh cong";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "gui mail khong thanh cong";
            }
        }

        public static async Task<string> SendGmail(string _from, string _to, string _subject, string _body /*string _gmail,string _pwd*/)
        {
            MailMessage message = new MailMessage(_from, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);

            using var smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.Credentials = new NetworkCredential("tungqwe1802@gmail.com", "aibiet18");
            smtpClient.EnableSsl = true;

            try
            {
                await smtpClient.SendMailAsync(message);
                return "gui mail thanh cong";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "gui mail khong thanh cong" + ex.Message;
            }
        }
    }
}
