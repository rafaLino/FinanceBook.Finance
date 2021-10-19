using FinanceBook.Finance.Application.Core;
using FinanceBook.Finance.Application.Core.Extensions;
using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperation
{
    public class CreateGroupWithOperationCommandHandler : IRequestHandler<CreateGroupWithOperationCommand, Response>
    {
        private readonly IGroupWriteOnlyRepository _groupWriteOnlyRepository;
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;

        public CreateGroupWithOperationCommandHandler(IGroupWriteOnlyRepository groupWriteOnlyRepository, IOperationWriteOnlyRepository operationWriteOnlyRepository)
        {
            _groupWriteOnlyRepository = groupWriteOnlyRepository;
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
        }

        public async Task<Response> Handle(CreateGroupWithOperationCommand request, CancellationToken cancellationToken)
        {
            Group group = new(request.AccountId, request.Name, request.Description, request.Category.AsEnum<Category>());

            Operation operation = new(group.Id, request.Name, request.Amount);

            await _groupWriteOnlyRepository.SaveAsync(group, cancellationToken);
            await _operationWriteOnlyRepository.SaveAsync(operation, cancellationToken);

            return new Response(new
            {
                GroupId = group.Id,
                OperationId = operation.Id
            });
        }
    }
}
