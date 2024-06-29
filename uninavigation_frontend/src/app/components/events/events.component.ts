import { Component, Input } from '@angular/core';
import { EventService } from '../../services/event/event.service';
import { EventDetail, EventList } from '../../models/event.model';
import { AuthService } from '../../services/auth/auth.service';
import { AuthGuard } from '../../services/auth/auth.guard';
import { User } from '../../models/user';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { EditEventComponent } from './edit-event/edit-event.component';
import { FontType } from 'ng-zorro-antd/water-mark';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrl: './events.component.scss',
})
export class EventsComponent {
  user?: User;
  events?: EventDetail[];
  participantCount: number = 0;
  userLoggedIn: boolean = false;
  userIsAdmin: boolean = false;
  isLoading = false;
  font: FontType = {
    color: 'red',
    fontSize: 24
  };

  constructor(
    private eventService: EventService,
    private authGuard: AuthGuard,
    private authService: AuthService,
    private message: NzMessageService,
    private modal: NzModalService
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
      this.events = data;
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
      this.eventService.attendEvent(id, this.user?.userId).subscribe((data) => {
        this.message.success('Successfully attended the event', {
          nzDuration: 5000,
        });
        this.loadEvents();
      });
  }

  openEditModal(event: EventDetail): void {
    const modalRef = this.modal.create({
      nzTitle: 'Edit Event',
      nzContent: EditEventComponent,
      nzFooter: null,
      nzData: {
        event: event,
      },
    });

    const instance = modalRef.getContentComponent();
    instance.onClose.subscribe(() => {
      this.loadEvents();
      modalRef.close();
    });
  }

  getBase64ImageSrc(data: string, contentType: string): string {
    if (data && contentType) {
      return `data:${contentType};base64,${data}`;
    }
    return 'https://via.placeholder.com/400x200?text=No+Image+Available'; // default placeholder
  }

  eventHasEnded(endTime: Date): boolean {
    const end = new Date(endTime).getTime();
    const now = new Date().getTime();
    return end < now;
  }

  deleteEvent(id: number) {
    this.eventService.deleteEvent(id).subscribe((data) => {
      this.message.success('Successfully deleted the event', {
        nzDuration: 5000,
      });
      this.loadEvents();
    });
  }
}
