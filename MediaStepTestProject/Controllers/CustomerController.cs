using MediaStepTestProject.Commands;
using MediaStepTestProject.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaStepTestProject.Controllers;

public class CustomerController : ApiBaseController
{
    [HttpPost("addrange")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> AddRangeCustomer([FromBody] AddRangeCustomerCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpGet("customer")]
    public async Task<IActionResult> GetCustomer(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new CustomerQuery(), cancellationToken));
    }

    [HttpPost("buy-product")]
    public async Task<IActionResult> BuyProduct([FromBody] BuyProductCommand command, CancellationToken cancellationToken)
    {
        await Mediator.Send(command, cancellationToken);

        return Ok();
    }
}
