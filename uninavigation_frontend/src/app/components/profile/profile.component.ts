import { Component } from '@angular/core';
import { UpdateUserDTO, User } from '../../models/user';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { EventDetail } from '../../models/event.model';
import { EventService } from '../../services/event/event.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NotificationService } from '../../services/notification/notification.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent {
  user: User;
  router: Router;
  isEditing: boolean = false;
  error: string = '';
  events: EventDetail[] = [];
  updateModel: UpdateUserDTO = new UpdateUserDTO();

  constructor(
    private authService: AuthService,
    private eventService: EventService,
    router: Router,
    private message: NzMessageService,
    private notification: NotificationService
    
  ) {
    this.user = new User();
    this.router = router;
  }

  ngOnInit(): void {
    this.getUserInfo();
  }

  getUserInfo(): void {
    this.authService.getUserInfo().subscribe({
      next: (data) => {
        this.user = data;
        this.eventService.getEventUserById(this.user.userId).subscribe({
          next: (data) => {
            this.events = data;
          },
          error: (e) => {
            console.error(e);
            this.notification.error(e)
          },
        });
      },
      error: (e) => {
        console.error(e);
        this.notification.error(e.error);
      },
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
    this.getUserInfo();
  }

  cancelChanges(): void {
    this.toggleEdit();
  }

  saveChanges(): void {
    this.updateModel.userId = this.user.userId;
    this.updateModel.firstName = this.user.firstName;
    this.updateModel.lastName = this.user.lastName;
    this.updateModel.email = this.user.email;
    this.updateModel.picture = this.user.picture;

    this.authService.updateUserInfo(this.updateModel).subscribe({
      next: (response) => {
        this.isEditing = false;
        this.getUserInfo();
      },
      error: (e) => {

      },
    });
  }

  deleteAccount() {
    this.authService.deleteAccount().subscribe({
      next: (response) => {
        console.log(response);
        localStorage.setItem('token', '');
        localStorage.setItem('expiration', '');
        localStorage.clear();
        window.location.reload();
        this.router.navigate(['/Pagenotfound']);
      },
      error: (e) => {
        console.log('Error deleting acount:', e);
      },
    });
  }

  CreateBase64String(fileInput: any) {
    let reader = new FileReader();
    if (fileInput.target.files && fileInput.target.files.length > 0) {
      let file = fileInput.target.files[0];

      const img = new Image();
      img.src = window.URL.createObjectURL(file);

      reader.readAsDataURL(file);
      reader.onload = () => {
        const width = img.naturalWidth;
        const height = img.naturalHeight;

        window.URL.revokeObjectURL(img.src);

        if (width >= 512 && height >= 512) {
          this.error = 'photo should be smaller then 512px x 512px';
        }
        //this.imagePreview = reader.result;
        this.user.picture = reader.result as string;
      };
    }
  }

  unattendEvent(id: number) {
    this.eventService.unattendEvent(this.user.userId, id).subscribe({
      next: (response) => {
        this.message.success(
          'Successfully unattended the event',
          {
            nzDuration: 5000,
          }
        );
        this.eventService.getEventUserById(this.user.userId).subscribe({
          next: (data) => {
            this.events = data;
          },
          error: (e) => {
            console.error(e);
          },
        });
      },
    });
  }

  getBase64ImageSrc(data: string, contentType: string): string {
    if (data && contentType) {
      return `data:${contentType};base64,${data}`;
    }
    return 'https://via.placeholder.com/400x200?text=No+Image+Available';
  }
}
