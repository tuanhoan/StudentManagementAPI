import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { map, startWith } from "rxjs/operators";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
  styleUrls: ["./student-list.component.scss"],
})
export class StudentListComponent implements OnInit, AfterViewInit {
  constructor(public httpService: HttpServerService) {}
  students: Student[] = [];

  ngOnInit(): void {
    this.httpService.Get("Students").subscribe((data: any) => {
      data.forEach((item: any) => {
        let std = new Student();
        std.fullName = item.appUser.fullName;
        std.email = item.appUser.email;
        std.birthday = item.appUser.birthday;
        std.phoneNumber = item.appUser.phoneNumber;
        std.team = item.teamNavigation?.name;
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
    "Team",
  ];
  dataSource: any = new MatTableDataSource<Student>(this.students);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    console.log(this.dataSource);
    this.dataSource.paginator = this.paginator;
  }

}


export class Student {
  fullName: string = "";
  email: string = "";
  birthday: Date = new Date();
  phoneNumber: string = "";
  team: string = "";
}
