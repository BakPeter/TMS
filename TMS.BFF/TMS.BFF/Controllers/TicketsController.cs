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
            return ErrorHandler(e);
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
            return ErrorHandler(e);
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
            return ErrorHandler(e);
        }
    }

    private ActionResult ErrorHandler(Exception error)
    {
        _logger.LogError(error.Message);

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Bad Request",
            Detail = error.Message,
        };
        return BadRequest(problem);
    }
}