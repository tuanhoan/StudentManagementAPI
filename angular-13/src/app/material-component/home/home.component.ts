import { Component } from "@angular/core";
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem,
} from "@angular/cdk/drag-drop";
import { HttpServerService } from "src/app/Services/http-server.service";
import { compileClassMetadata } from "@angular/compiler";
import { MapTeacherSubjectTeamServiceService } from "src/app/Services/map-teacher-subject-team-service.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
})
export class HomeComponent {
  constructor(
    private httpServerService: HttpServerService,
    private mapTeacherSubjectTeamService: MapTeacherSubjectTeamServiceService
  ) {}

  result: any = [];
  teams: any = [];

  ngOnInit(): void {
    this.httpServerService.getTeams().subscribe((data) => {
      this.teams = data;
    });
    this.httpServerService.getComments().subscribe((data) => {
      data.forEach((element: []) => {
        let temp: any = [];
        element.forEach((x: string) => {
          let obj = new Test();
          obj.name = x.split("-")[0] + "-" + x.split("-")[1];
          obj.color = "white";
          temp.push(obj);
        });
        this.result.push(temp);
      });
      this.RoteteMatrix(this.result);
      console.log(this.result);
    });
  }

  drop(event: CdkDragDrop<any[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
      if (event.previousIndex < event.currentIndex)
        moveItemInArray(
          event.container.data,
          event.currentIndex - 1,
          event.previousIndex
        );
      else
        moveItemInArray(
          event.container.data,
          event.currentIndex + 1,
          event.previousIndex
        );
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
      transferArrayItem(
        event.container.data,
        event.previousContainer.data,
        event.currentIndex + 1,
        event.previousIndex
      );
    }
    this.RoteteMatrix(this.result);
  }

  RoteteMatrix(matrix: any) {
    var newGrid = [];

    for (var j = 0; j < matrix[0].length; j++) {
      var temp = [];
      for (var i = 0; i < matrix.length; i++) {
        if (matrix[i][j] != undefined) temp.push(matrix[i][j]);
      }
      if (temp != undefined) newGrid.push(temp);
    }

    newGrid.forEach((item) => {
      item.forEach((kk) => {
        if (kk != undefined) {
          var name = kk.name;
          if (item.filter((x: any) => x.name === name).length > 1) {
            kk.color = "red";
          } else {
            kk.color = "white";
          }
        }
      });
    });
  }

  FillColor() {
    // let array = [
    //   0, 1, 2, 3, 8, 9, 10, 11, 16, 17, 18, 19, 24, 25, 26, 27, 32, 33, 34, 35,
    //   36,
    // ];
    // for (let i = 0; i < this.result.length; i++) {
    //   for (let j = 0; j < this.result[i].length; j++) {
    //     if (array.filter((x) => x == j).length > 0) {
    //       this.result[i][j].color = "blue";
    //     }
    //   }
    // }
  }
}

export class Test {
  name: string = "";
  color: string = "";
}
