using FinanceBook.Finance.Application.Core;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceBook.Finance.Application.Commands.CreateOperation
{
    public class CreateOperationCommand : IRequest<Response>
    {
        /// <summary>
        /// GroupId
        /// </summary>
        [Required]
        public Guid GroupId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
    }
}
