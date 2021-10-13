using System;

namespace FinanceBook.Finance.Application.Queries.Results
{
    public class OperationResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public OperationResult(Guid id, string name, decimal amount)
        {
            Id = id;
            Name = name;
            Amount = amount;
        }
    }
}
