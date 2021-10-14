namespace FinanceBook.Finance.Application.Exceptions
{
    public class GroupNotFoundException : AppException
    {
        public GroupNotFoundException(string message) : base((int)System.Net.HttpStatusCode.BadRequest, nameof(GroupNotFoundException), message)
        {
        }

        public GroupNotFoundException() : base((int)System.Net.HttpStatusCode.BadRequest, nameof(GroupNotFoundException), "Group not found!")
        {

        }
    }
}
