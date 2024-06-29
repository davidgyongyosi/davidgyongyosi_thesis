import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  private url = 'Roles';

  constructor(private http: HttpClient) {}

  createRole(roleName: string): Observable<any> {
    return this.http.post<any>(`${environment.baseApiUrl}/${this.url}`, { roleName });
  }

  getRoles(): Observable<RoleResponse> {
    return this.http.get<RoleResponse>(`${environment.baseApiUrl}/${this.url}`);
  }

  deleteRole(id: string): Observable<any> {
    return this.http.delete<any>(`${environment.baseApiUrl}/${this.url}/${id}`);
  }

  assignRole(userId: string, roleId: string): Observable<any> {
    return this.http.post<any>(`${environment.baseApiUrl}/${this.url}/assign`, { userId, roleId });
  }

  getUserRole(id: string): Observable<any> {
    return this.http.get<any>(`${environment.baseApiUrl}/${this.url}/user/${id}`);
  }
}

interface RoleResponse {
  id: string | null;
  name: string | null;
  totalUsers: number;
}
