using Courier.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Courier.API;

[ApiController]
[Route("api/[controller]")]
public class ParcelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParcelsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateParcel(CreateParcelCommand command)
    {
        var parcelId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetParcel), new { id = parcelId }, new { id = parcelId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetParcel(int id)
    {
        // Implementation to get parcel details
        return Ok();
    }
}