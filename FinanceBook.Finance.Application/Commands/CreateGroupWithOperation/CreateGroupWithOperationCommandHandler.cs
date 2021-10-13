using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperation
{
    public class CreateGroupWithOperationCommandHandler : IRequestHandler<CreateGroupWithOperationCommand, CreateGroupWithOperationCommandResult>
    {
        private readonly IGroupWriteOnlyRepository _groupWriteOnlyRepository;
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;

        public CreateGroupWithOperationCommandHandler(IGroupWriteOnlyRepository groupWriteOnlyRepository, IOperationWriteOnlyRepository operationWriteOnlyRepository)
        {
            _groupWriteOnlyRepository = groupWriteOnlyRepository;
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
        }

        public async Task<CreateGroupWithOperationCommandResult> Handle(CreateGroupWithOperationCommand request, CancellationToken cancellationToken)
        {
            Group group = new(request.AccountId, request.Name, request.Description, request.Category);

            Operation operation = new(group.Id, request.Name, request.Amount);

            await _groupWriteOnlyRepository.SaveAsync(group, cancellationToken);
            await _operationWriteOnlyRepository.SaveAsync(operation, cancellationToken);

            return new CreateGroupWithOperationCommandResult
            {
                GroupId = group.Id,
                OperationId = operation.Id
            };
        }
    }
}
