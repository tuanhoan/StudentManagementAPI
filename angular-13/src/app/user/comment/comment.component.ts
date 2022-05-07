import { Component, Input, OnInit } from "@angular/core";
import { ServiceblogService } from "../blog/blog-service.service";
import { CommentService } from "./comment.service";

@Component({
  selector: "app-comment",
  templateUrl: "./comment.component.html",
  styleUrls: ["./comment.component.css"],
})
export class CommentComponent implements OnInit {
  comments: any;
  @Input() Id: number = 0;
  content = "";

  constructor(
    public service: ServiceblogService,
    public commentService: CommentService
  ) {
    this.service.showEdit = false;
  }
  ngOnInit(): void {
    this.commentService.getById(this.Id).subscribe((data) => {
      console.log(data);
      this.comments = data;
    });
  }

  public async submit() {
    if (this.content == "") {
      return;
    }
    let body = {
      UserId: localStorage.getItem("userId"),
      newsFeedId: this.Id,
      Content: this.content,
    };
    this.content = "";
    (await this.commentService.Comment(body)).subscribe((data) => {
      console.log("success", data);
      this.commentService.getById(this.Id).subscribe((data) => {
        console.log(data);
        this.comments = data;
      });
    });
  }
}
