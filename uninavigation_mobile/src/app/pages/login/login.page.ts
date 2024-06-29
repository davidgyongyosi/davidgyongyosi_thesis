import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';
import { LoginModel } from 'src/app/models/loginmodel';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage {

  loginModel: LoginModel = new LoginModel();
  loginFailed = false;
  constructor(
    private authService: AuthService, 
    private modalCtrl: ModalController
  ) { 
  }

  login() {
    if (this.loginModel.username != '' && this.loginModel.password != '') {
      this.authService.login(this.loginModel).subscribe({
        next: (data) => {
          const { token, expiration, role } = JSON.parse(data);
          localStorage.setItem('token', token);
          localStorage.setItem('expiration', expiration);
          localStorage.setItem('role', role);
          this.modalCtrl.dismiss('confirm');
        },
        error: (e) => {
          console.error(e);
          this.loginFailed = true;
        }
      });
    }
    else {
      this.loginFailed = true;
    }
  }

  signup() {
    this.modalCtrl.dismiss('register');
  }

  cancel() {
    this.modalCtrl.dismiss();
  }
}
