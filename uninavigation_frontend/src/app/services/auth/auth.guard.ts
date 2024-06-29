import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  constructor(private router: Router,private authService: AuthService) {}

  public isLoggedIn(): boolean {
    let token = localStorage.getItem('token');
    return token !== null;
  }

  public isAdmin(): boolean {
    let isAdmin = localStorage.getItem('role');
    return isAdmin == 'Admin';
  }

  public canActivate(): boolean {
    if (!this.isAdmin()) {
      this.router.navigate(['/Home']);
      return false;
    }
    return true;
  }
}
