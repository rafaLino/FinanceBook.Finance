using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.RemoveGroup
{
    public class RemoveGroupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
