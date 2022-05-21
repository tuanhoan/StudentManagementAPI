import { Component, Input, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import { ServiceblogService } from "../blog/blog-service.service";

@Component({
  selector: "app-user-homework",
  templateUrl: "./user-homework.component.html",
  styleUrls: ["./user-homework.component.css"],
})
export class UserHomeworkComponent implements OnInit {
  constructor(private httpService: HttpServerService) {}
  subjects:any;
  ngOnInit(): void {
    this.httpService.Get("Subject").subscribe((data) => {
      console.log(data);
      this.subjects= data;
    });
  }
}
