using FinanceBook.Finance.Application.Core;
using FinanceBook.Finance.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.RemoveOperation
{
    public class RemoveOperationCommandHandler : IRequestHandler<RemoveOperationCommand, Response>
    {
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;

        public RemoveOperationCommandHandler(IOperationWriteOnlyRepository operationWriteOnlyRepository)
        {
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
        }

        public async Task<Response> Handle(RemoveOperationCommand request, CancellationToken cancellationToken)
        {
            await _operationWriteOnlyRepository.RemoveAsync(request.Id, cancellationToken);

            return Response.Value;
        }
    }
}
