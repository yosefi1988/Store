
namespace WebApplicationStore.Controllers
{
    public class EmailSender : IEmailSender
    {
        public string Email { get; set; }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
