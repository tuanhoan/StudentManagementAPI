import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class NewsfeedService {
  private REST_API_SERVER = "https://localhost:44360/api";
  private httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  constructor(private httpClient: HttpClient) {}

  public PostNewsfeed(data: any): Observable<any> {
    const url = this.REST_API_SERVER + "/Newsfeeds";
    return this.httpClient.post<any>(url, data, this.httpOptions);
  }
}
