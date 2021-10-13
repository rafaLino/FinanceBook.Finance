using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using FinanceBook.Finance.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Infrastructure.Repositories
{
    public class GroupRepository : IGroupWriteOnlyRepository, IGroupReadOnlyRepository
    {

        private readonly PostgresContext _context;

        public GroupRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Group group, CancellationToken cancelationToken)
        {
            Entities.Group entity = new()
            {
                Id = group.Id,
                AccountId = group.AccountId,
                Name = group.Name,
                Description = group.Description,
                Category = group.Category
            };
            _context.Groups.Add(entity);
            await _context.SaveChangesAsync(cancelationToken);
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            Entities.Group entity = new()
            {
                Id = id
            };
            _context.Groups.Attach(entity);
            _context.Groups.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Group group, CancellationToken cancellationToken)
        {
            Entities.Group entity = new()
            {
                Id = group.Id,
                AccountId = group.AccountId,
                Name = group.Name,
                Description = group.Description,
                Category = group.Category
            };
            _context.Groups.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Group> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity is null ?
                default :
                Group.Load(entity.Id, entity.AccountId, entity.Name, entity.Description, entity.Category);
        }
    }
}
