using FinanceBook.Finance.API.Models;
using FinanceBook.Finance.Application.Commands.CreateGroup;
using FinanceBook.Finance.Application.Commands.CreateGroupWithOperation;
using FinanceBook.Finance.Application.Commands.RemoveGroup;
using FinanceBook.Finance.Application.Commands.UpdateGroup;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace FinanceBook.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Created(Request.Path, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(Guid id, [FromBody] UpdateGroupRequestModel model, CancellationToken cancellationToken)
        {
            var command = new UpdateGroupCommand
            {
                Id = id,
                Name = model.Name,
                Description = model.Description
            };

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGroup(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveGroupCommand
            {
                Id = id
            };

            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("operation")]
        public async Task<IActionResult> CreateGroupWithOperation([FromBody] CreateGroupWithOperationCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Created(Request.Path, result);
        }
    }
}
