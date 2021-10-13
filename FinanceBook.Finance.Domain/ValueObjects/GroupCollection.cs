using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceBook.Finance.Domain.ValueObjects
{
    public class GroupCollection : FinanceCollection<Group>
    {
        protected GroupCollection(IEnumerable<Group> collection) : base(collection)
        {
        }

        public override decimal Total() => _collection.Sum(x => x.Operations.Total());

        public static GroupCollection New(IEnumerable<Group> collection) => collection is not null ? new GroupCollection(collection) : null;

    }
}
