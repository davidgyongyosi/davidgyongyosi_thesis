import { Component, OnInit } from '@angular/core';
import { EventService } from '../../services/event/event.service';
import { EventDetail, EventList } from '../../models/event.model';
import { AuthGuard } from 'src/app/services/auth/auth.guard';
import { AuthService } from 'src/app/services/auth/auth.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-events',
  templateUrl: './events.page.html',
  styleUrls: ['./events.page.scss'],
})
export class EventsPage {
  user?: User;
  events?: EventDetail[];
  participantCount: number = 0;
  userLoggedIn: boolean = false;
  userIsAdmin: boolean = false;
  isLoading = false;

  constructor(
    private eventService: EventService,
    private authGuard: AuthGuard,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.loadEvents();
    this.userLoggedIn = this.authGuard.isLoggedIn();
    this.userIsAdmin = this.authGuard.isAdmin();
    if (this.userLoggedIn)
      {
        this.authService.getUserInfo().subscribe((data) => {
          this.user = data;
        });
      }
  }

  loadEvents(): void {
    this.isLoading = true;
    this.eventService.getAllEvents().subscribe((data) => {
      this.events = data.filter((event) => new Date(event.endTime).getTime() > new Date().getTime());
      this.isLoading = false;
    });
  }

  isUserAttending(event: EventDetail): boolean {
    if (event.participants != null)
      return event.participants?.some(
        (participant) => participant.userId === this.user?.userId
      );
    else return false;
  }

  attendEvent(id: number) {
    if (this.user != null)
      this.eventService.attendEvent(id, this.user?.userId).subscribe(() => {
        this.loadEvents();
      });
  }

  getBase64ImageSrc(data: string, contentType: string): string {
    if (data && contentType) {
      return `data:${contentType};base64,${data}`;
    }
    return 'https://via.placeholder.com/400x200?text=No+Image+Available';
  }

}
