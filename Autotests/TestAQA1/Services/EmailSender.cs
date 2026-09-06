using Autotests.TestAQA1.Interfaces.Email;

namespace Autotests.TestAQA1.Services
{
    public class EmailSender : IEmailSender
    {
        public void Send(string to, string text)
        {
            Console.WriteLine($"Sending mail to {to}: {text}");
        }
    }
    
}
