import { Component, OnInit, ViewChild } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { MatTableDataSource } from "@angular/material/table";
import { FormControl } from "@angular/forms";
import { Observable } from "rxjs-compat";
import { MatPaginator } from "@angular/material/paginator";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-score-student",
  templateUrl: "./score-student.component.html",
  styleUrls: ["./score-student.component.scss"],
})
export class ScoreStudentComponent implements OnInit {
  isList = true;
  isEdit = false;
  studentId: any;
  subjectid: any;
  displayedColumns: string[] = [
    "FullName",
    "Score15P",
    "Score60P",
    "ScoreHK",
    "ScoreTB",
  ];
  studentScore: any = [];
  options: any;
  id: any;
  myControl = new FormControl();
  filteredOptions!: Observable<string[]>;
  dataSource: any = new MatTableDataSource<StudentScore>(this.studentScore);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(
    private httpService: HttpServerService,
    activatedRouter: ActivatedRoute
  ) {
    this.id = activatedRouter.snapshot.paramMap.get("id");
    this.subjectid = activatedRouter.snapshot.paramMap.get("subjectid");
  }
  ngOnInit(): void {
    let oldId = 0;
    let student: any;
    this.httpService
      .Get(
        "Scores/subjectId/" +
          this.subjectid +
          "/teamId/" +
          this.id +
          "/semester/1"
      )
      .subscribe((data: any) => {
        data.forEach((element: any) => {
          if (oldId != element.studentId) {
            if (oldId != 0) {
              this.studentScore.push(student);
            }
            oldId = element.studentId;
            student = new StudentScore();
            student.semesterId = element.semesterId;
            student.semesterName = element.semesterName;
            student.studentId = element.studentId;
            student.studentName = element.studentName;
            student.subjectId = element.subjectId;
            student.subjectName = element.subjectName;
            student.testTypeName = element.testTypeName;
            student.testTypeId = element.testTypeId;
          }
          if (element.testTypeId == 1) {
            student.score15p = element.point;
          }
          if (element.testTypeId == 2) {
            student.score60p = element.point;
          }
          if (element.testTypeId == 3) {
            student.scoreHK = element.point;
          }
        });
        this.dataSource = new MatTableDataSource<StudentScore>(
          this.studentScore
        );
        this.dataSource.paginator = this.paginator;
        console.log(this.dataSource);
      });
  }
  ViewScore(Id: any) {
    this.isList = false;
    this.studentId = Id;
    console.log(Id);
  }
  Edit() {
    this.isEdit = !this.isEdit;
    let scoreCreates: any = [];
    this.studentScore.forEach((element: any) => {
      console.log(element);

      if (element.score15p != null) {
        let student = new ScoreCreate();
        student.semesterId = element.semesterId;
        student.studentId = element.studentId;
        student.subjectId = element.subjectId;
        student.testTypeId = 1;
        student.point = element.score15p;
        scoreCreates.push(student);
      }
      if (element.score60p != null) {
        let student = new ScoreCreate();
        student.semesterId = element.semesterId;
        student.studentId = element.studentId;
        student.subjectId = element.subjectId;
        student.testTypeId = 2;
        student.point = element.score60p;
        scoreCreates.push(student);
      }
      if (element.scoreHK != null) {
        let student = new ScoreCreate();
        student.semesterId = element.semesterId;
        student.studentId = element.studentId;
        student.subjectId = element.subjectId;
        student.testTypeId = element.testTypeId;
        student.point = 3;
        scoreCreates.push(student);
      }
    });
    console.log(scoreCreates);
    this.httpService.Post("Scores/update", scoreCreates).subscribe((data) => {
      console.log("hhee", data);
    });
  }
}

export class ScoreCreate {
  semesterId = 0;
  studentId = 0;
  subjectId = 0;
  testTypeId = 0;
  point = 0;
}

export class StudentScore {
  studentName = "";
  studentId = 0;
  semesterId = 0;
  semesterName = "";
  testTypeName = "";
  testTypeId = 0;
  subjectId = 0;
  subjectName = "";
  score15p: number = 0;
  score60p: number = 0;
  scoreHK: number = 0;
  scoreTb: number = 0;
}
