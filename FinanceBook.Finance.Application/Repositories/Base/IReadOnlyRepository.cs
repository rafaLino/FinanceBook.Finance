using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Repositories
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
