using FinanceBook.Finance.Application.Core;
using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.UpdateOperation
{
    public class UpdateOperationCommand : IRequest<Response>
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string Name { get; set; }
    }
}
