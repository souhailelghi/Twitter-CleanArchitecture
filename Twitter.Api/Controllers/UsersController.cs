using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Twitter.Application.Features.Users.Commands.AddUser;
using Twitter.Application.Features.Users.Commands.DeleteUser;
using Twitter.Application.Features.Users.Commands.UpdateUser;
using Twitter.Application.Features.Users.Queryies.GetListUserQuery;
using Twitter.Application.Features.Users.Queryies.GetUserByIdQuery;
using Twitter.Domain.Models;

namespace Twitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetUsersList()
        {
            try
            {
                List<User> UsersList = await _mediator.Send(new GetListUserQuery());
                return Ok(UsersList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                User UsersList = await _mediator.Send(new GetUserByIDQuery(id));
                return Ok(UsersList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            if (command == null)
            {
                return BadRequest("User data is required.");
            }

            try
            {
                string result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserQuery(id));

                if (result == "User not found.")
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            try
            {
                var result = await _mediator.Send(command);

                if (result == "User not found.")
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
