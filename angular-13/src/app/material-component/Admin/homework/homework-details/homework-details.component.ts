
import { Component, OnInit,ElementRef } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { DomSanitizer } from "@angular/platform-browser";
import { ActivatedRoute, Router } from "@angular/router";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { Enum } from "src/app/Enum";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-homework-details",
  templateUrl: "./homework-details.component.html",
  styleUrls: ["./homework-details.component.scss"]
})
export class HomeworkDetailComponent implements OnInit {
  homeworks: any;
  domSanitizers:any;
  enum = "Homeworks";
  id:any;
  constructor(private httpService: HttpServerService,
    private domSanitizer: DomSanitizer,
    activatedRouter: ActivatedRoute,) {
    this.domSanitizers = domSanitizer;
    this.id = activatedRouter.snapshot.paramMap.get("id");
  }
  ngOnInit(): void {
    this.httpService.Get("Homeworks/"+this.id).subscribe((data) => {
      this.homeworks = data;
      console.log(this.id, localStorage.getItem("teamId"));

      console.log("homework",data);
    });
  }
}
