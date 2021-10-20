using FinanceBook.Finance.Application.Core;
using FinanceBook.Finance.Application.Exceptions;
using FinanceBook.Finance.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommandHandler : IRequestHandler<UpdateOperationCommand, Response>
    {
        private readonly IOperationWriteOnlyRepository _operationWriteOnlyRepository;
        private readonly IOperationReadOnlyRepository _operationReadOnlyRepository;

        public UpdateOperationCommandHandler(IOperationWriteOnlyRepository operationWriteOnlyRepository, IOperationReadOnlyRepository operationReadOnlyRepository)
        {
            _operationWriteOnlyRepository = operationWriteOnlyRepository;
            _operationReadOnlyRepository = operationReadOnlyRepository;
        }

        public async Task<Response> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            var operation = await _operationReadOnlyRepository.GetAsync(request.Id, cancellationToken);

            if (operation is null)
                throw new OperationNotFoundException();

            operation.Update(request.Name, request.Amount);

            await _operationWriteOnlyRepository.UpdateAsync(operation, cancellationToken);

            return Response.Value;
        }
    }
}
