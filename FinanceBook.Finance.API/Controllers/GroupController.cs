using FinanceBook.Finance.API.Controllers.Base;
using FinanceBook.Finance.API.Models;
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
    public class GroupController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
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

            return OkOrBadRequest(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGroup(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveGroupCommand
            {
                Id = id
            };

            return OkOrBadRequest(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupWithOperationCommand command, CancellationToken cancellationToken)
        {
            return CreatedOrBadRequest(await _mediator.Send(command, cancellationToken));
        }
    }
}
