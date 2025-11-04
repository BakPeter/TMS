using Repository.Core.Interfaces.Validation;
using Repository.Core.Types;
using TMS.Core.Types;

namespace TMS.Infrastructure.Services;

public class TicketValidation: IEntityValidation<Ticket>
{
    public ValidationResult Validate(Ticket entity)
    {
        return new ValidationResult(true);
    }
}