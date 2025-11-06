import { Routes } from '@angular/router';
import { TicketsViewer } from './components/tickets-viewer/tickets-viewer';
import { AddNewTicket } from './components/add-new-ticket/add-new-ticket';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'tickets',
    pathMatch: 'full',
  },
  {
    path: 'tickets',
    component: TicketsViewer,
  },
  {
    path: 'addnewticket',
    component: AddNewTicket,
  },
];
