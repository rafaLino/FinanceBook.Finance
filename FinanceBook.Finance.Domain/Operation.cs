using FinanceBook.Finance.Domain.ValueObjects;
using System;

namespace FinanceBook.Finance.Domain
{
    public class Operation
    {

        public Guid Id { get; private set; }

        public Guid GroupId { get; private set; }

        public string Name { get; private set; }
        public Amount Amount { get; private set; }

        public MonthDate ReferenceDate { get; private set; }

        private Operation() { }
        public Operation(Guid groupId, string name, Amount amount)
        {
            Id = Guid.NewGuid();
            ReferenceDate = MonthDate.Now;
            GroupId = groupId;
            Name = name;
            Amount = amount;
        }

        public void Update(string name, Amount amount)
        {
            Name = name;
            Amount = amount;
        }

        public static Operation Load(Guid id, Guid groupId, string name, Amount amount, MonthDate referenceDate)
        {
            Operation operation = new();
            operation.Id = id;
            operation.GroupId = groupId;
            operation.Name = name;
            operation.Amount = amount;
            operation.ReferenceDate = referenceDate;
            return operation;
        }
    }
}
