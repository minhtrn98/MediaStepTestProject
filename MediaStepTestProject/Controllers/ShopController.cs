using MediaStepTestProject.Commands;
using MediaStepTestProject.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaStepTestProject.Controllers;

public class ShopController : ApiBaseController
{
    [HttpPost("addrange")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> AddRangeShop([FromBody] AddRangeShopCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetShop(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ShopQuery(), cancellationToken));
    }
}
