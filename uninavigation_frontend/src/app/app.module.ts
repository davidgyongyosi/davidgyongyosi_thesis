import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient } from '@angular/common/http';
import { AuthInterceptor } from './services/auth/auth.interceptor';

import { AppRoutingModule } from './app-routing.module';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { EventsComponent } from './components/events/events.component';
import { AddEventComponent } from './components/events/add-event/add-event.component';
import { EditEventComponent } from './components/events/edit-event/edit-event.component';
import { MapComponent } from './components/map/map.component';
import { PagenotfoundComponent } from './components/pagenotfound/pagenotfound.component';
import { ProfileComponent } from './components/profile/profile.component';
import { UsersComponent } from './components/users/users.component';
import { RolesComponent } from './components/roles/roles.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzIconModule} from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzNotificationModule } from 'ng-zorro-antd/notification';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzWaterMarkModule } from 'ng-zorro-antd/water-mark';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';


import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { provideNzI18n, en_US } from 'ng-zorro-antd/i18n';
import { ArContentEditorComponent } from './components/ar-content-editor/ar-content-editor.component';
import { ArEditModalComponent } from './components/ar-content-editor/ar-edit-modal/ar-edit-modal.component';
import { ArAddModalComponent } from './components/ar-content-editor/ar-add-modal/ar-add-modal.component';

registerLocaleData(en);


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    EventsComponent,
    MapComponent,
    PagenotfoundComponent,
    ProfileComponent,
    AddEventComponent,
    EditEventComponent,
    UsersComponent,
    RolesComponent,
    ArContentEditorComponent,
    ArEditModalComponent,
    ArAddModalComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    //Ng zorro imports
    NzLayoutModule,
    NzMenuModule,
    NzDividerModule,
    NzIconModule,
    NzButtonModule,
    NzFormModule,
    NzInputModule,
    NzTabsModule,
    NzModalModule,
    NzCardModule,
    NzToolTipModule,
    NzDatePickerModule,
    NzMessageModule,
    NzUploadModule,
    NzSelectModule,
    NzDropDownModule,
    NzSpinModule,
    NzTableModule,
    NzListModule,
    NzNotificationModule,
    NzAvatarModule,
    NzPageHeaderModule,
    NzWaterMarkModule,
    NzPaginationModule,
    NzCheckboxModule,

    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    provideAnimationsAsync(),
    provideNzI18n(en_US),
    provideHttpClient(),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
