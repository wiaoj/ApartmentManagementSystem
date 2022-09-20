using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base;

public class BaseController : ControllerBase {
    protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator? _mediator;
}