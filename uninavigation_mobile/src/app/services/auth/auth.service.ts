import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { LoginModel } from '../../models/loginmodel'; 
import { RegisterModel } from '../../models/registermodel';
import { User } from '../../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url = 'Auth';
  constructor(private http: HttpClient) { }
  
  login(loginModel: LoginModel): Observable<string> {
    return this.http.post(`${environment.baseApiUrl}/${this.url}/Login`, loginModel, {
      responseType: 'text',
    });
  }
  
  register(registermodel: RegisterModel): Observable<any> {
    console.log(registermodel);
    return this.http.put<any>(`${environment.baseApiUrl}/${this.url}/InsertUser`, registermodel);
  }

  getUserInfo(): Observable<User> {
    return this.http.get<User>(`${environment.baseApiUrl}/${this.url}/detail`);
  }


  updateUserInfo(user: User): Observable<any> {
    return this.http.put(`${environment.baseApiUrl}/${this.url}/update`, user);
  }

  deleteAccount(): Observable<any> {
    return this.http.delete(`${environment.baseApiUrl}/${this.url}/DeleteMyself`);
  }
}