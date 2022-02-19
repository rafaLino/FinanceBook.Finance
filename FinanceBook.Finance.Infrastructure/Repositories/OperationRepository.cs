using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using FinanceBook.Finance.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Infrastructure.Repositories
{
    public class OperationRepository : IOperationWriteOnlyRepository, IOperationReadOnlyRepository
    {
        private readonly PostgresContext _context;

        public OperationRepository(PostgresContext context)
        {
            _context = context;
        }



        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            Entities.Operation entity = new()
            {
                Id = id
            };

            _context.Operations.Attach(entity);
            _context.Operations.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task SaveAsync(Operation operation, CancellationToken cancelationToken)
        {
            Entities.Operation entity = new()
            {
                Id = operation.Id,
                GroupId = operation.GroupId,
                Name = operation.Name,
                Amount = operation.Amount,
                ReferenceDate = operation.ReferenceDate
            };

            _context.Operations.Add(entity);

            await _context.SaveChangesAsync(cancelationToken);
        }

        public async Task UpdateAsync(Operation operation, CancellationToken cancellationToken)
        {
            Entities.Operation entity = new()
            {
                Id = operation.Id,
                GroupId = operation.GroupId,
                Name = operation.Name,
                Amount = operation.Amount,
                ReferenceDate = operation.ReferenceDate
            };

            _context.Operations.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<Operation> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Operations.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity is null ?
                default :
                Operation.Load(entity.Id, entity.GroupId, entity.Name, entity.Amount, entity.ReferenceDate);
        }

        public async Task SaveAsync(IEnumerable<Operation> operations, CancellationToken cancelationToken)
        {
            IEnumerable<Entities.Operation> entities = operations
                .Select(operation => new Entities.Operation
                {
                    Id = operation.Id,
                    GroupId = operation.GroupId,
                    Name = operation.Name,
                    Amount = operation.Amount,
                    ReferenceDate = operation.ReferenceDate
                });

            _context.Operations.AddRange(entities);
            await _context.SaveChangesAsync(cancelationToken);
        }
    }
}
