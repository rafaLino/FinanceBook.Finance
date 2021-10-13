using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FinanceBook.Finance.Domain.ValueObjects
{
    public abstract class FinanceCollection<T>
    {
        protected readonly IList<T> _collection;
        public IReadOnlyCollection<T> List => new ReadOnlyCollection<T>(_collection);

        protected FinanceCollection(IEnumerable<T> collection)
        {
            _collection = new List<T>(collection);
        }
        public abstract decimal Total();
        public virtual IEnumerable<TResult> As<TResult>(Func<T, TResult> selector) where TResult : class => _collection.Select(selector);

    }
}
