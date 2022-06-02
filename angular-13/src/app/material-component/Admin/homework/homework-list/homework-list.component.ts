import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-homework-list",
  templateUrl: "./homework-list.component.html",
  styleUrls: ["./homework-list.component.scss"],
})
export class HomeworkListComponent implements OnInit {
  homeworks: any;
  id: any;
  isAdd: boolean = false;
  constructor(
    private httpService: HttpServerService,
    activatedRouter: ActivatedRoute
  ) {
    this.id = activatedRouter.snapshot.paramMap.get("id");
  }
  ngOnInit(): void {
    this.httpService.Get("Homeworks/teamId/" + this.id).subscribe((data) => {
      console.log(data);
      this.homeworks = data;
    });
  }
}
