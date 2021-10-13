using System;

namespace FinanceBook.Finance.Infrastructure.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime ReferenceDate { get; set; }
    }
}
