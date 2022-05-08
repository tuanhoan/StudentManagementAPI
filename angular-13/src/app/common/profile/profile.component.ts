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
    this.httpService.Get("Users/tuanhoan").subscribe((data) => {
      console.log(data);

      this.profile.id = data.id;
      this.profile.username = data.userName;
      this.profile.fullName = data.fullName;
      this.profile.birthday = data.birthday;
      this.profile.phoneNumber = data.phoneNumber ;
      this.profile.email = data.email;
      this.profile.isTeacher = data.teacherNavigation == null ? false : true;
      this.profile.isStudent = data.studentNavigation == null ? false : true;

      console.log(this.profile);
    });
  }

  public SaveChange(){
    console.log(this.profile);
    this.httpService.Post("Users/UpdateInfo", this.profile).subscribe(data=>{
      console.log(data);
    })
  }
}

export class Profile {
  id:string="";
  fullName: string = "";
  phoneNumber: string = "";
  birthday:string = "";
  email: string = "";
  username: string = "";
  address: string = "";
  isStudent: boolean = false;
  isTeacher: boolean = false;
}
