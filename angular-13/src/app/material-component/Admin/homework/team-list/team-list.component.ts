import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Router } from "@angular/router";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-team-list",
  templateUrl: "./team-list.component.html",
  styleUrls: ["./team-list.component.scss"],
})
export class TeamListComponent implements OnInit {
  teams: any;
  constructor(private httpService: HttpServerService) {}
  ngOnInit(): void {
    this.httpService
      .Get("Teachers/get-teams?teacherId=" + localStorage.getItem("teacherId"))
      .subscribe((data) => {
        console.log(data);
        this.teams = data;
      });
  }
}
