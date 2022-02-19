using FinanceBook.Finance.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Repositories
{
    public interface IOperationWriteOnlyRepository : IWriteOnlyRepository<Operation>
    {
        Task SaveAsync(IEnumerable<Operation> operations, CancellationToken cancelationToken);
    }
}
