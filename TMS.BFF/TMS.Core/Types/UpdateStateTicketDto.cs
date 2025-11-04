namespace TMS.Core.Types;

public record UpdateStateTicketDto(int TicketId, TicketState NewState);