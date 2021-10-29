using FinanceBook.Finance.Application.Core;
using FinanceBook.Finance.Application.Core.Extensions;
using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperations
{
    public class CreateGroupWithOperationsCommandHandler : IRequestHandler<CreateGroupWithOperationsCommand, Response>
    {
        private readonly IGroupWriteOnlyRepository _groupWriteOnlyRepository;
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;

        public CreateGroupWithOperationsCommandHandler(IGroupWriteOnlyRepository groupWriteOnlyRepository, IOperationWriteOnlyRepository operationWriteOnlyRepository)
        {
            _groupWriteOnlyRepository = groupWriteOnlyRepository;
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
        }

        public async Task<Response> Handle(CreateGroupWithOperationsCommand request, CancellationToken cancellationToken)
        {
            Group group = new(request.AccountId, request.Name, request.Description, request.Category.AsEnum<Category>());
            IEnumerable<Operation> operations = request.Operations.Select(item => new Operation(group.Id, item.Name, item.Amount));

            await _groupWriteOnlyRepository.SaveAsync(group, cancellationToken);
            await _operationWriteOnlyRepository.SaveAsync(operations, cancellationToken);

            return new Response(new
            {
                GroupId = group.Id,
                OperationIds = operations.Select(x => x.Id)
            });

        }
    }
}
