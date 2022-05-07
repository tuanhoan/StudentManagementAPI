import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class NewsFeedService {
  private REST_API_SERVER = "https://localhost:44360/api";
  private httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<any> {
    const url = this.REST_API_SERVER + "/NewsFeeds";
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public getById(id:number):Observable<any>{
    const url = this.REST_API_SERVER + "/NewsFeeds/" + id;
    return this.httpClient.get<any>(url, this.httpOptions);
  }
}
