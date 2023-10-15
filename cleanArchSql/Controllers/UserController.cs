using cleanArchSql.Application.Commands;
using cleanArchSql.Application.Queries;
using cleanArchSql.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cleanArchSql.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var command = new CreateUserCommand() { NewUser = user };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUser user)
        {
            var command = new UpdateUserByIdCommand()
            {
                UserId = id,
                Name = user.Name,
                Address = user.Address,
                Phone = user.Phone
            };

            var result = await _mediator.Send(command);

            return result ? Ok() : NotFound();
        }

    }
}
