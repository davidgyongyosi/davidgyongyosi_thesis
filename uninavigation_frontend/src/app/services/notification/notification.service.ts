import { Injectable } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Injectable({ providedIn: 'root' })
export class NotificationService {
  constructor(private notification: NzNotificationService) { }

  error(message: string) {
    this.notification.create(
      'error',
      'Error',
      message, {
      nzClass: 'error-notification',
    });
  }

  success(message: string) {
    this.notification.create(
      'success',
      'Success',
      message, {
      nzClass: 'success-notification',
    })
  }

  warning(message: string) {
    this.notification.create(
      'warning',
      'Warning',
      message, {
      nzClass: 'warning-notification',
    })
  }

  info(message: string) {
    this.notification.create(
      'info',
      'Info',
      message, {
      nzClass: 'info-notification',
    })
  }
}
