using MediaStepTestProject.Commands;
using MediaStepTestProject.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaStepTestProject.Controllers;

public class HomeController : ApiBaseController
{
    [HttpGet("cust-prod-shop")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetCustomerProductShop(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new CustomerProductShopQuery(), cancellationToken));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(command, cancellationToken));
    }
}
