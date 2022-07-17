using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessment.Shared
{
 
    public class EmailSender
    {

        public void SendIt(List<string> adresses, string filePath)
        {
            foreach(string adress in adresses)
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("finalassessment@link.com");
                mail.To.Add(adress);
                mail.Subject = "En Fazla 5 Ticari Faliyet - " + DateTime.Now.ToShortDateString();
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "İyi Çalışmalar";
                mail.Body = htmlBody;
                Attachment attachment;
                attachment = new Attachment(filePath);
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("finalassessment@link.com", "123456789");
                SmtpServer.EnableSsl = true;
                SmtpServer.Timeout = int.MaxValue;
                SmtpServer.Send(mail);
            }
        

        }

    }
}
