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
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperation([FromBody] CreateOperationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Created(Request.Path, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOperation(Guid id, UpdateOperationRequestModel model, CancellationToken cancellationToken)
        {
            var command = new UpdateOperationCommand
            {
                Id = id,
                Name = model.Name,
                Amount = model.Amount
            };

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOperation(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveOperationCommand
            {
                Id = id
            };

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
