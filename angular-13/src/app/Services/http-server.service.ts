import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class HttpServerService {
  private REST_API_SERVER = "https://localhost:44360/api/";
  private httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };
  constructor(private httpClient: HttpClient) {}

  public Get(url: string): Observable<any> {
    url = this.REST_API_SERVER + url;
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public getComments(): Observable<any> {
    const url = this.REST_API_SERVER + "ThoiKhoaBieu/getTKB";
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public getTeams(): Observable<any> {
    const url = this.REST_API_SERVER + "Teams";
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public Post(url: string, data: any): Observable<any> {
    url = this.REST_API_SERVER + url;
    return this.httpClient.post<any>(url, data, this.httpOptions);
  }
}
