import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MapTeacherSubjectTeamServiceService {

  private REST_API_SERVER = 'https://localhost:44360/api';
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
  }

  constructor(private httpClient:HttpClient) { }

  public getMapTeacherSubjectTeam():Observable<any>{
    const url = this.REST_API_SERVER +'/ThoiKhoaBieu/getall';
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public getByTeacherId(Id:number):Observable<any>{
    const url = this.REST_API_SERVER +'/ThoiKhoaBieu/GetByTeacherId?Id='+Id;
    return this.httpClient.get<any>(url, this.httpOptions);
  }
}
