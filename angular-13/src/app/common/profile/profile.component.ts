import { flatten } from "@angular/compiler";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import {
  FormControl,
  FormGroup,
  FormGroupDirective,
  NgForm,
  Validators,
} from "@angular/forms";
import { ErrorStateMatcher } from "@angular/material/core";
import { HttpServerService } from "src/app/Services/http-server.service";
import { LoginService } from "src/app/Services/login.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.scss"],
})
export class ProfileComponent implements OnInit {
  profile: Profile = new Profile();

  constructor(private httpService: HttpServerService) {}

  ngOnInit(): void {
    this.httpService
      .Get("Users/" + localStorage.getItem("username"))
      .subscribe((data) => {
        this.profile.id = data.id;
        this.profile.address = data.address;
        this.profile.username = data.userName;
        this.profile.fullName = data.fullName;
        this.profile.birthday = data.birthday;
        this.profile.phoneNumber = data.phoneNumber;
        this.profile.email = data.email;
        this.profile.isStudent = data.isStudent == "False" ? false : true;
        this.profile.avatar =
          data.avatarPath == null
            ? "https://thuthuatnhanh.com/wp-content/uploads/2020/09/hinh-anh-avatar-de-thuong.jpg"
            : data.avatarPath;

        console.log(this.profile.isStudent);
      });
  }

  public SaveChange() {
    console.log(this.profile);
    this.httpService
      .Post("Users/UpdateInfo", this.profile)
      .subscribe((data) => {
        console.log(data);
      });
  }
  UploadAvatar() {
    console.log("uploaded");
  }
  onFileSelected(event: any) {
    const formData = new FormData();
    console.log(event.target.files);
    let files = event.target.files;
    Array.from(files).map((file: any, index) => {
      return formData.append("files", file, file.name);
    });
    this.httpService
      .Post(
        "Users/UpdateAvatar?username=" + localStorage.getItem("username"),
        formData,
        {}
      )
      .subscribe((data) => {
        this.httpService
          .Get("Users/" + localStorage.getItem("username"))
          .subscribe((data) => {
            console.log(data);

            this.profile.id = data.id;
            this.profile.address = data.address;
            this.profile.username = data.userName;
            this.profile.fullName = data.fullName;
            this.profile.birthday = data.birthday;
            this.profile.phoneNumber = data.phoneNumber;
            this.profile.email = data.email;
            this.profile.isTeacher = !data.isStudent;
            this.profile.isStudent = data.isStudent;
            this.profile.avatar =
              data.avatarPath == null
                ? "https://thuthuatnhanh.com/wp-content/uploads/2020/09/hinh-anh-avatar-de-thuong.jpg"
                : data.avatarPath;

            localStorage.setItem("avatar", this.profile.avatar);
          });
      });
  }
}

export class Profile {
  id: string = "";
  fullName: string = "";
  phoneNumber: string = "";
  birthday: string = "";
  email: string = "";
  username: string = "";
  address: string = "";
  isStudent: boolean = false;
  isTeacher: boolean = false;
  avatar: string = "";
}
