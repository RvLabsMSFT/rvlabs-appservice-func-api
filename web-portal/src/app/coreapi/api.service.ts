import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  httpHeaders = new HttpHeaders({
    'Accept':  'application/json'
  });

  constructor( private http: HttpClient ) { }

  SendGetRequest( endpoint, path): Observable<any> {
    return this.http.get(endpoint + path, { 
      headers: { 'Accept': 'application/json' }, 
      observe: 'response'
    });
  }
}
