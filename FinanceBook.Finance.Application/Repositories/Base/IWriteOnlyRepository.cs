using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Repositories
{
    public interface IWriteOnlyRepository<T> where T : class
    {
        Task SaveAsync(T entity, CancellationToken cancelationToken);

        Task RemoveAsync(Guid id, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
