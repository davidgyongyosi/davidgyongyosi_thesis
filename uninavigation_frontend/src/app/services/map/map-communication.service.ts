import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MapCommunicationService {
  private locationSource = new Subject<string>();
  location$ = this.locationSource.asObservable();

  sendLocation(location: string) {
    this.locationSource.next(location);
  }
}
