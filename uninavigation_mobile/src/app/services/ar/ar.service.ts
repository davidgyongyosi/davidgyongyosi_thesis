import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ArContent } from '../../models/ar_content.model';

@Injectable({
  providedIn: 'root'
})
export class ArService {
  private url = 'ArContent';

  constructor(private http: HttpClient) {}

  getAllContents(): Observable<ArContent[]> {
    return this.http.get<ArContent[]>(
      `${environment.baseApiUrl}/${this.url}`
    );
  }

  getContentById(id: number): Observable<ArContent> {
    return this.http.get<ArContent>(
      `${environment.baseApiUrl}/${this.url}/${id}`
    );
  }

  createContent(content: ArContent): Observable<ArContent> {
    return this.http.post<ArContent>(
      `${environment.baseApiUrl}/${this.url}`,
      content
    );
  }

  updateContent(content: ArContent): Observable<any> {
    return this.http.put<any>(
      `${environment.baseApiUrl}/${this.url}`,
      content
    );
  }

  deleteContent(id: number): Observable<void> {
    return this.http.delete<void>(
      `${environment.baseApiUrl}/${this.url}/${id}`
    );
  }

  getArContentView(elevation: number): Observable<string> {
    return this.http.get(`${environment.baseApiUrl}/${this.url}/elevation/${elevation}` ,{ responseType: 'text' })
  }
}
