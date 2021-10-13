using FinanceBook.Finance.Domain;
using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperation
{
    public class CreateGroupWithOperationCommand : IRequest<CreateGroupWithOperationCommandResult>
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public decimal Amount { get; set; }
    }
}
