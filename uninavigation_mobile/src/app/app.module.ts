import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './services/auth/auth.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterPage } from './pages/register/register.page';
import { LoginPage } from './pages/login/login.page';
import { HomePage } from './pages/home/home.page';
import { MapPage } from './pages/map/map.page';
import { EventsPage } from './pages/events/events.page';
import { PagenotfoundPage } from './pages/pagenotfound/pagenotfound.page';
import { ProfilePage } from './pages/profile/profile.page';
import { ArContentComponent } from './pages/ar-content/ar-content.component';
import { ARViewPage } from './pages/arview/arview.page';

@NgModule({
  declarations: [
    AppComponent,
    EventsPage,
    HomePage,
    LoginPage,
    MapPage,
    PagenotfoundPage,
    RegisterPage,
    ProfilePage,
    ArContentComponent,
    ARViewPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {}
