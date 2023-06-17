using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaStepTestProject.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public abstract class ApiBaseController : ControllerBase
{
    private IMediator _mediator = default!;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

}