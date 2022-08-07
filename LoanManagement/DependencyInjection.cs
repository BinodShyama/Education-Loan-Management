using LoanManagement.Domain.Entities;
using LoanManagement.Helpers.Activity;
using LoanManagement.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISelectListService, SelectListService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<INepaliDateService, NepaliDateService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IStatus, Status>();
            services.AddTransient<IActivity, Activity>();
            services.AddTransient<IChequePrint, ChequePrint>();
            SeedAccountsData.Initialize(services.BuildServiceProvider().GetService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();
            return services; }

    }
}
