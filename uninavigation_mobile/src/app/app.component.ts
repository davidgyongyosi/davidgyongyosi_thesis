import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter, map, mergeMap } from 'rxjs';
import { AuthGuard } from './services/auth/auth.guard';
import { AuthService } from './services/auth/auth.service';
import { ModalController } from '@ionic/angular';
import { RegisterPage } from './pages/register/register.page';
import { LoginPage } from './pages/login/login.page';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  title = 'uninavigation_frontend';
  loggedIn: boolean = false;
  isMapRoute: boolean = false;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private titleService: Title,
    private authGuard: AuthGuard,
    private authService: AuthService,
    private modalController: ModalController
  ) {
    this.loggedIn = this.authGuard.isLoggedIn();
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
      this.isMapRoute = this.router.url.includes('/Maps');
      if (data && data.title) {
        this.titleService.setTitle('Uni Navigator: ' + data.title);
      } else {
        this.titleService.setTitle('Uni Navigator');
      }
    });
  }

  async openLoginModal() {
    const modal = await this.modalController.create({
      component: LoginPage
    });
    await modal.present();
    const { data } = await modal.onDidDismiss();
    if (data == 'confirm') {
      this.loggedIn = true;
    }
    else if (data == 'register') {
      this.openRegisterModal();
    }
  }

  async openRegisterModal() {
    const modal = await this.modalController.create({
      component: RegisterPage
    });
    await modal.present();

    const { data } = await modal.onDidDismiss();
    if (data == 'confirm') {
      this.openLoginModal();
    }
    else if (data == 'login') {
      this.openLoginModal();
    }
  }

  profileNavigate() {
    this.router.navigate(['/profile']);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('expiration');
    this.loggedIn = false;
    this.router.navigate(['/home']);
  }
}