import { Component, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";

@Component({
  selector: "app-score-list",
  templateUrl: "./score-list.component.html",
  styleUrls: ["./score-list.component.scss"],
})
export class ScoreListComponent implements OnInit {
  teams: any;
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService
      .Get("Teachers/get-teams?teacherId=" + localStorage.getItem("teacherId"))
      .subscribe((data) => {
        console.log(data);
        this.teams = data;
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
