import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TicketViewer } from './components/ticket-viewer/ticket-viewer';
import { Ticket, TicketState } from './model/Tikcet';
import { TicketsViewer } from './components/tickets-viewer/tickets-viewer';

@Component({
  selector: 'app-root',
  imports: [TicketsViewer],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('tms.app');

  tickets: Ticket[] = [
    new Ticket(1, 'Server Down', 'Production server is not responding', TicketState.Open),
    new Ticket(2, 'Login Error', 'Cannot login to app', TicketState.Closed),
  ];

  onTicketStateChanged(updatedTicket: Ticket) {
    debugger;
    const index = this.tickets.findIndex((t) => t.ticketId === updatedTicket.ticketId);

    if (index !== -1) this.tickets[index] = { ...updatedTicket };
  }
}
