using FinanceBook.Finance.Application.Core;
using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.RemoveGroup
{
    public class RemoveGroupCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
