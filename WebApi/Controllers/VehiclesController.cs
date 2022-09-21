using Application.Handlers.Vehicles.Commands.Create;
using Application.Handlers.Vehicles.Commands.Delete;
using Application.Handlers.Vehicles.Commands.Update;
using Application.Handlers.Vehicles.Dtos.Commands;
using Application.Handlers.Vehicles.Dtos.Queries;
using Application.Handlers.Vehicles.Queries.GetAll;
using Application.Handlers.Vehicles.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class VehiclesController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] CreateVehicleCommand createVehicleCommand) {
        CreatedVehicleDto result = await Mediator.Send(createVehicleCommand);
        return Created("", result);
    }

    [HttpDelete("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Delete([FromBody] DeleteVehicleCommand deleteVehicleCommand) {
        DeletedVehicleDto result = await Mediator.Send(deleteVehicleCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] UpdateVehicleCommand updateVehicleCommand) {
        UpdatedVehicleDto result = await Mediator.Send(updateVehicleCommand);
        return Ok(result);
    }

    [HttpGet("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll() {
        return Ok(await Mediator.Send(new GetAllVehicleQuery { }));
    }

    [HttpGet("[action]/{UserId:Guid}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetById([FromRoute] GetByUserIdVehicleQuery getByUserIdVehicleQuery) {
        IQueryable<GetByUserIdVehicleDto> result = await Mediator.Send(getByUserIdVehicleQuery);
        return Ok(result);
    }
}