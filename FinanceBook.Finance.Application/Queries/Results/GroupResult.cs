using FinanceBook.Finance.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace FinanceBook.Finance.Application.Queries.Results
{
    public class GroupResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Total { get; set; }


        public double Percentage { get; set; }

        public IEnumerable<OperationResult> Operations { get; set; }

        public GroupResult(Guid id, string name, OperationCollection operationCollection)
        {
            Id = id;
            Name = name;
            Operations = operationCollection.As(x => new OperationResult(x.Id, x.Name, x.Amount));
            Total = operationCollection.Total();
        }
    }
}
