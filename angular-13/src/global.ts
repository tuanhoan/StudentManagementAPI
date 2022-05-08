import { HttpClient, HttpHeaders } from "@angular/common/http";

export const GlobalVariable = Object.freeze({
  REST_API_SERVER: "https://localhost:44360/api",
  httpOptions: {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  },
});
