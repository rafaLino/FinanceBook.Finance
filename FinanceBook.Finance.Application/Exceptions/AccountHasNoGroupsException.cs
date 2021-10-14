using System;

namespace FinanceBook.Finance.Application.Exceptions
{
    public class AccountHasNoGroupsException : AppException
    {
        public AccountHasNoGroupsException(Guid accountId) :
            base(
                (int)System.Net.HttpStatusCode.BadRequest,
                nameof(AccountHasNoGroupsException),
                $"Groups not found for account {accountId}"
                )
        {
        }

        public AccountHasNoGroupsException(string message) : base((int)System.Net.HttpStatusCode.BadRequest, nameof(AccountHasNoGroupsException), message)
        {

        }
    }
}
