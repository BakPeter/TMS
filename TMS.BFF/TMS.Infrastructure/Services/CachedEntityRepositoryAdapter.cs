using System.Collections.Concurrent;
using System.Collections.Immutable;
using Repository.Core.Interfaces;
using Repository.Core.Types;
using TMS.Core.Types;

namespace TMS.Infrastructure.Services;

public class CachedEntityRepositoryAdapter : IRepositoryAdapter<Ticket>
{
    private readonly ConcurrentDictionary<int, Ticket> _data = new();

    public Task<Result<Ticket>> GetByIdAsync(int id)
    {
        if (_data.TryGetValue(id, out var ticket))
            return Task.FromResult(new Result<Ticket>(true, ticket));
        return Task.FromResult(new Result<Ticket>(false, null, new EntityDontExistsException()));
    }

    public Task<Result<IEnumerable<Ticket>>> GetAllAsync()
    {
        var result = new Result<IEnumerable<Ticket>>(true, _data.Values.ToImmutableList());
        return Task.FromResult(result);
    }

    public Task<Result<Ticket>> AddAsync(Ticket entity)
    {
        _data[entity.TicketId] = entity;
        return Task.FromResult(new Result<Ticket>(true, entity));
    }

    public Task<Result<Ticket>> UpdateAsync(Ticket entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Ticket>> DeleteAsync(Ticket entity)
    {
        throw new NotImplementedException();
    }

    // TODO - reimplement for Subject and Description equality - ?
    public Task<bool> Contains(Ticket entity)
    {
        var result = _data.ContainsKey(entity.TicketId);
        return Task.FromResult(result);
    }
}