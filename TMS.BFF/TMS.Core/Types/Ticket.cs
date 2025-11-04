namespace TMS.Core.Types;

public enum TicketState
{
    Closed,
    Open
}
public record Ticket(int TicketId, string Subject, string Description, TicketState State);
