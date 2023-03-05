using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


using HandsOn.PlanoContas.Core.Interfaces;
using HandsOn.PlanoContas.Core.Services;
using HandsOn.PlanoContas.Infrastructure.Auth.Authorization;
using HandsOn.PlanoContas.Infrastructure.Data.Contexts;
using HandsOn.PlanoContas.Infrastructure.Data.Repositories;

namespace HandsOn.PlanoContas.Infrastructure.IoC
{
    public  class ContainerDependencies
    {

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IChartAccountRepository, ChartAccountRepository>();

            services.AddScoped<IChartAccountService, ChartAccountService>();
            services.AddScoped<INextCodeService, NextCodeService>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();


        }

    }
}
