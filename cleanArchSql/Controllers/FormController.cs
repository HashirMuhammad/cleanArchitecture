using cleanArchSql.Application.Commands;
using cleanArchSql.Application.Handlers;
using cleanArchSql.Application.Queries;
using cleanArchSql.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static cleanArchSql.Application.Handlers.GetFormDataQueryHandler;

namespace cleanArchSql.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpGet(Name = "GetAllFormData")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFormData());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateForm form)
        {
            var command = new UpdateFormByIdCommand()
            {
                FormId = id,
                PageName = form.PageName,
                PageDescription = form.PageDescription,
                Active = form.Active,
                PageType =form.PageType,
                AssignedUsers = form.AssignedUsers,
                PageDesignFile = form.PageDesignFile,
            };

            var result = await _mediator.Send(command);

            return result ? Ok() : NotFound();
        }

        // Update your controller to use the new query
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormDataById(int id)
        {
            var query = new GetFormDataQuery { FormDataId = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetNamesByFormDataId(int id)
        {
            var query = new GetFormDataQueryHandler { FormDataId = id };
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }*/



        [HttpPost]
        public async Task<IActionResult> SaveFormData([FromBody] FormData formData)
        {
            var command = new SaveFormDataCommand { FormData = formData };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        /*[HttpPost]
        [Route("save-data")]
        public async Task<IActionResult> SaveData([FromBody] PageInputDto formData)
        {
            var command = new SaveFormDataDtoCommand { FormData = formData };
            var result = await _mediator.Send(command);
            return Ok(result);
        }*/

    }
}
