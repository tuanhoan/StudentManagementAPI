import {
  HttpClient,
  HttpErrorResponse,
  HttpEventType,
  HttpHeaders,
} from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-homework",
  templateUrl: "./homework.component.html",
  styleUrls: ["./homework.component.scss"],
})
export class HomeworkComponent implements OnInit {
  formHomework!: FormGroup;
  id: any;
  constructor(
    private httpService: HttpClient,
    private service: HttpServerService,
    public router: Router,
    activatedRouter: ActivatedRoute
  ) {
    this.id = activatedRouter.snapshot.paramMap.get("id");
  }
  ngOnInit(): void {
    console.log(localStorage);
    this.formHomework = new FormGroup({
      title: new FormControl(""),
      content: new FormControl(""),
      file: new FormControl(),
    });
  }
  public Editor = ClassicEditor;

  httpOptionss = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
      // 'Authorization': 'Bearer ' + this.token,
      // "Access-Control-Allow-Origin":"*"
    }),
  };
  fileName = "";

  public model = {
    title: "",
    content: "",
    userId: "",
  };
  progress: any;
  message: any;
  onUploadFinished: any;
  files: File[] = [];

  onFileSelected(event: any) {
    this.files = event.target.files;
    Array.from(this.files).map((file) => {
      return (this.fileName += file.name + " |");
    });

    console.log(this.formHomework.value);
  }
  onSubmit() {
    console.log(this.formHomework);
    const formData = new FormData();

    Array.from(this.files).map((file, index) => {
      return formData.append("formFiles", file, file.name);
    });
    formData.append("title", this.model.title);
    formData.append("content", this.model.content);
    formData.append("userId", localStorage.getItem("userId")!);
    formData.append("teamId", "31");

    this.service
      .Post("Homeworks", formData, {
        // reportProgress: true,
        // observe: "events",
      })
      .subscribe((data) => {
        console.log(data);
      });

    this.model.content = "";
    this.model.title = "";
    this.files = [];
    console.log(`Form submit, model: ${JSON.stringify(this.model)}`);
  }
}
