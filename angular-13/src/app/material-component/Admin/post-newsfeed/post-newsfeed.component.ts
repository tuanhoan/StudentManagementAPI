import { Component } from "@angular/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { NewsfeedService } from "./newsfeed.service";

@Component({
  selector: "app-post-newsfeed",
  templateUrl: "./post-newsfeed.component.html",
  styleUrls: ["./post-newsfeed.component.scss"],
})
export class PostNewsFeedComponent {
  constructor(private newsfeedService: NewsfeedService) {}
  public Editor = ClassicEditor;

  public model = {
    title: "",
    content: "",
  };

  onSubmit() {
    this.newsfeedService.PostNewsfeed(this.model).subscribe((data) => {
      console.log(data);
    });

    this.model.content = "";
    this.model.title = "";
    console.log(`Form submit, model: ${JSON.stringify(this.model)}`);
  }
}
