using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quartz
{
    public static class DataScheduler
    {

        public static async Task Start(IServiceProvider serviceProvider)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<JobFactory>()!;
            await scheduler.Start();

            IJobDetail jobDetailNotification = JobBuilder.Create<NotificationJob>().Build();
            ITrigger triggerNotification = TriggerBuilder.Create()
                .WithIdentity("NotificationTrigger", "default")
                .StartNow()
                .WithSimpleSchedule(x => x
                .WithIntervalInHours(24)
                //.WithIntervalInMinutes(1) для тестирования
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(jobDetailNotification, triggerNotification);
        }
    }
}
