using Repository.Core.Interfaces.Validation;
using Repository.Core.Types;
using TMS.Core.Types;

namespace TMS.Infrastructure.Services.Validators;

public class TicketSubjectValidator : IEntityValidator<Ticket>
{
    public ValidationResult Validate(Ticket ticket)
    {
        return string.IsNullOrEmpty(ticket.Subject)
            ? new ValidationResult(false, ["Subject is null or empty"])
            : new ValidationResult(true);
    }
}