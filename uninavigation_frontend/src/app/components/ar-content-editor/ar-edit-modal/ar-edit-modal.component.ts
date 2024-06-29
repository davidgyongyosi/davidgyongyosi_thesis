import { Component, EventEmitter } from '@angular/core';
import { ArContent } from '../../../models/ar_content.model';
import { NzModalRef } from 'ng-zorro-antd/modal';
import { ArService } from '../../../services/ar/ar.service';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { LocationService } from '../../../services/location/location.service';
import { Location } from '../../../models/location.model';
import { NotificationService } from '../../../services/notification/notification.service';

interface MaxSizeMap {
  [key: string]: number;
  jpg: number;
  jpeg: number;
  png: number;
}

@Component({
  selector: 'app-ar-edit-modal',
  templateUrl: './ar-edit-modal.component.html',
  styleUrl: './ar-edit-modal.component.scss',
})
export class ArEditModalComponent {
  onClose = new EventEmitter<void>();
  content!: ArContent;
  editForm: FormGroup;
  locations?: Array<Location>;

  constructor(
    private modalRef: NzModalRef,
    private arService: ArService,
    private fb: FormBuilder,
    private locService: LocationService,
    private notification: NotificationService
  ) {
    this.content = this.modalRef.getConfig().nzData.data;
    this.loadLocations();

    this.editForm = this.fb.group({
      roomName: ['', [Validators.required]],
      elevation: [0, [Validators.required]],
      longitude: ['', [Validators.required]],
      latitude: ['', [Validators.required]],
      content: [null, [Validators.required, this.fileValidator()]],
    });
  }

  ngOnInit(): void {
    if (this.content) {
      this.editForm.patchValue(this.content);
    }
  }

  loadLocations(): void {
    this.locService.getAllLocations().subscribe((resp) => {
      this.locations = resp;
    });
  }

  saveChanges(): void {
    if (this.editForm.invalid) {
      this.notification.error('Please fill in all required fields');
      return;
    }
    this.content.elevation = this.editForm.get('elevation')?.value;
    this.content.roomName = this.editForm.get('roomName')?.value;
    this.content.longitude = this.editForm.get('longitude')?.value;
    this.content.latitude = this.editForm.get('latitude')?.value;

    this.arService.updateContent(this.content).subscribe({
      next: (resp) => {
        this.notification.success(resp.message);
      },
      error: (error) => {
        this.notification.error(error.error);
      },
      complete: () => {
        this.onClose.emit();
      },
    });
    this.onClose.emit();
  }
  cancel() {
    this.onClose.emit();
  }

  fileValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const file = control.value;
      if (file) {
        const fileExtension = file.name?.split('.').pop().toLowerCase();
        const fileType = file.type;
        const fileSize = file.size;

        // Define file type and size limits
        const allowedExtensions = ['jpg', 'jpeg', 'png'];
        const maxSizes: MaxSizeMap = {
          jpg: 15 * 1024 * 1024, // 15MB
          jpeg: 15 * 1024 * 1024, // 15MB
          png: 15 * 1024 * 1024, // 15MB
        };

        const maxFileSize = maxSizes[fileExtension as keyof MaxSizeMap] || 0;

        // Check file extension and size
        if (
          !allowedExtensions.includes(fileExtension) ||
          fileSize > maxFileSize
        ) {
          return {
            fileType: !allowedExtensions.includes(fileExtension),
            fileSize: fileSize > maxFileSize,
          };
        }
      }
      return null; // Return null if no errors
    };
  }

  onFileSelected(event: Event) {
    const element = event.target as HTMLInputElement;
    const file = element.files ? element.files[0] : null;
    if (file) {
      this.editForm
        .get('content')
        ?.setValue(file, { emitModelToViewChange: false });
    }
  }

  CreateBase64String(fileInput: any) {
    let reader = new FileReader();
    if (fileInput.target.files && fileInput.target.files.length > 0) {
      let file = fileInput.target.files[0];

      const img = new Image();
      img.src = window.URL.createObjectURL(file);

      reader.readAsDataURL(file);
      reader.onload = () => {
        window.URL.revokeObjectURL(img.src);
        this.content.content = reader.result as string;
        this.content.contentName = file.name;
      };
    }
  }
}
