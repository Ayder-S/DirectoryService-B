using DS.Application.Locations;
using DS.Contracts;
using DS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DS.Presenters.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateLocationHandler handler,
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(request, cancellationToken);
        if(!result.IsSuccess)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
    }
}