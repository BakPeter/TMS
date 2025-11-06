import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { Ticket, TicketState } from '../../model/Tikcet';
import { TicketViewer } from '../ticket-viewer/ticket-viewer';
import { TicketsViewerService } from '../../services/tickets-viewer-service';
import { UpdateTicketStateDto } from '../../model/UpdateTicketStateDto';

@Component({
  selector: 'app-tickets-viewer',
  imports: [TicketViewer],
  templateUrl: './tickets-viewer.html',
  styleUrl: './tickets-viewer.css',
})
export class TicketsViewer implements OnInit {
  service: TicketsViewerService = inject(TicketsViewerService);
  cdr: ChangeDetectorRef = inject(ChangeDetectorRef);

  tickets: Ticket[] = [];

  ngOnInit(): void {
    this.loadTickets();
  }

  loadTickets() {
    this.service.getAllTickets().subscribe(
      (tickets: Ticket[]) => {
        this.tickets = tickets;
        this.cdr.detectChanges();
      },
      (error) => {
        alert('Failed to fetch tickets ' + error.message);
      }
    );
  }

  onTicketStateChanged(ticket: Ticket) {
    debugger;
    // const newState: TicketState =
    //   ticket.state === TicketState.Closed ? TicketState.Open : TicketState.Closed;
    // const updateTicketDto: UpdateTicketStateDto = new UpdateTicketStateDto(
    //   ticket.ticketId,
    //   newState
    // );
    const updateTicketDto: UpdateTicketStateDto = new UpdateTicketStateDto(ticket.ticketId);
    this.service.updateTicketState(updateTicketDto).subscribe(
      (ticket: Ticket) => {
        this.loadTickets();
      },
      (error) => {
        alert('Failed to to update ticket state ' + error.message);
      }
    );
  }
}
