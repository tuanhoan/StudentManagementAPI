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
  studentId: any;
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
  }
  ngOnInit(): void {
    let oldId = 0;
    let student: any;
    this.httpService
      .Get("Scores/subjectId/1/teamId/1/semester/1")
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

    // this.httpService.Get("Students/teams/" + this.id).subscribe((data: any) => {
    //   data.forEach((item: any) => {
    //     let std = new Student();
    //     std.fullName = item.appUser.fullName;
    //     std.email = item.appUser.email;
    //     std.birthday = item.appUser.birthday;
    //     std.phoneNumber = item.appUser.phoneNumber;
    //     std.team = item.teamNavigation?.name;
    //     std.userName = item.appUser.userName;
    //     std.Id = item.id;
    //     this.students.push(std);
    //   });
    //   this.dataSource = new MatTableDataSource<Student>(this.students);
    //   this.dataSource.paginator = this.paginator;
    // });
  }
  ViewScore(Id: any) {
    this.isList = false;
    this.studentId = Id;
    console.log(Id);
  }
}

export class Student {
  Id = "";
  fullName: string = "";
  email: string = "";
  birthday: Date = new Date();
  phoneNumber: string = "";
  team: string = "";
  userName = "";
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
