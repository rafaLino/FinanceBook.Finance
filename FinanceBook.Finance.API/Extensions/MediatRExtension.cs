using FinanceBook.Finance.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinanceBook.Finance.API.Extensions
{
    /// <summary>
    /// mediatr and fluent validation setups
    /// </summary>
    public static class MediatRExtension
    {
        private const string APPLICATION_ASSEMBLY_NAME = "FinanceBook.Finance.Application";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediatrFluentValidation(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load(APPLICATION_ASSEMBLY_NAME);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddSingleton(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }
    }
}
