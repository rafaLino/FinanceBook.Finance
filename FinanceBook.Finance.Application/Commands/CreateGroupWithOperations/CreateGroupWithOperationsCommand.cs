using FinanceBook.Finance.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperations
{
    public class CreateGroupWithOperationsCommand : IRequest<Response>
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public IEnumerable<OperationInput> Operations { get; set; }
    }

    public class OperationInput
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }
    }
}
