using FinanceBook.Finance.Application.Core;
using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<Response>
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Amount { get; set; }
    }
}
