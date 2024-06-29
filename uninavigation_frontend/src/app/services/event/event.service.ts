import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  EventList,
  EventDetail,
  CreateEvent,
  UpdateEvent,
} from '../../models/event.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private url = 'Events';

  constructor(private http: HttpClient) {}

  getAllEvents(): Observable<EventDetail[]> {
    return this.http.get<EventDetail[]>(
      `${environment.baseApiUrl}/${this.url}`
    );
  }

  getEventById(id: number): Observable<EventDetail> {
    return this.http.get<EventDetail>(
      `${environment.baseApiUrl}/${this.url}/${id}`
    );
  }

  getEventUserById(id: string): Observable<EventDetail[]> {
    return this.http.get<EventDetail[]>(
      `${environment.baseApiUrl}/${this.url}/user-events/${id}`
    );
  }

  createEvent(eventData: FormData): Observable<EventDetail> {
    return this.http.post<EventDetail>(
      `${environment.baseApiUrl}/${this.url}`,
      eventData
    );
  }

  updateEvent(id: number, eventData: FormData): Observable<void> {
    return this.http.put<void>(
      `${environment.baseApiUrl}/${this.url}/${id}`,
      eventData
    );
  }

  deleteEvent(id: number): Observable<void> {
    return this.http.delete<void>(
      `${environment.baseApiUrl}/${this.url}/${id}`
    );
  }

  attendEvent(eventId: number, userId: string): Observable<void> {
    return this.http.post<void>(
      `${environment.baseApiUrl}/${this.url}/${eventId}/attend`,
      { userId }
    );
  }

  unattendEvent(userId: string, eventId: number): Observable<void> {
    return this.http.delete<void>(
      `${environment.baseApiUrl}/${this.url}/${eventId}/unattend/${userId}`
    );
  }
}
