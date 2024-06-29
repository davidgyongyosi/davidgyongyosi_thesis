import { ChangeDetectorRef, Component, EventEmitter, Output } from '@angular/core';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { EventDetail } from '../../../models/event.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LocationService } from '../../../services/location/location.service';
import { Location } from '../../../models/location.model';
import { EventService } from '../../../services/event/event.service';
import { NotificationService } from '../../../services/notification/notification.service';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrl: './edit-event.component.scss',
})
export class EditEventComponent {
  event!: EventDetail;
  eventForm: FormGroup;
  locations: Location[] = [];
  picture?: File;

  firstDateAvailable: Date = new Date();

  @Output() onClose = new EventEmitter<void>();

  constructor(
    private modalRef: NzModalRef,
    private fb: FormBuilder,
    private locService: LocationService,
    private cd: ChangeDetectorRef,
    private eventService: EventService,
    private notification: NotificationService
  ) {
    this.event = this.modalRef.getConfig().nzData.event;

    this.eventForm = this.fb.group({
      name: [null, [Validators.required]],
      startTime: [null, [Validators.required]],
      endTime: [null, [Validators.required]],
      location: [null, [Validators.required]],
      description: [null, [Validators.required]],
      picture: [null],
    });

    this.loadLocations();

    const today = new Date();
    this.firstDateAvailable.setDate(today.getDate());
  }

  disableStartDate = (startValue: Date): boolean => {
    return !startValue || startValue.getTime() < this.firstDateAvailable.getTime();
  }

  disableEndDate = (endValue: Date): boolean => {
    if (!endValue || !this.eventForm.get('startTime')?.value) {
      return true;
    }
    return new Date(this.eventForm.get('startTime')?.value).getTime() >= endValue.getTime();
  }

  loadLocations(): void {
    this.locService.getAllLocations().subscribe((resp) => {
      this.locations = resp;
    });
  }

  onFileSelected(event: Event): void {
    const element = event.currentTarget as HTMLInputElement;
    let file: File | null = element.files ? element.files[0] : null;
    if (file) {
      this.picture = file;
      this.cd.markForCheck();
    }
  }

  submitForm(): void {
    if (this.eventForm.valid && this.picture) {
      const formData = new FormData();

      formData.append('picture', this.picture);
      formData.append('name', this.eventForm.get('name')?.value);
      formData.append(
        'startTime',
        this.eventForm.get('startTime')?.value.toISOString()
      );
      formData.append(
        'endTime',
        this.eventForm.get('endTime')?.value.toISOString()
      );
      formData.append('location', this.eventForm.get('location')?.value);
      formData.append('description', this.eventForm.get('description')?.value);

      this.eventService.updateEvent(this.event.eventId!, formData).subscribe({
        next: () => {
          this.notification.success(`Successfully created ${this.eventForm.get('name')?.value} event`);
          this.eventForm.reset();
          this.cd.markForCheck();
        },
        error: (error) => {
          this.notification.error(error.error);
        },
      });
    } else {
      // Handle form validation errors
      Object.values(this.eventForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
      if (!this.picture) {
        //this.message.error('Please upload a picture!', { nzDuration: 5000 });
        this.notification.error('Please upload a picture!');
      }
    }
    this.onClose.emit();
  }

  deleteEvent() {
    this.eventService.deleteEvent(
    this.event.eventId!).subscribe({
      next: (response) => {
        this.onClose.emit();
      },
      error: (err) => {
        console.error(err);
      }
    })
  }
}
