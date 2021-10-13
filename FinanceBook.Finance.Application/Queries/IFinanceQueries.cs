using FinanceBook.Finance.Application.Queries.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Queries
{
    public interface IFinanceQueries
    {
        Task<FinanceQueryResult> GetFinanceAsync(Guid accountId, CancellationToken cancellationToken);
    }
}
