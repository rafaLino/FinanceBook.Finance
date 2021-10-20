using FinanceBook.Finance.API.Controllers.Base;
using FinanceBook.Finance.API.Models;
using FinanceBook.Finance.Application.Commands.CreateOperation;
using FinanceBook.Finance.Application.Commands.RemoveOperation;
using FinanceBook.Finance.Application.Commands.UpdateOperation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceBook.Finance.API.Controllers
{
    /// <summary>
    /// Operation controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOperation([FromBody] CreateOperationCommand command, CancellationToken cancellationToken)
        {
            return CreatedOrBadRequest(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOperation(Guid id, UpdateOperationRequestModel model, CancellationToken cancellationToken)
        {
            var command = new UpdateOperationCommand
            {
                Id = id,
                Name = model.Name,
                Amount = model.Amount
            };

            return OkOrBadRequest(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOperation(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveOperationCommand
            {
                Id = id
            };

            return OkOrBadRequest(await _mediator.Send(command, cancellationToken));
        }
    }
}
