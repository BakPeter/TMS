import { CommonModule } from '@angular/common';
import { Component, EventEmitter, input, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Ticket, TicketState } from '../../model/Tikcet';

@Component({
  selector: 'app-ticket-viewer',
  imports: [CommonModule, FormsModule],
  templateUrl: './ticket-viewer.html',
  styleUrl: './ticket-viewer.css',
})
export class TicketViewer {
  @Input() serialNumber!: number;
  @Input() ticket!: Ticket;
  @Output() ticketStateChanged = new EventEmitter<number>();

  TicketState = TicketState;
  states = Object.keys(TicketState).filter((key) => isNaN(Number(key)));

  onTicketStateChanged(ticketId: number) {
    // debugger;
    // if (this.ticket.state === TicketState.Closed) this.ticket.state = TicketState.Open;
    // else this.ticket.state = TicketState.Closed;
    this.ticketStateChanged.emit(ticketId);
  }
}
