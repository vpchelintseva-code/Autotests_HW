using Autotests.TestAQA1.Interfaces.Email;
using Autotests.TestAQA1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Autotests.TestAQA1.Modules
{
    public static class EmailNotification
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<UserNotifier>();
            return services;
        }
    }
}
