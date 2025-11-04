using TMS.Infrastructure.Interfaces;

namespace TMS.Infrastructure.Services;

public class IdGenerator : IIdGenerator
{
    // TODO - IdGenerator reimplement to thread safe 

    private static int _idCounter = 0;
    public int GetId()
    {
        _idCounter++;
        return _idCounter;
    }
}