using Application.Handlers.Bills.Commands.Create;
using Application.Handlers.Bills.Commands.Delete;
using Application.Handlers.Bills.Commands.Update;
using Application.Handlers.Bills.Dtos.Commands;
using Application.Handlers.Bills.Dtos.Queries;
using Application.Handlers.Bills.Queries.GetAll;
using Application.Handlers.Bills.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BillsController : BaseController {
    [HttpPost("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromBody] CreateBillCommand createBillCommand) {
        CreatedBillDto result = await Mediator.Send(createBillCommand);
        return Created("", result);
    }

    [HttpDelete("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Delete([FromBody] DeleteBillCommand deleteBillCommand) {
        DeletedBillDto result = await Mediator.Send(deleteBillCommand);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> Update([FromBody] UpdateBillCommand updateBillCommand) {
        UpdatedBillDto result = await Mediator.Send(updateBillCommand);
        return Ok(result);
    }

    [HttpGet("[action]")]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll() {
        return Ok(await Mediator.Send(new GetAllBillQuery { }));
    }

    [HttpGet("[action]/{UserId:Guid}")]
    [Produces("application/json")]
    public async Task<IActionResult> GetById([FromRoute] GetByUserIdBillQuery getByUserIdBillQuery) {
        IQueryable<GetByUserIdBillDto> result = await Mediator.Send(getByUserIdBillQuery);
        return Ok(result);
    }
}