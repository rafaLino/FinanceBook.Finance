using Microsoft.EntityFrameworkCore;

namespace FinanceBook.Finance.Infrastructure.Contexts
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {

        }
        public DbSet<Entities.Group> Groups { get; set; }

        public DbSet<Entities.Operation> Operations { get; set; }
    }
}
