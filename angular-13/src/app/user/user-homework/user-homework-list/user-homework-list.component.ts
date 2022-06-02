import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { HttpServerService } from "src/app/Services/http-server.service";
import { ServiceblogService } from "../../blog/blog-service.service";

@Component({
  selector: "app-user-homework-list",
  templateUrl: "./user-homework-list.component.html",
  styleUrls: ["./user-homework-list.component.css"],
})
export class UserHomeworkListComponent implements OnInit {
  id: any;
  constructor(
    private httpService: HttpServerService,
    activatedRouter: ActivatedRoute
  ) {
    this.id = activatedRouter.snapshot.paramMap.get("id");
  }
  homeworks: any;
  ngOnInit(): void {
    this.httpService
      .Get(
        "Homeworks/subject/" +
          this.id +
          "/team/" +
          localStorage.getItem("teamId")
      )
      .subscribe((data) => {
        console.log(data);
        this.homeworks = data;
      });
  }
}
