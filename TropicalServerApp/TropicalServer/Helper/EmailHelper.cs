using System.Net;
using System.Net.Mail;

namespace TropicalServer.Helper
{
    public class EmailHelper
    {

        public static void SendEmail(string emailto, string msg)
        {
            MailMessage mail = new MailMessage("itlizeemailsender@gmail.com", emailto);
            mail.Body = msg;
            NetworkCredential mailAthentication = new NetworkCredential("itlizeemailsender@gmail.com", "Itlize2018");
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
            mailClient.Credentials = mailAthentication;
            mail.IsBodyHtml = true;
            mailClient.Send(mail);
        }

        public static string GetAccountResetLink(bool isUserName)
        {
            if (isUserName)
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        public static string GetEmailTemplate(string resetLink)
        {
            return "<html><head></head><body><p>Use this link to reset your password. The <a href ='" + resetLink +
                   "'>link</a> is only valid for 24 hours.</p></body><html>";
        }
    }
}