import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Location } from '../../models/location.model';

@Injectable({
  providedIn: 'root',
})
export class LocationService {
  private url = 'Location';

  constructor(private http: HttpClient) {}

  getAllLocations(): Observable<Location[]> {
    return this.http.get<Location[]>(`${environment.baseApiUrl}/${this.url}`);
  }

  addLocations(locations: Location[]): Observable<void> {
    return this.http.post<void>(
      `${environment.baseApiUrl}/${this.url}`,
      locations
    );
  }

  deleteLocation(locationId: number): Observable<void> {
    return this.http.delete<void>(
      `${environment.baseApiUrl}/${this.url}/${locationId}`
    );
  }

  updateLocation(location: Location): Observable<void> {
    return this.http.put<void>(
      `${environment.baseApiUrl}/${this.url}/${location.id}`,
      location
    );
  }

  restoreLocations(): Observable<any> {
    return this.http.get<any>(`${environment.baseApiUrl}/${this.url}/restore`);
  }
}
