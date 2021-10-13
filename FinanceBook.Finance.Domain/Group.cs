using FinanceBook.Finance.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace FinanceBook.Finance.Domain
{
    public class Group
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }

        public Category Category { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public OperationCollection Operations { get; private set; }

        private Group()
        {

        }

        public Group(Guid accountId, string name, string description, Category category)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Name = name;
            Description = description;
            Category = category;
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static Group Load(Guid id, Guid accountId, string name, string description, Category category, IEnumerable<Operation> operations = null)
        {
            Group group = new();
            group.Id = id;
            group.AccountId = accountId;
            group.Name = name;
            group.Description = description;
            group.Category = category;
            group.Operations = OperationCollection.New(operations);
            return group;
        }
    }
}
