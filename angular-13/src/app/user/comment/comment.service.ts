import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class CommentService {
  private REST_API_SERVER = "https://localhost:44360/api";
  private httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  constructor(private httpClient: HttpClient) {}

  public getAll(): Observable<any> {
    const url = this.REST_API_SERVER + "/Comments";
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public getById(id: number): Observable<any> {
    const url = this.REST_API_SERVER + "/Comments/" + id;
    return this.httpClient.get<any>(url, this.httpOptions);
  }

  public async Comment(data: any): Promise<Observable<any>> {
    const url = this.REST_API_SERVER + "/Comments";
    return await this.httpClient.post<any>(url, data, this.httpOptions);
  }
}
