import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Login/login/login.component';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private REST_API_SERVER = 'https://localhost:44360/api';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }
  data = [];

  constructor(private httpClient:HttpClient) { }

  public Login(data:User):Observable<any>{
    const url = this.REST_API_SERVER +'/Users/Authenticate';
    return this.httpClient.post<any>(url,data, this.httpOptions);
  }
}
