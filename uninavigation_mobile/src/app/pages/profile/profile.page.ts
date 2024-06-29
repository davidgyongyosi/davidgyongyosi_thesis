import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventDetail } from 'src/app/models/event.model';
import { User } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth/auth.service';
import { EventService } from 'src/app/services/event/event.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {
  user: User;
  router: Router
  isEditing: boolean = false;
  error: string = "";
  segment: string = "details";
  events: EventDetail[] = [];

  constructor(private authService: AuthService, router: Router, private eventService: EventService) {
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
          },
        });
      },
      error: (e) => {
        console.error(e);
      },
    });
  }

  CreateBase64String(fileInput: any) {
    let reader = new FileReader();
     if (fileInput.target.files && fileInput.target.files.length > 0) {
       let file = fileInput.target.files[0];

       const img = new Image();
       img.src = window.URL.createObjectURL( file );

       reader.readAsDataURL(file);
       reader.onload = () => {

         const width = img.naturalWidth;
         const height = img.naturalHeight;

         window.URL.revokeObjectURL( img.src );

         if( width >= 512 && height >= 512 ) {
            this.error = "photo should be smaller then 512px x 512px"
         }
         //this.imagePreview = reader.result;
         this.user.picture = reader.result as string;
     };
    }
  }

  unattendEvent(id: number) {
    this.eventService.unattendEvent(this.user.userId, id).subscribe({
      next: (response) => {
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
