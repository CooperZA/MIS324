using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace cooperz_assign01.Utilities
{
    /// <summary>
    /// Sends an html email via wwu SMTP server
    /// server accepts email traffic only from yorktown
    /// </summary>
    public static class SendEmail
    {
        public static string Send(string ToEmail, string ToName, string FromEmail, string FromName, string Subject, string Body, bool IsHtml)
        {
            MailAddress toAddress = new MailAddress(ToEmail, ToName);
            MailAddress fromAddress = new MailAddress(FromEmail, FromName);
            MailMessage myMessage = new MailMessage(fromAddress, toAddress);

            myMessage.Subject = Subject;
            myMessage.Body = Body;
            myMessage.IsBodyHtml = IsHtml;

            // smtp server
            SmtpClient smtpClient = new SmtpClient("smtp.wwu.edu", 25);
            smtpClient.Timeout = 3000;
            try
            {
                smtpClient.Send(myMessage);
            }
            catch (Exception ex)
            {
                return "Error sending email to: " + ToEmail + ". " + ex.Message;
            }

            return "Email sent Successfully";
        }

        // generate header html for email
        public static string GenerateHeader()
        {
            string head = @"<html lang='en'> <head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>MVC Music Purchase</title> <style>body, h4{font - family: 'Helvetica Neue', Arial, Helvetica, sans - serif;}table{border: none;}td{padding: 5px; vertical - align: top;}.productImage{border: solid 1px black; box - shadow: 5px 5px 10px #a19b9b; margin: 15px 25px 15px 0; margin: 10px;}.productTitle{color: #033e5c; font - size: medium;}.itemsShipped td{padding: 10px;}.totals{margin - left: 40 %;}.totals td{padding: 2px;}.enhancement{display: none;}</style></head>";

            return head;
        }
    }
}