import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter, map, mergeMap } from 'rxjs';
import { AuthGuard } from './services/auth/auth.guard';
import { ModalService } from './services/modal/modal.service';
import { AuthService } from './services/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Uni Navigator';
  loggedIn: boolean = false;
  isMapRoute: boolean = false;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private titleService: Title,
    private authGuard: AuthGuard,
    private authService: AuthService,
    private modalService: ModalService
  ) {
    this.loggedIn =  this.authGuard.isLoggedIn();
  }

  checkLoginStatus() {
    this.loggedIn = this.authGuard.isLoggedIn();
  }

  isAdmin(): boolean {
    return this.authGuard.canActivate();
  }

  ngOnInit() {
    
    const currentDate = new Date();
    const tokenExpiration = localStorage.getItem('expiration');

if (tokenExpiration) {
    const expirationDate = new Date(tokenExpiration);
    if (!isNaN(expirationDate.getTime()) && currentDate >= expirationDate) {
        this.logout();
      }
    }

    this.modalService.loginSuccess.subscribe(loggedIn => {
      this.loggedIn = loggedIn;
      this.checkLoginStatus();
    });

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd),
      map(() => this.activatedRoute),
      map(route => {
        while (route.firstChild) {
          route = route.firstChild;
        }
        return route;
      }),
      filter(route => route.outlet === 'primary'),
      mergeMap(route => route.data)
    ).subscribe((data: any) => {
      this.isMapRoute = this.router.url.includes('/Map');
      if (data && data.title) {
        this.titleService.setTitle('Uni Navigator: ' + data.title);
        this.title = data.title;
      } else {
        this.titleService.setTitle('Uni Navigator');
      }
    });
  }

  openLogin() {
    this.modalService.openLoginModal();
  }

  openRegister() {
    this.modalService.openRegisterModal();
  }

  profileNavigate(){
    this.router.navigate(['/Profile']);
  }

  logout(){
    localStorage.setItem('token', '');
    localStorage.setItem('expiration', '');
    localStorage.clear();
    this.loggedIn = false;
    this.router.navigate(['/Home']);
    //this.authService.logout();
  }
}
