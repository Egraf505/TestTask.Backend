using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Interfaces;

namespace TestTask.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ContactDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IContactDbContext>(provider =>
                provider.GetService<ContactDbContext>());
            return services;
        }
    }
}
