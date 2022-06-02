import { Component, Input, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import { ServiceblogService } from "../../blog/blog-service.service";

@Component({
  selector: "app-user-homework-details",
  templateUrl: "./user-homework-details.component.html",
  styleUrls: ["./user-homework-details.component.css"],
})
export class UserHomeworkDetailsComponent implements OnInit {
  constructor(private httpService: HttpServerService) {}
  subjects: any;
  ngOnInit(): void {
    this.httpService.Get("Subject").subscribe((data) => {
      console.log(data);
      this.subjects = data;
    });
  }
}
