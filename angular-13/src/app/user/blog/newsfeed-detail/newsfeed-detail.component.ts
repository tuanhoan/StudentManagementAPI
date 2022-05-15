import { Component, OnInit, ViewEncapsulation } from "@angular/core";
import { ServiceblogService } from "../blog-service.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Blog } from "../blog-type";
import { NewsFeedService } from "../newsfeed.service";

@Component({
  selector: "app-newsfeed-detail",
  templateUrl: "./newsfeed-detail.component.html",
  styleUrls: ["./newsfeed-detail.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class NewsfeedDetailComponent implements OnInit {
  id: any;
  blogDetail: any | null = null;

  constructor(
    activatedRouter: ActivatedRoute,
    public service: ServiceblogService,
    public router: Router,
    private newsfeedService: NewsFeedService
  ) {
    this.id = activatedRouter.snapshot.paramMap.get("id");
  }

  ngOnInit(): void {
    // this.blogDetail = this.service.Blogs.filter(x => x.id === +this.id)[0];
    this.newsfeedService.getById(this.id).subscribe((data) => {
      console.log(data);
      this.blogDetail = data;
    });
  }

  loginClick() {
    this.router.navigate(["/login"]);
  }

  newPost() {
    this.service.showEdit = false;
    this.router.navigate(["/post"]);
  }

  editPost() {
    this.service.showEdit = false;
    this.router.navigate(["/editPost", this.blogDetail?.id]);
  }

  // editPost(){
  //   this.router.navigate([('/editPost'), this.service?.detailId]);

  // }
}
