using FinanceBook.Finance.Application.Core;
using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest<Response>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
