using System.Net.Mail;


namespace FinalAssessment.Shared
{
 
    public class EmailSender
    {

        //sending emails process
        public void SendIt(List<string> adresses, string filePath, string emailsubject)
        {
            foreach(string adress in adresses)
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("finalassessment@link.com");
                mail.To.Add(adress);
                mail.Subject = emailsubject;
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
