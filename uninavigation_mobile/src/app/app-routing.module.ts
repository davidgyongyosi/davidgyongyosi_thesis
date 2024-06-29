import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { RegisterPage } from './pages/register/register.page';
import { HomePage } from './pages/home/home.page';
import { MapPage } from './pages/map/map.page';
import { LoginPage } from './pages/login/login.page';
import { ProfilePage } from './pages/profile/profile.page';
import { PagenotfoundPage } from './pages/pagenotfound/pagenotfound.page';
import { EventsPage } from './pages/events/events.page';
import { ARViewPage } from './pages/arview/arview.page';

const routes: Routes = [
  { path: 'home', component: HomePage, data: { title: 'Home' }},
  { path: 'arview', component: ARViewPage, data: { title: 'ARView' }},
  { path: 'events', component: EventsPage, data: { title: 'Events' }},
  { path: 'map', component: MapPage, data: { title: 'Map' }},
  { path: 'login', component: LoginPage, data: { title: 'Login' }},
  { path: 'register', component: RegisterPage, data: { title: 'Register' }},
  { path: 'profile', component: ProfilePage, data: { title: 'Profile' }},
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: PagenotfoundPage , data: { title: 'Page not found!' }},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
