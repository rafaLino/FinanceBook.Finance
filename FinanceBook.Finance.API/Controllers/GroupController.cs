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
    /// <summary>
    /// Group controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ApiControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGroup(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveGroupCommand
            {
                Id = id
            };

            return OkOrBadRequest(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupWithOperationCommand command, CancellationToken cancellationToken)
        {
            return CreatedOrBadRequest(await _mediator.Send(command, cancellationToken));
        }
    }
}
