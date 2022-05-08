import { Component, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";

@Component({
  selector: "app-score-view",
  templateUrl: "./score-view.component.html",
  styleUrls: ["./score-view.component.scss"],
})
export class ScoreComponent implements OnInit {
  displayedColumns: string[] = ["subject", "15P", "60P", "HK", "TB"];
  dataSource: any;
  scores: Score[] = [];
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService.Get("Subject").subscribe((subject) => {
      this.httpService.Get("Scores/student/1/Semester/3").subscribe((data) => {
        subject.forEach((element: any) => {
          var socreSb = data.filter((x: any) => x.subjectId == element.id);
          var score = new Score();
          score.score15p = socreSb[0]?.point;
          score.score60p = socreSb[1]?.point;
          score.scoreHK = socreSb[2]?.point;
          score.subject = element.name;
          score.scoreTb = +(
            (socreSb[0]?.point +
              socreSb[1]?.point * 2 +
              socreSb[2]?.point * 3) /
            6
          ).toFixed(2);
          this.scores.push(score);
        });
        console.log(this.scores);
        this.dataSource = this.scores;
      });
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
