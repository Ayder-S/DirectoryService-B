using DS.Application.Abstractions;
using DS.Application.Locations;
using DS.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace DS.Presenters.Controllers;

[ApiController]
[Route("api/locations")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICommandHandler<CreateLocationCommand, Guid> handler,
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateLocationCommand(request);

        var result = await handler.Handle(command, cancellationToken);
        if(result.IsFailure)
            return BadRequest(Envelope.Fail(result.Error));

        return Ok(Envelope.Ok(result.Value));
    }
}