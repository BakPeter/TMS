import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../model/Tikcet';
import { Observable } from 'rxjs';
import { UpdateTicketStateDto } from '../model/UpdateTicketStateDto';

@Injectable({
  providedIn: 'root',
})
export class TicketsViewerService {
  host: string = 'http://localhost:5093/api';

  constructor(private http: HttpClient) {}

  getAllTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.host + '/Tickets');
  }

  updateTicketState(udpateTicketDto: UpdateTicketStateDto): Observable<Ticket> {
    return this.http.put<Ticket>(this.host + '/Tickets', udpateTicketDto);
  }
}
