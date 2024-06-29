import { Component, EventEmitter, Output } from '@angular/core';
import { LoginModel } from '../../models/loginmodel';
import { AuthService } from '../../services/auth/auth.service';
import { FormControl, FormGroup, NonNullableFormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginModel: LoginModel = new LoginModel();
  loginFailed = false;
  @Output() onClose = new EventEmitter<void>();
  @Output() onLoginSuccess = new EventEmitter<void>();
  @Output() onRegisterClick = new EventEmitter<void>();

  validateForm: FormGroup<{
    userName: FormControl<string>;
    password: FormControl<string>;
  }> = this.fb.group({
    userName: ['', [Validators.required]],
    password: ['', [Validators.required]]
  });

  constructor(
    private authService: AuthService, 
    private fb: NonNullableFormBuilder
  ) { }

  login() {
    if (this.validateForm.valid) {
      this.loginModel.username = this.validateForm.value.userName;
      this.loginModel.password = this.validateForm.value.password;
      
      this.authService.login(this.loginModel).subscribe({
        next: (data) => {
          localStorage.setItem('token', data.token);
          localStorage.setItem('expiration', data.expiration);
          localStorage.setItem('role', data.role);
          //this.authService.startTimer();
          this.onLoginSuccess.emit();
        },
        error: (e) => {
          console.error(e);
          this.loginFailed = true;
        }
      });
    }
  }

  signup() {
    this.onRegisterClick.emit();
  }
}
