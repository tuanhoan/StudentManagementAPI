import { Component, Input, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";

@Component({
  selector: "app-score-view",
  templateUrl: "./score-view.component.html",
  styleUrls: ["./score-view.component.scss"],
})
export class ScoreComponent implements OnInit {
  semester: any;
  @Input() StudentId = localStorage.getItem("studentId");
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService.Get("Semesters").subscribe((data) => {
      this.semester = data;
    });
  }
}

export class Score {
  subject: string = "";
  score15p: number = 0;
  score60p: number = 0;
  scoreHK: number = 0;
  scoreTb: number = 0;
}
