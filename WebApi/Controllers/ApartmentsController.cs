using Application.Handlers.Apartments.Commands.Create;
using Application.Handlers.Apartments.Commands.Delete;
using Application.Handlers.Apartments.Commands.Update;
using Application.Handlers.Apartments.Dtos.Commands;
using Application.Handlers.Apartments.Dtos.Queries;
using Application.Handlers.Apartments.Queries.GetAll;
using Application.Handlers.Apartments.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApartmentsController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] CreateApartmentCommand createApartmentCommand) {
        CreatedApartmentDto result = await Mediator.Send(createApartmentCommand);
        return Created("", result);
    }

    [HttpDelete("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Delete([FromBody] DeleteApartmentCommand deleteApartmentCommand) {
        DeletedApartmentDto result = await Mediator.Send(deleteApartmentCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] UpdateApartmentCommand updateApartmentCommand) {
        UpdatedApartmentDto result = await Mediator.Send(updateApartmentCommand);
        return Ok(result);
    }

    [HttpGet("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll() {
        return Ok(await Mediator.Send(new GetAllApartmentQuery { }));
    }

    [HttpGet("[action]/{Id:Guid}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdApartmentQuery getByIdApartmentQuery) {
        GetByIdApartmentDto result = await Mediator.Send(getByIdApartmentQuery);
        return Ok(result);
    }
}