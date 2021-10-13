using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceBook.Finance.Domain.ValueObjects
{
    public class OperationCollection : FinanceCollection<Operation>
    {
        protected OperationCollection(IEnumerable<Operation> collection) : base(collection)
        {
        }

        public override decimal Total() => _collection.Sum(x => x.Amount);

        public static OperationCollection New(IEnumerable<Operation> collection) => collection is not null ? new OperationCollection(collection) : null;
    }
}
