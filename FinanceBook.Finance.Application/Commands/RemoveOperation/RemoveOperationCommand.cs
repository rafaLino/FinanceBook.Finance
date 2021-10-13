using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.RemoveOperation
{
    public class RemoveOperationCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
