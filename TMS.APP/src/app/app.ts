import { Component, signal } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { TicketsViewer } from './components/tickets-viewer/tickets-viewer';
import { AddNewTicket } from './components/add-new-ticket/add-new-ticket';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, TicketsViewer, AddNewTicket],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('tms.app');
}
