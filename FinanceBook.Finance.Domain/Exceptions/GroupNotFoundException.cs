namespace FinanceBook.Finance.Domain.Exceptions
{
    public class GroupNotFoundException : DomainException
    {
        public GroupNotFoundException(string message) : base(message)
        {
        }

        public GroupNotFoundException() : base("Group not found!")
        {

        }
    }
}
