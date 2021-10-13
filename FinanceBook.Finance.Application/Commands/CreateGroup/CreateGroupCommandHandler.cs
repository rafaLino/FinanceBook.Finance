using FinanceBook.Finance.Application.Repositories;
using FinanceBook.Finance.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.Application.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreateGroupCommandResult>
    {
        private readonly IGroupWriteOnlyRepository _groupWriteOnlyRepository;

        public CreateGroupCommandHandler(IGroupWriteOnlyRepository groupWriteOnlyRepository)
        {
            _groupWriteOnlyRepository = groupWriteOnlyRepository;
        }

        public async Task<CreateGroupCommandResult> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new Group(request.AccountId, request.Name, request.Description, request.Category);

            await _groupWriteOnlyRepository.SaveAsync(group, cancellationToken);

            return new CreateGroupCommandResult { Id = group.Id };
        }
    }
}
