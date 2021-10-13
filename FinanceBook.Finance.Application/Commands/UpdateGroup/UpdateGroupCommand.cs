using MediatR;
using System;

namespace FinanceBook.Finance.Application.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
