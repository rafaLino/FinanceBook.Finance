using FinanceBook.Finance.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace FinanceBook.Finance.Application.Queries.Results
{
    public class FinanceQueryResult
    {
        public Guid AccountId { get; set; }

        public BalanceResult Balance { get; set; }
        public IEnumerable<GroupResult> Incomes { get; set; }
        public IEnumerable<GroupResult> Expenses { get; set; }
        public IEnumerable<GroupResult> Investments { get; set; }

        public FinanceQueryResult(Guid accountId, GroupCollection incomes, GroupCollection expenses, GroupCollection investments)
        {
            AccountId = accountId;
            Incomes = incomes.As(x => new GroupResult(x.Id, x.Name, x.Operations));
            Expenses = expenses.As(x => new GroupResult(x.Id, x.Name, x.Operations));
            Investments = investments.As(x => new GroupResult(x.Id, x.Name, x.Operations));

            CalculatePercentage(Expenses, expenses.Total());
            CalculatePercentage(Investments, investments.Total());
            CalculatePercentage(Incomes, incomes.Total());

            Balance = new BalanceResult
            {
                Income = incomes.Total(),
                Expense = expenses.Total(),
                Investment = investments.Total()
            };
        }

        private static void CalculatePercentage(IEnumerable<GroupResult> groups, decimal groupTotal)
        {
            foreach (var item in groups)
            {
                item.Percentage = groupTotal != 0 ? Convert.ToDouble(item.Total / groupTotal) : 0;
            }
        }
    }
}
