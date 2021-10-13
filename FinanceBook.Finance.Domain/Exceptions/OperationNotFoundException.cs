namespace FinanceBook.Finance.Domain.Exceptions
{
    public class OperationNotFoundException : DomainException
    {
        public OperationNotFoundException(string message) : base(message)
        {
        }

        public OperationNotFoundException() : base("Operation not found!")
        {

        }
    }
}
