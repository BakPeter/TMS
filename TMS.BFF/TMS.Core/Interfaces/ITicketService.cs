using Repository.Core.Interfaces;
using Repository.Core.Types;
using TMS.Core.Types;
using TMS.Infrastructure.Interfaces;

namespace TMS.Core.Interfaces;

public interface ITicketService
{
    Task<Result<IEnumerable<Ticket>>> GetAllTickets();
    Task<Result<Ticket>> AddTicket(AddTicketDto addTicketDto);
    Task<Result<Ticket>> UpdateTicketState(UpdateStateTicketDto updateStateTicketDto);
}

public class TicketService : ITicketService
{
    private readonly IRepository<Ticket> _repository;
    private readonly IIdGenerator _idGenerator;

    public TicketService(IRepository<Ticket> repository, IIdGenerator idGenerator)
    {
        _repository = repository;
        _idGenerator = idGenerator;
    }

    public async Task<Result<IEnumerable<Ticket>>> GetAllTickets() => await _repository.GetAllAsync();
    public async Task<Result<Ticket>> AddTicket(AddTicketDto addTicketDto)
    {
        var ticket = new Ticket(_idGenerator.GetId(), addTicketDto.Subject, addTicketDto.Description, TicketState.Open);
        return await _repository.AddAsync(ticket);

    }

    public async Task<Result<Ticket>> UpdateTicketState(UpdateStateTicketDto updateStateTicketDto)
    {
        return await _repository.UpdateFieldAsync(
            updateStateTicketDto.TicketId,
            ticket => ticket with { State = updateStateTicketDto.NewState });
    }
}