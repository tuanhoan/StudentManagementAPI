import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Router } from "@angular/router";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
  styleUrls: ["./student-list.component.scss"],
})
export class StudentListComponent implements OnInit, AfterViewInit {
  constructor(public httpService: HttpServerService, private router: Router) {}
  students: Student[] = [];

  ngOnInit(): void {
    console.log(localStorage);
    this.httpService.Get("Students").subscribe((data: any) => {
      data.forEach((item: any) => {
        let std = new Student();
        std.fullName = item.appUser.fullName;
        std.email = item.appUser.email;
        std.birthday = item.appUser.birthday;
        std.phoneNumber = item.appUser.phoneNumber;
        std.team = item.teamNavigation?.name;
        std.userName = item.appUser.userName;
        this.students.push(std);
      });
      this.dataSource = new MatTableDataSource<Student>(this.students);
      this.dataSource.paginator = this.paginator;
    });
  }
  displayedColumns: string[] = [
    "FullName",
    "Email",
    "Birthday",
    "PhoneNumber",
    "User",
    "Team",
  ];
  dataSource: any = new MatTableDataSource<Student>(this.students);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  AddStudent() {
    this.router.navigate(["students"]);
  }
}

export class Student {
  fullName: string = "";
  email: string = "";
  birthday: Date = new Date();
  phoneNumber: string = "";
  team: string = "";
  userName = "";
}
