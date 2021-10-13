using System;

namespace FinanceBook.Finance.Application.Commands.CreateGroupWithOperation
{
    public class CreateGroupWithOperationCommandResult
    {
        public Guid GroupId { get; set; }

        public Guid OperationId { get; set; }
    }
}
