using FinanceBook.Finance.Application.Exceptions;
using FinanceBook.Finance.Application.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
    {
        private readonly IGroupWriteOnlyRepository _groupWriteOnlyRepository;
        private readonly IGroupReadOnlyRepository _groupReadOnlyRepository;

        public UpdateGroupCommandHandler(IGroupWriteOnlyRepository groupWriteOnlyRepository, IGroupReadOnlyRepository groupReadOnlyRepository)
        {
            _groupWriteOnlyRepository = groupWriteOnlyRepository;
            _groupReadOnlyRepository = groupReadOnlyRepository;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupReadOnlyRepository.GetAsync(request.Id, cancellationToken);

            if (group is null)
                throw new GroupNotFoundException();

            group.Update(request.Name, request.Description);

            await _groupWriteOnlyRepository.UpdateAsync(group, cancellationToken);

            return Unit.Value;
        }
    }
}
