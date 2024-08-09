
using System.Net;
using System.Net.Mail;

namespace WebApplicationStore.Repositories
{
    public class MessageSender : IMessageSender
    {
        public Task SendEmailAsync(string email, string subject, string message, bool isMessageHtml)
        {
            using (var client = new SmtpClient())
            {
                var credentials = new NetworkCredential()
                {
                    UserName = email,
                    Password = subject
                };
                client.Credentials = credentials;
                client.Host = "localhost";
                client.Port = 0;
                client.EnableSsl = true;

                using var emailMessage = new MailMessage()
                {
                    //To = { new MailAddress(toEmail) },
                    //From = new MailAddress(toEmail), // with @gmail.com
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml
                };
                client.Send(emailMessage);

            }
            return Task.CompletedTask;
        }
    }
}
