import { Component, Input, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";

@Component({
  selector: "app-score-item",
  templateUrl: "./score-item.component.html",
  styleUrls: ["./score-item.component.scss"],
})
export class ScoreItemComponent implements OnInit {
  @Input() SemesterId = 0;
  @Input() StudentId = localStorage.getItem("studentId");
  displayedColumns: string[] = ["subject", "15P", "60P", "HK", "TB"];
  dataSource: any;
  scores: Score[] = [];
  semester: any;
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService.Get("Semesters").subscribe((data) => {
      this.semester = data;
    });

    this.httpService.Get("Subject").subscribe((subject) => {
      this.httpService
        .Get(
          "Scores/student/" + this.StudentId + "/Semester/" + this.SemesterId
        )
        .subscribe((data) => {
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
          this.dataSource = this.scores;
        });
    });
  }
  DbClick() {}
}

export class Score {
  subject: string = "";
  score15p: number = 0;
  score60p: number = 0;
  scoreHK: number = 0;
  scoreTb: number = 0;
}
