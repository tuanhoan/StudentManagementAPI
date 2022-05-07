import { Component, OnInit } from "@angular/core";
import { Blog } from "./blog-type";
import { ServiceblogService } from "./blog-service.service";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { TeacherServiceService } from "src/app/Services/teacher-service.service";
import { NewsFeedService } from "./newsfeed.service";

@Component({
  selector: "app-newsfeed",
  templateUrl: "./newsfeed.component.html",
  styleUrls: ["./newsfeed.component.css"],
})
export class NewsfeedComponent implements OnInit {
  blogsDetail: Blog[] = [];
  newsfeeds:any;

  constructor(
    public service: ServiceblogService,
    public router: Router,
    public http: HttpClient,
    private newsfeedService: NewsFeedService
  ) {
    this.service.showEdit = false;
  }

  ngOnInit(): void {
    if (this.service.Blogs.length === 0)
      this.service.getBlog().subscribe((d: any) => (this.service.Blogs = d));

    this.newsfeedService.getAll().subscribe((data) => {
      console.log(data);
      this.newsfeeds = data;
    });

    console.log(this.service);
  }

  loginClick() {
    this.router.navigate(["/login"]);
  }

  newPost() {
    this.router.navigate(["/post"]);
  }

  viewDetail(id: number) {
    this.service.detailId = id;

    if (this.service.loginStatusService) this.service.showEdit = true;

    this.router.navigate(["user/blogDetail", id]);
  }
}
