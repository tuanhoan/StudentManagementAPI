import { Component, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-exercise-list",
  templateUrl: "./exercise-list.component.html",
  styleUrls: ["./exercise-list.component.scss"],
})
export class ExerciseListComponent implements OnInit {
  subjects: any;
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService.Get("Homeworks/teamId/31").subscribe((data) => {
      console.log(data);
      this.subjects = data;
    });
  }
}
