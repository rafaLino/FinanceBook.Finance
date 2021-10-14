using System;

namespace FinanceBook.Finance.Infrastructure.Exceptions
{
    public class AccountHasNoGroupsException : InfrastructureException
    {
        public AccountHasNoGroupsException(Guid accountId) : base($"Groups not found for account ${accountId}")
        {
        }

        public AccountHasNoGroupsException(string message) : base(message)
        {

        }
    }
}
