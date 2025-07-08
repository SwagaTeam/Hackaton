using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connString) 
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connString));

            //services.AddScoped<ITraineeRepository, TraineeRepository>();

            return services;
        }
    }
}
