using MediaStepTestProject.Commands;
using MediaStepTestProject.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaStepTestProject.Controllers;

public class ProductController : ApiBaseController
{
    [HttpPost("addrange")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> AddRangeProduct([FromBody] AddRangeProductCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpGet("product")]
    public async Task<IActionResult> GetProduct([FromQuery] ProductQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }
}
