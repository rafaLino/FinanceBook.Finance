using FinanceBook.Finance.Application.Exceptions;
using FinanceBook.Finance.Application.Queries;
using FinanceBook.Finance.Application.Queries.Results;
using FinanceBook.Finance.Domain;
using FinanceBook.Finance.Domain.ValueObjects;
using FinanceBook.Finance.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Infrastructure.Queries
{
    public class FinanceQueries : IFinanceQueries
    {
        private readonly PostgresContext _context;

        public FinanceQueries(PostgresContext context)
        {
            _context = context;
        }

        public async Task<FinanceQueryResult> GetFinanceAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var groupEntities = await _context.Groups
                .Where(group => group.AccountId == accountId)
                .Include(g => g.Operations.Where(x => x.ReferenceDate.Month == DateTime.Now.Month))
                .ToListAsync(cancellationToken);

            if (!groupEntities.Any())
                throw new AccountHasNoGroupsException(accountId);

            var groups = groupEntities
                .Select(entity =>
                 Group.Load(
                     entity.Id,
                     entity.AccountId,
                     entity.Name,
                     entity.Description,
                     entity.Category,
                     entity.Operations?
                     .Select(op =>
                         Operation.Load(
                             op.Id,
                             op.GroupId,
                             op.Name,
                             op.Amount,
                             op.ReferenceDate)))
                );

            FinanceQueryResult result = new(
                    accountId,
                    GroupCollection.New(groups.Where(x => x.Category == Category.INCOME)),
                    GroupCollection.New(groups.Where(x => x.Category == Category.EXPENSE)),
                    GroupCollection.New(groups.Where(x => x.Category == Category.INVESTMENT))
                    );

            return result;
        }
    }
}