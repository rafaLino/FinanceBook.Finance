namespace FinanceBook.Finance.Application.Exceptions
{
    public class OperationNotFoundException : AppException
    {
        public OperationNotFoundException(string message) : base((int)System.Net.HttpStatusCode.BadRequest, nameof(OperationNotFoundException), message)
        {
        }

        public OperationNotFoundException() : base((int)System.Net.HttpStatusCode.BadRequest, nameof(OperationNotFoundException), "Operation not found!")
        {

        }
    }
}
