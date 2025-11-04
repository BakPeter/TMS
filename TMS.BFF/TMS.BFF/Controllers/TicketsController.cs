using Microsoft.AspNetCore.Mvc;
using TMS.Core.Interfaces;
using TMS.Core.Types;

namespace TMS.BFF.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ILogger<TicketsController> _logger;
    private readonly ITicketService _service;

    public TicketsController(ILogger<TicketsController> logger, ITicketService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
    {
        try
        {
            var response = await _service.GetAllTickets();
            if (response.IsSuccess) return Ok(response.Entity);
            return BadRequest(response.Error!.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Ticket>> AddTicket([FromBody] AddTicketDto addTicketDto)
    {
        try
        {
            var response = await _service.AddTicket(addTicketDto);
            if (response.IsSuccess) return Ok(response.Entity);
            return BadRequest(response.Error!.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult<Ticket>> UpdateTicketState([FromBody] UpdateStateTicketDto updateStateTicketDto)
    {
        try
        {
            var response = await _service.UpdateTicketState(updateStateTicketDto);
            if (response.IsSuccess) return Ok(response.Entity);
            return BadRequest(response.Error!.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }
}