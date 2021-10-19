using FinanceBook.Finance.Application.Behaviours;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinanceBook.Finance.API.Extensions
{
    public static class MediatRExtension
    {
        private const string APPLICATION_ASSEMBLY_NAME = "FinanceBook.Finance.Application";
        public static void AddMediatrFluentValidation(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load(APPLICATION_ASSEMBLY_NAME);
            
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            services.AddFluentValidation(setup =>
            {
                setup.RegisterValidatorsFromAssembly(assembly);
            });
        }
    }
}
