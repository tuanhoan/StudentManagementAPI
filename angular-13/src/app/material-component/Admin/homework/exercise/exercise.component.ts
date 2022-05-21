import { Component, Input, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-exercise",
  templateUrl: "./exercise.component.html",
  styleUrls: ["./exercise.component.css"],
})
export class ExerciseComponent implements OnInit {
  comments: any;
  @Input() Id: number = 0;
  content = "";

  constructor(public service: HttpServerService) {}
  files = [];
  fileName = "";
  ngOnInit(): void {
    this.service.Get("Exercises/" + this.Id).subscribe((data) => {
      this.comments = data;
    });
  }
  onFileSelected(event: any) {
    this.files = event.target.files;
    Array.from(this.files).map((file: any) => {
      return (this.fileName += file.name + " |");
    });

    // console.log(this.formHomework.value);
  }
  public async submit() {
    if (this.content == "") {
      return;
    }
    const formData = new FormData();

    Array.from(this.files).map((file: any, index) => {
      return formData.append("formFiles", file, file.name);
    });
    formData.append("userId", localStorage.getItem("userId") + "");
    formData.append("homeworkId", this.Id + "");
    formData.append("content", this.content);

    this.content = "";
    this.fileName = "";
    this.files = [];

    (await this.service.Post("Exercises", formData, {})).subscribe((p) => {
      this.service.Get("Exercises/" + this.Id).subscribe((data) => {
        this.comments = data;
      });
    });
  }
}
