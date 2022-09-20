using Application.Handlers.Users.Commands.Create;
using Application.Handlers.Users.Commands.Delete;
using Application.Handlers.Users.Commands.Update;
using Application.Handlers.Users.Dtos.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand createUserCommand) {
        CreatedUserDto result = await Mediator.Send(createUserCommand);
        return Created("", result);
    }

    [HttpDelete("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand) {
        DeletedUserDto result = await Mediator.Send(deleteUserCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand) {
        UpdatedUserDto result = await Mediator.Send(updateUserCommand);
        return Ok(result);
    }
}