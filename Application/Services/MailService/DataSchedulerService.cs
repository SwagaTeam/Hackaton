using Application.Quartz;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MailService
{
    public class DataSchedulerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataSchedulerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                await DataScheduler.Start(serviceProvider);
            }
            await Task.CompletedTask;
        }
    }
}
