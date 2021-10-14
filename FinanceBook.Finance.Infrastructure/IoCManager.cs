using FinanceBook.Finance.Application.Queries;
using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Infrastructure.Contexts;
using FinanceBook.Finance.Infrastructure.Contexts.Postgres;
using FinanceBook.Finance.Infrastructure.Queries;
using FinanceBook.Finance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceBook.Finance.Infrastructure
{
    public static class IoCManager
    {
        private const string DATABASE_URL = "DATABASE_URL";

        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IGroupWriteOnlyRepository, GroupRepository>();
            service.AddScoped<IGroupReadOnlyRepository, GroupRepository>();

            service.AddScoped<IOperationWriteOnlyRepository, OperationRepository>();
            service.AddScoped<IOperationReadOnlyRepository, OperationRepository>();

            service.AddScoped<IFinanceQueries, FinanceQueries>();
        }

        public static void AddContexts(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<PostgresContext>(opt =>
                opt.UseNpgsql(
                    new PostgresUriBuilder(configuration[DATABASE_URL])
                    .Build()
                ));
        }
    }
}
