using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.CreateOperation
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, CreateOperationResult>
    {
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;

        public CreateOperationCommandHandler(IOperationWriteOnlyRepository operationWriteOnlyRepository)
        {
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
        }

        public async Task<CreateOperationResult> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            var operation = new Operation(request.GroupId, request.Name, request.Amount);

            await _operationWriteOnlyRepository.SaveAsync(operation, cancellationToken);

            return new CreateOperationResult
            {
                Id = operation.Id
            };
        }
    }
}
