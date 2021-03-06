import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { HttpServerService } from "src/app/Services/http-server.service";
import { LoginService } from "src/app/Services/login.service";

@Component({
  selector: "app-login-page",
  templateUrl: "./login-page.component.html",
  styleUrls: ["./login-page.component.css"],
})
export class LoginPageComponent implements OnInit {
  constructor(
    private httpLogin: LoginService,
    private httpServer: HttpServerService,
    private router: Router,
    public snackBar: MatSnackBar
  ) {}

  formLogin = new FormGroup({
    username: new FormControl("", [Validators.required]),
    password: new FormControl("", [
      Validators.required,
      Validators.minLength(8),
    ]),
  });
  user: User = new User();

  ngOnInit(): void {}

  Login() {
    this.user = this.formLogin.value;
    let infor = new Infor();
    this.httpLogin.Login(this.user).subscribe(
      (data) => {
        if (data != null) {
          infor.token = data.item1;
          infor.username = data.item2;
          infor.userId = data.item4;
          infor.role = data.item3[0];

          localStorage.setItem("token", infor.token);
          localStorage.setItem("username", infor.username);
          localStorage.setItem("userId", infor.userId);
          localStorage.setItem("role", infor.role);

          this.httpServer.Get("Users/" + infor.username).subscribe((user) => {
            console.log(user);

            localStorage.setItem("fullName", user.fullName);
            localStorage.setItem("studentId", user.studentId);
            localStorage.setItem("teacherId", user.teacherId);
            localStorage.setItem("teamId", user.teamId);
            localStorage.setItem("avatar", user.avatarPath);
            localStorage.setItem("isStudent", user.isStudent);

            if (infor.role == "admin" || infor.role == "teacher") {
              console.log("sdasd");

              this.router.navigate([""]);
            }

            if (infor.role == "student") this.router.navigate(["user"]);
          });

          this.snackBar.open("????ng nh???p th??nh c??ng", undefined, {
            duration: 2000,
          });
        }
      },
      (error) => {
        this.snackBar.open("Sai t??n ????ng nh???p ho???c m???t kh???u", undefined, {
          duration: 2000,
        });
      }
    );
  }
}

export class User {
  userName: string = "";
  password: string = "";
}

export class Infor {
  token: string = "";
  username: string = "";
  userId: string = "";
  role: string = "";
}
