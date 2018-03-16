/**
* @Project Name: $projectname$ ： EmailSender
* @Project Desc:
*
* @Machine Name: IVAN_ZHANG
* @Namespace Name: TestNinja.Mocking
* @Creation Time:  3/16/2018 10:47:09 AM
* @Author Ivan
* @Email  yf.eva.yifan@gmail.com
*
* @Change Log
*
* Version       Change Date               Changed By                  Changes
* ───────────────────────────────────────────────────────────────────────────────
* V0.01          3/16/2018 10:47:09 AM                    Ivan                  Initial
*
* Copyright (c) @ Yifan Zhang 2018.  All rights reserved.
*
*/

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TestNinja.Mocking
{
    public interface IEmailSender
    {
        void EmailFile(string emailAddress, string emailBody, string filename, string subject);
    }

    class EmailSender : IEmailSender
    {
        public void EmailFile(string emailAddress, string emailBody, string filename, string subject)
        {
            var client = new SmtpClient(SystemSettingsHelper.EmailSmtpHost)
            {
                Port = SystemSettingsHelper.EmailPort,
                Credentials =
                    new NetworkCredential(
                        SystemSettingsHelper.EmailUsername,
                        SystemSettingsHelper.EmailPassword)
            };

            var from = new MailAddress(SystemSettingsHelper.EmailFromEmail, SystemSettingsHelper.EmailFromName,
                Encoding.UTF8);
            var to = new MailAddress(emailAddress);

            var message = new MailMessage(from, to)
            {
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                Body = emailBody,
                BodyEncoding = Encoding.UTF8
            };

            message.Attachments.Add(new Attachment(filename));
            client.Send(message);
            message.Dispose();

            File.Delete(filename);
        }
    }
}
