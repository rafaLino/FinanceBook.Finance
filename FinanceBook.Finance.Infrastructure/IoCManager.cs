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
            string connectionString = configuration["DATABASE_URL"];
            service.AddDbContext<PostgresContext>(opt =>
                opt.UseNpgsql(
                    new PostgresUriBuilder(connectionString)
                    .Build()
                ));
        }
    }
}
