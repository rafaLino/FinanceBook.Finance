using FinanceBook.Finance.Domain;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceBook.Finance.Application.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<CreateGroupCommandResult>
    {
        /// <summary>
        /// AccountId
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Category [INCOME, EXPENSE, INVESTMENT]
        /// </summary>
        [Required]
        public Category Category { get; set; }
    }
}
