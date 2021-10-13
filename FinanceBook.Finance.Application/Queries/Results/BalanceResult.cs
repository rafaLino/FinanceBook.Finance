using System;

namespace FinanceBook.Finance.Application.Queries.Results
{
    public class BalanceResult
    {
        public decimal Income { get; set; }

        public decimal Expense { get; set; }

        public decimal Investment { get; set; }

        public decimal Balance { get => Income - Cost; }

        public decimal Cost { get => Expense + Investment; }

        public decimal RemainingIncome { get => Income - Investment; }

        public double BalancePercentage { get => Income != 0 ? Convert.ToDouble(Balance / Income) : 0; }

        public double InvestmentPercentage { get => Income != 0 ? Convert.ToDouble(Investment / Income) : 0; }

        public double ExpensePercentage { get => Income != 0 ? Convert.ToDouble(Expense / Income) : 0; }
    }
}
