using Autotests.TestAQA1.Interfaces.Email;

namespace Autotests.TestAQA1.Services
{
    public class UserNotifier
    {
        private readonly IEmailSender  emailSender;
        public UserNotifier(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        
        public void Notify(int userId)
        {
            emailSender.Send(
                "user@mail.com",
                $"Hello, user {userId}!");
        }
    }
}
