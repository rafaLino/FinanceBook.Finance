using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommand : IRequest
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string Name { get; set; }
    }
}
