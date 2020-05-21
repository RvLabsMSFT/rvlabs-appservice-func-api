import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EchoApiService {

  siteURL = "http://localhost:7071/api/echo_api";
  httpHeaders = new HttpHeaders({
    'Content-Type':  'application/json'
  });

  constructor(private http: HttpClient) { }


  postUser(user): Observable<any> {
    return this.http.post(this.siteURL, user, {headers: this.httpHeaders, observe: 'response'})
  }
}
