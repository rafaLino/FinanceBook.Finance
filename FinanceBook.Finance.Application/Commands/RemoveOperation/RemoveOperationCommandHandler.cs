using FinanceBook.Finance.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.RemoveOperation
{
    public class RemoveOperationCommandHandler : IRequestHandler<RemoveOperationCommand>
    {
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;

        public RemoveOperationCommandHandler(IOperationWriteOnlyRepository operationWriteOnlyRepository)
        {
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
        }

        public async Task<Unit> Handle(RemoveOperationCommand request, CancellationToken cancellationToken)
        {
            await _operationWriteOnlyRepository.RemoveAsync(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
