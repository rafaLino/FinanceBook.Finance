using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Infrastructure.Contexts.Postgres
{
    public class PostgresUriBuilder
    {
        private NpgsqlConnectionStringBuilder _builder;
        public PostgresUriBuilder(string connectionString)
        {
            var databaseUri = new Uri(connectionString);
            var userInfo = databaseUri.UserInfo.Split(':');

            _builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Prefer,
                TrustServerCertificate = true,
                Pooling = true
            };
        }

        public string Build() => _builder.ToString();
    }
}
