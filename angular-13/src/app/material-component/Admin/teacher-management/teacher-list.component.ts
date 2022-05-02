import { AfterViewInit, Component, Input, OnInit, ViewChild } from "@angular/core";
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
} from "@angular/cdk/drag-drop";
import { HttpServerService } from "src/app/Services/http-server.service";
import { compileClassMetadata } from "@angular/compiler";
import { MapTeacherSubjectTeamServiceService } from "src/app/Services/map-teacher-subject-team-service.service";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import { TeacherServiceService } from "src/app/Services/teacher-service.service";
import { Observable } from "rxjs";
import { MaterialComponentsModule } from "../../material.module";
import { ActivatedRoute, Router } from "@angular/router";
import { map, switchMap } from "rxjs/operators";

@Component({
  selector: "app-teacher-list",
  templateUrl: "./teacher-list.component.html",
  styleUrls: ["./teacher-list.component.scss"],
})
export class TeacherListComponent implements AfterViewInit, OnInit {
  teachers = [];
  Datas: PeriodicElement[] = [];
  ELEMENT_DATA: PeriodicElement[] = [];

  constructor(
    private teacherService: TeacherServiceService,
    private mapTeacherSubjectTeamService: MapTeacherSubjectTeamServiceService
  ) {}
  ngOnInit(): void {
    this.teacherService.getAll().subscribe((data) => {
      this.teachers = data;
      // console.log(new MatTableDataSource<any>(this.teachers));
      this.teachers.forEach((element: any, index) => {
        this.ELEMENT_DATA.push({
          id: element.id,
          position: index + 1,
          name: element.name,
          email: element.appUser.email,
          subject: element.subjectNavigation.name,
          username: element.appUser.userName,
        });
      });

      this.dataSource = new MatTableDataSource<PeriodicElement>(this.ELEMENT_DATA);
      console.log(this.ELEMENT_DATA);
      this.dataSource.paginator = this.paginator;
      // console.log(this.paginator);
    });

  }

  displayedColumns: string[] = ["no", "name", "subject", "email", "username", "action"];
  dataSource = new MatTableDataSource<PeriodicElement>(this.ELEMENT_DATA);

  @ViewChild(MatPaginator) paginator!: MatPaginator;


  ngAfterViewInit() {
    // this.dataSource = new MatTableDataSource<PeriodicElement>(this.ELEMENT_DATA);
    // setTimeout(() => this.dataSource.paginator = this.paginator,10000);
    console.log("after",this.paginator);

    // this.dataSource.paginator = this.paginator;
  }

  ViewChild(id: number){

  }
}

export interface PeriodicElement {
  id: number;
  name: string;
  position: number;
  email: string;
  subject: string;
  username: string;
}
