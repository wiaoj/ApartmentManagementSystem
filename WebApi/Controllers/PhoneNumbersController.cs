using Application.Handlers.PhoneNumbers.Commands.Create;
using Application.Handlers.PhoneNumbers.Commands.Delete;
using Application.Handlers.PhoneNumbers.Commands.Update;
using Application.Handlers.PhoneNumbers.Dtos.Commands;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PhoneNumbersController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] CreatePhoneNumberCommand createPhoneNumberCommand) {
        CreatedPhoneNumberDto result = await Mediator.Send(createPhoneNumberCommand);
        return Created("", result);
    }

    [HttpDelete("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Delete([FromBody] DeletePhoneNumberCommand deletePhoneNumberCommand) {
        DeletedPhoneNumberDto result = await Mediator.Send(deletePhoneNumberCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] UpdatePhoneNumberCommand updatePhoneNumberCommand) {
        UpdatedPhoneNumberDto result = await Mediator.Send(updatePhoneNumberCommand);
        return Ok(result);
    }
}