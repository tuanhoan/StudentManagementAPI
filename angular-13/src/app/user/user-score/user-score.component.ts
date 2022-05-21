import { Component, Input, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import { ServiceblogService } from "../blog/blog-service.service";

@Component({
  selector: "app-user-score",
  templateUrl: "./user-score.component.html",
  styleUrls: ["./user-score.component.css"],
})
export class UserScoreComponent implements OnInit {
  ngOnInit(): void {

  }
}

