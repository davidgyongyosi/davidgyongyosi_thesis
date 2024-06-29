import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { EventsComponent } from './components/events/events.component';
import { MapComponent } from './components/map/map.component';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AddEventComponent } from './components/events/add-event/add-event.component';
import { AuthGuard } from './services/auth/auth.guard';
import { UsersComponent } from './components/users/users.component';
import { RolesComponent } from './components/roles/roles.component';
import { ArContentEditorComponent } from './components/ar-content-editor/ar-content-editor.component';

const routes: Routes = [
  { path: 'Home', component: HomeComponent, data: { title: 'Home' }},
  { path: 'Events', component: EventsComponent, data: { title: 'Events' }},
  { path: 'Map', component: MapComponent, data: { title: 'Map' }},
  { path: 'Profile', component: ProfileComponent, data: { title: 'Profile' }},
  { path: 'CreateEvent', component: AddEventComponent, data: { title: 'Create Events' }, canActivate: [AuthGuard]},
  { path: 'Users', component: UsersComponent, data: { title: 'Users' }, canActivate: [AuthGuard]},
  { path: 'Roles', component: RolesComponent, data: { title: 'Roles' }, canActivate: [AuthGuard]},
  { path: 'AR-Editor', component: ArContentEditorComponent, data: { title: 'AR Content Editor' }, canActivate: [AuthGuard]},
  { path: '',   redirectTo: '/Home', pathMatch: 'full' },
  { path: '**', component: PagenotfoundComponent , data: { title: 'Page not found!' }}
];
@NgModule({
  imports: [RouterModule.forRoot(routes, {enableTracing: false})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
