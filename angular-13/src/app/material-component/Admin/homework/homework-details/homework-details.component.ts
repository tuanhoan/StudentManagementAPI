
import { Component, OnInit,ElementRef } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { DomSanitizer } from "@angular/platform-browser";
import { Router } from "@angular/router";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-homework-details",
  templateUrl: "./homework-details.component.html",
  styleUrls: ["./homework-details.component.scss"]
})
export class HomeworkDetailComponent implements OnInit {
  homeworks: any;
  domSanitizers:any;
  constructor(private httpService: HttpServerService,private domSanitizer: DomSanitizer) {
    this.domSanitizers = domSanitizer;
  }
  ngOnInit(): void {
    this.httpService.Get("Homeworks/41").subscribe((data) => {
      console.log(data);
      this.homeworks = data;
    });
  }
}
