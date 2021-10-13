using FinanceBook.Finance.Domain;
using System;
using System.Collections.Generic;

namespace FinanceBook.Finance.Infrastructure.Entities
{
    public class Group
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Operation> Operations { get; set; }
    }
}
