using CloudBanking.Core.Interfaces;
using CloudBanking.Core.Services;
using CloudBanking.Core.Utilities;
using CloudBanking.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudBanking.Api.Middelware
{
    public static class IoC
    {
        public static IServiceCollection AddService(IServiceCollection service)
        {
            service.AddTransient<IBankingRepository, BankingRepository>();
            service.AddTransient<IBankingService, BankingService>();
            service.AddScoped<ICalculator, Calculator>();

            return service;
        }
    }
}
