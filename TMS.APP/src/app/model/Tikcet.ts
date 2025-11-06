export enum TicketState {
  Closed = 0,
  Open,
}

export class Ticket {
  constructor(
    public ticketId: number,
    public subject: string,
    public description: string,
    public state: TicketState
  ) {}
}
