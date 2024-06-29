import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { LoginModel } from '../../models/loginmodel';
import { RegisterModel } from '../../models/registermodel';
import { UpdateUserDTO, User, UserDetailDTO } from '../../models/user';

interface LoginResponse {
  token: string;
  expiration: string;
  role: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url = 'Auth';

  constructor(private http: HttpClient) {}

  login(loginModel: LoginModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(
      `${environment.baseApiUrl}/${this.url}/Login`,
      loginModel
    );
  }

  register(registermodel: RegisterModel): Observable<any> {
    console.log(registermodel);
    return this.http.put<any>(
      `${environment.baseApiUrl}/${this.url}/register`,
      registermodel
    );
  }

  getUserInfo(): Observable<User> {
    return this.http.get<User>(`${environment.baseApiUrl}/${this.url}/detail`);
  }

  updateUserInfo(user: UpdateUserDTO): Observable<any> {
    return this.http.post(`${environment.baseApiUrl}/${this.url}/update`, user);
  }

  deleteAccount(): Observable<any> {
    return this.http.delete(
      `${environment.baseApiUrl}/${this.url}/delete`
    );
  }

  deleteUser(id: string): Observable<any> {
    return this.http.delete(
      `${environment.baseApiUrl}/${this.url}/delete/${id}`
    );
  }

  getUsers(): Observable<UserDetailDTO[]> {
    return this.http.get<UserDetailDTO[]>(`${environment.baseApiUrl}/${this.url}/users`);
  }
}
