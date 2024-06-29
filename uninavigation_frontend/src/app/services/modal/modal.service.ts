import { EventEmitter, Injectable, Output } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { LoginComponent } from '../../components/login/login.component';
import { RegisterComponent } from '../../components/register/register.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  loginSuccess = new EventEmitter<boolean>();

  constructor(private modalService: NzModalService) {}

  openLoginModal(): void {
    const modalRef = this.modalService.create({
      nzTitle: 'Login',
      nzContent: LoginComponent,
      nzFooter: null,
    });

    const instance = modalRef.getContentComponent();
    instance.onClose.subscribe(() => modalRef.close());
    instance.onLoginSuccess.subscribe(() => {
      modalRef.close()
      this.loginSuccess.emit();
    } );
    instance.onRegisterClick.subscribe(() => {
      modalRef.close();
      this.openRegisterModal();
      
    });
  }

  openRegisterModal(): void {
    const modalRef = this.modalService.create({
      nzTitle: 'Register',
      nzContent: RegisterComponent,
      nzFooter: null,
    });

    const instance = modalRef.getContentComponent();
    instance.onClose.subscribe(() => modalRef.close());
    instance.onRegisterSuccess.subscribe(() => modalRef.close());
    instance.onLoginClick.subscribe(() => {
      modalRef.close();
      this.openLoginModal(); // Automatically open the Login modal
    });
  }
}
