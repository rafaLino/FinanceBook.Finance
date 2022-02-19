using FinanceBook.Finance.Application.Core;
using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.RemoveOperation
{
    public class RemoveOperationCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
