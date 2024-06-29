import { ChangeDetectorRef, Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EventService } from '../../../services/event/event.service';
import { CreateEvent } from '../../../models/event.model';
import { Location } from '../../../models/location.model';
import { LocationService } from '../../../services/location/location.service';
import { NotificationService } from '../../../services/notification/notification.service';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrl: './add-event.component.scss'
})
export class AddEventComponent {
  eventForm: FormGroup;
  event!: CreateEvent;
  picture?: File;
  locations: Location[] = [];
  firstDateAvailable: Date = new Date();

  constructor(private fb: FormBuilder,
    private eventService: EventService,
    private cd: ChangeDetectorRef,
    private locService: LocationService,
    private notification: NotificationService) {
    this.eventForm = this.fb.group({
      name: [null, [Validators.required]],
      startTime: [null, [Validators.required]],
      endTime: [null, [Validators.required]],
      location: [null, [Validators.required]],
      description: [null, [Validators.required]],
      picture: [null, [Validators.required]]
    });

    this.loadLocations();

    const today = new Date();
    this.firstDateAvailable.setDate(today.getDate());
  }

  onFileSelected(event: Event): void {
    const element = event.currentTarget as HTMLInputElement;
    let file: File | null = element.files ? element.files[0] : null;
    if (file) {
      this.picture = file;
      this.cd.markForCheck();
    }
  }

  disableStartDate = (startValue: Date): boolean => {
    return !startValue || startValue.getTime() <= this.firstDateAvailable.getTime();
  }

  disableEndDate = (endValue: Date): boolean => {
    if (!endValue || !this.eventForm.get('startTime')?.value) {
      return true;
    }
    const startValue = new Date(this.eventForm.get('startTime')?.value);
    return endValue.getTime() <= startValue.getTime();
  }

  submitForm(): void {
    if (this.eventForm.valid && this.picture) {
      const formData = new FormData();
      
      formData.append('picture', this.picture);
      formData.append('name', this.eventForm.get('name')?.value);
      formData.append('startTime', this.eventForm.get('startTime')?.value.toISOString());
      formData.append('endTime', this.eventForm.get('endTime')?.value.toISOString());
      formData.append('location', this.eventForm.get('location')?.value);
      formData.append('description', this.eventForm.get('description')?.value);
  
      this.eventService.createEvent(formData).subscribe({
        next: () => {
          this.notification.success(`Successfully created ${this.eventForm.get('name')?.value} event`);
          this.eventForm.reset();
          this.cd.markForCheck();
        },
        error: error => {
          this.notification.error(error.error);
        }
      });
    } else {
      // Handle form validation errors
      Object.values(this.eventForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
      if (!this.picture) {
        this.notification.error('Please upload a picture!');
      }
    }
  }
  
  loadLocations(): void {
    this.locService.getAllLocations().subscribe(resp => {
      this.locations = resp;
    }
    )
  }
}
