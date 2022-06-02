import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatPaginator } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Router } from "@angular/router";
import { Observable } from "rxjs-compat";
import { map, startWith } from "rxjs/operators";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-student-list",
  templateUrl: "./student-list.component.html",
  styleUrls: ["./student-list.component.scss"],
})
export class StudentListComponent implements OnInit, AfterViewInit {
  constructor(public httpService: HttpServerService, private router: Router) {}
  displayedColumns: string[] = [
    "FullName",
    "Email",
    "Birthday",
    "PhoneNumber",
    "User",
    "Team",
  ];
  students: Student[] = [];
  options: any;
  myControl = new FormControl();
  filteredOptions!: Observable<string[]>;
  dataSource: any = new MatTableDataSource<Student>(this.students);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  AddStudent() {
    this.router.navigate(["students"]);
  }
  GetAll() {
    this.students = [];
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

  ngOnInit(): void {
    this.httpService.Get("Teams").subscribe((data) => {
      console.log(data);
      this.options = data;

      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(""),
        map((value) => (typeof value === "string" ? value : value.name)),
        map((name) => (name ? this._filter(name) : this.options.slice()))
      );
    });
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

  private _filter(name: string): any {
    const filterValue = name.toLowerCase();

    return this.options.filter((option: any) =>
      option.name.toLowerCase().includes(filterValue)
    );
  }
  displayFn(options: any): string {
    return options && options.name ? options.name : "";
  }
  public onSelectionChange(value: any) {
    this.students = [];
    this.httpService
      .Get("Students/teams/" + value.option.value.id)
      .subscribe((data: any) => {
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
}

export class Student {
  fullName: string = "";
  email: string = "";
  birthday: Date = new Date();
  phoneNumber: string = "";
  team: string = "";
  userName = "";
}
