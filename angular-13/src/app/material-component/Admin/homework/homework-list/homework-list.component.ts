import {
  HttpClient,
  HttpErrorResponse,
  HttpEventType,
  HttpHeaders,
} from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-homework-list",
  templateUrl: "./homework-list.component.html",
  styleUrls: ["./homework-list.component.scss"],
})
export class HomeworkListComponent implements OnInit {
  homeworks: any;
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService.Get("Homeworks/teamId/31").subscribe((data) => {
      console.log(data);
      this.homeworks = data;
    });
  }
}
