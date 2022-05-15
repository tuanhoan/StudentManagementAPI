import { Component, Input, OnInit } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";

@Component({
  selector: "app-exercise",
  templateUrl: "./exercise.component.html",
  styleUrls: ["./exercise.component.css"],
})
export class ExerciseComponent implements OnInit {
  comments: any;
  @Input() Id: number = 0;
  content = "";

  constructor(
    public service: HttpServerService,
  ) {
  }
  ngOnInit(): void {
    this.service.Get("Exercises/"+this.Id).subscribe((data) => {
      this.comments = data;
      console.log(data);

    });
  }

  public async submit() {
    // if (this.content == "") {
    //   return;
    // }
    // let body = {
    //   UserId: localStorage.getItem("userId"),
    //   newsFeedId: this.Id,
    //   Content: this.content,
    // };
    // this.content = "";
    // (await this.commentService.Comment(body)).subscribe((data) => {
    //   console.log("success", data);
    //   this.commentService.getById(this.Id).subscribe((data) => {
    //     console.log(data);
    //     this.comments = data;
    //   });
    // });
  }
}
