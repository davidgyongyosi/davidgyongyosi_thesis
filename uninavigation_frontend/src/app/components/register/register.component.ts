import { Component, EventEmitter, Output } from '@angular/core';
import { RegisterModel } from '../../models/registermodel';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  registerModel = new RegisterModel();
  @Output() onClose = new EventEmitter<void>();
  @Output() onRegisterSuccess = new EventEmitter<void>();
  @Output() onLoginClick = new EventEmitter<void>();

  RegisterForm: FormGroup<{
    email: FormControl<string>;
    username: FormControl<string>;
    firstname: FormControl<string>;
    lastname: FormControl<string>;
    password: FormControl<string>;
  }>;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder
  ) {
    this.RegisterForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      username: ['', [Validators.required]],
      firstname: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      password: ['', [Validators.required]]
    }) as FormGroup<{
      email: FormControl<string>;
      username: FormControl<string>;
      firstname: FormControl<string>;
      lastname: FormControl<string>;
      password: FormControl<string>;
    }>;
  }

  register() {
    if (this.RegisterForm.valid) {
      this.registerModel.email = this.RegisterForm.value.email;
      this.registerModel.firstname = this.RegisterForm.value.firstname;
      this.registerModel.lastname = this.RegisterForm.value.lastname;
      this.registerModel.username = this.RegisterForm.value.username;
      this.registerModel.PictureData = '';
      this.registerModel.PictureContentType = '';
      this.registerModel.password = this.RegisterForm.value.password;

      this.authService.register(this.RegisterForm.value).subscribe({
        next: (data) => {
          this.onRegisterSuccess.emit(); // Notify parent component of success
          // Optionally close the modal here or let the parent component handle it
        },
        error: (e) => console.error(e),
      });
    }
  }

  login() {
    this.onLoginClick.emit();
  }
}
