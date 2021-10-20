using FinanceBook.Finance.Application.Core;
using FinanceBook.Finance.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.RemoveGroup
{
    public class RemoveGroupCommandHandler : IRequestHandler<RemoveGroupCommand, Response>
    {
        private readonly IGroupWriteOnlyRepository _groupWriteOnlyRepository;

        public RemoveGroupCommandHandler(IGroupWriteOnlyRepository groupWriteOnlyRepository)
        {
            _groupWriteOnlyRepository = groupWriteOnlyRepository;
        }

        public async Task<Response> Handle(RemoveGroupCommand request, CancellationToken cancellationToken)
        {
            await _groupWriteOnlyRepository.RemoveAsync(request.Id, cancellationToken);

            return Response.Value;
        }
    }
}
