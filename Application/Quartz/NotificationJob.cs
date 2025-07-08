using Application.Quartz.Workers;
using Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quartz
{
    public class NotificationJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public NotificationJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var emailSender = scope.ServiceProvider.GetService<IEmailSender>();
                var serviceScopeFactory = scope.ServiceProvider.GetService<IServiceScopeFactory>();
                var userManager = scope.ServiceProvider.GetService<IUserService>();

                var users = await userManager!.GetUsers();

                foreach (var user in users)
                {

                   await SendEmail(emailSender!, user.Login, "Уведомление",
                                        $"Не забывайте проходить курс! Вы сейчас на {user.CurrentLevelNumber} уровне, осталось немного! :)");
                }
            }

        }

        public async Task SendEmail(IEmailSender emailSender, string to, string title, string message)
        {
            await emailSender.SendEmailAsync(to, title, message);
        }
    }
}
