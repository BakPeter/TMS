import { TicketState } from './Tikcet';

// export class UpdateTicketStateDto {
//   constructor(public ticketId: number, public state: TicketState) {}
// }

export class UpdateTicketStateDto {
  constructor(public ticketId: number) {}
}
