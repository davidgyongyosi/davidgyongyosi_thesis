import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { ModalController } from '@ionic/angular';
import { RegisterModel } from 'src/app/models/registermodel';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage {
  registerFailed = false;
  registerModel: RegisterModel = new RegisterModel();
  constructor(
    private authService: AuthService,
    private modalCtrl: ModalController
  ) {}

  register() {
    if (this.registerModel.email != '' &&
        this.registerModel.firstname != '' &&
        this.registerModel.lastname != '' && 
        this.registerModel.password != '' &&
        this.registerModel.username != ''
    ) {
      this.authService.register(this.registerModel).subscribe({
        next: (data) => {
          this.registerFailed = false;
          this.modalCtrl.dismiss('confirm');
        },
        error: (e) => console.error(e),
      });
    }
    else {
      this.registerFailed = true;
    }
  }

  login() {
    this.modalCtrl.dismiss('login');
  }

  cancel() {
    this.modalCtrl.dismiss();
  }
}